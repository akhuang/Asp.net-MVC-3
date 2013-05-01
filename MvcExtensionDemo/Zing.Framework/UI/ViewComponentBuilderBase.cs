using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Zing.Framework.UI
{
    public abstract class ViewComponentBuilderBase<TViewComponet, TBuilder>
        where TViewComponet : ViewComponentBase
        where TBuilder : ViewComponentBuilderBase<TViewComponet, TBuilder>
    {
        private TViewComponet _component;
        protected TViewComponet Component
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
        public ViewComponentBuilderBase(TViewComponet component)
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
