using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public class GridColumnSettings
    {
        private string member;

        public GridColumnSettings()
        {
            //Sortable = true;
            //Encoded = true;
            //Filterable = true;
            //Groupable = true;
            Visible = true;
            //IncludeInContextMenu = true;
            HeaderHtmlAttributes = new RouteValueDictionary();
            //HtmlAttributes = new RouteValueDictionary();
            //FooterHtmlAttributes = new RouteValueDictionary();
        }


        public string Member
        {
            get
            {
                return member;
            }
            set
            {
                member = value;

                if (!Title.HasValue())
                {
                    Title = member.AsTitle();
                }
            }
        }
        public Type MemberType
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public string Width
        {
            get;
            set;
        }

        private bool hidden;
        public bool Hidden
        {
            get
            {
                return hidden;
            }
            set
            {
                //if (value)
                //{
                //    HtmlAttributes["style"] = PrepareStyle(Convert.ToString(HtmlAttributes["style"]));
                //}
                //else if (HtmlAttributes.ContainsKey("style"))
                //{
                //    HtmlAttributes["style"] = ((string)HtmlAttributes["style"]).Replace("display:none;", "");
                //}
                hidden = value;
            }
        }

        public IDictionary<string, object> HeaderHtmlAttributes
        {
            get;
            private set;
        }
    }
}
