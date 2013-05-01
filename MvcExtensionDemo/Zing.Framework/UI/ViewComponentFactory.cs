using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Zing.Framework.UI.Grid.Fluent;
using Zing.Framework.UI.Grid.Html;

namespace Zing.Framework.UI
{
    public class ViewComponentFactory
    {
        public ViewComponentFactory(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }

        public ViewContext ViewContext
        {
            get
            {
                return HtmlHelper.ViewContext;
            }
        }

        public virtual GridBuilder<T> Grid<T>() where T : class
        {
            //IMPORTANT
            //Must use GridBuilder<T>.Create, or it can't render content as html
            return GridBuilder<T>.Create(Register(() => new Grid<T>(ViewContext, DependencyResolver.Current.GetService<IGridHtmlBuilderFactory>())));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TViewComponent Register<TViewComponent>(Func<TViewComponent> factory) where TViewComponent : ViewComponentBase
        {
            var component = factory();

            //scriptRegistrarBuilder.ToRegistrar().Register(component);

            return component;
        }
    }

    public class ViewComponentFactory<TModel> : ViewComponentFactory
    {
        public ViewComponentFactory(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {

        }


    }
}
