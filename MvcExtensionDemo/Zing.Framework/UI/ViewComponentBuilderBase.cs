using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Zing.Framework.UI
{
    public abstract class ViewComponentBuilderBase<TViewComponent, TBuilder> : ComponentBuilderBase<TViewComponent, TBuilder>
        where TViewComponent : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponent, TBuilder>
    {
        private TViewComponent _component;
        protected TViewComponent Component
        {
            get
            {
                return _component;
            }
            set
            {
                _component = value;
            }
        }
        public ViewComponentBuilderBase(TViewComponent component)
        {
            this._component = component;
        }

        public virtual TBuilder Name(string componentName)
        {
            Component.Name = componentName;

            return this as TBuilder;
        }

        public string ToHtmlString()
        {
            return Component.ToHtmlString();
        }
        public override string ToString()
        {
            return ToHtmlString();
        }
    }
}
