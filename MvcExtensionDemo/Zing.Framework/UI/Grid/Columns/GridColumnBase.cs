using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.UI;
using Zing.Framework.UI.Grid.Html;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public abstract class GridColumnBase<T> : IGridColumn where T : class
    {
        public GridColumnBase(Grid<T> grid)
        {
            Settings = new GridColumnSettings();
            Grid = grid;
            Visible = true;
        }
        internal GridColumnSettings Settings
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the grid.
        /// </summary>
        /// <value>The grid.</value>
        public Grid<T> Grid
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the title of the column.
        /// </summary>
        /// <value>The title.</value>
        public virtual string Title
        {
            get
            {
                return Settings.Title;
            }
            set
            {
                Settings.Title = value;
            }
        }


        /// <summary>
        /// Gets the member of the column.
        /// </summary>
        /// <value>The member.</value>
        public string Member
        {
            get
            {
                return Settings.Member;
            }

            set
            {
                Settings.Member = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this column is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>. The default value is <c>true</c>.</value>
        /// <remarks>
        /// Invisible columns are not output in the HTML.
        /// </remarks>
        public bool Visible
        {
            get
            {
                return Settings.Visible;
            }
            set
            {
                Settings.Visible = value;
            }
        }



        /// <summary>
        /// Gets or sets the width of the column.
        /// </summary>
        /// <value>The width.</value>
        public string Width
        {
            get
            {
                return Settings.Width;
            }
            set
            {
                Settings.Width = value;
            }
        }

        public bool Hidden
        {
            get
            {
                return Settings.Hidden;
            }
            set
            {
                Settings.Hidden = value;
            }
        }

        /// <summary>
        /// Gets the header HTML attributes.
        /// </summary>
        /// <value>The header HTML attributes.</value>
        public IDictionary<string, object> HeaderHtmlAttributes
        {
            get
            {
                return Settings.HeaderHtmlAttributes;
            }
        }

        ///// <summary>
        ///// Gets the footer HTML attributes.
        ///// </summary>
        ///// <value>The footer HTML attributes.</value>
        //public IDictionary<string, object> FooterHtmlAttributes
        //{
        //    get
        //    {
        //        return Settings.FooterHtmlAttributes;
        //    }
        //}

        public IGridCellBuilder CreateHeaderBuilder()
        {
            var builder = CreateHeaderBuilderCore();

            //Decorate(builder);

            return builder;
        }

        protected virtual IGridCellBuilder CreateHeaderBuilderCore()
        {
            return new GridHeaderCellBuilder(HeaderHtmlAttributes, AppendHeaderContent);
        }

        protected void AppendHeaderContent(IHtmlNode container)
        {
            //if (HeaderTemplate != null && HeaderTemplate.HasValue())
            //{
            //    HeaderTemplate.Apply(container);
            //}
            //else
            //{
            container.Html(Title.HasValue() ? Title : "&nbsp;");
            //}
        }


        public IGridDataCellBuilder CreateDisplayCellBuilder()
        {
            throw new NotImplementedException();
        }
    }
}
