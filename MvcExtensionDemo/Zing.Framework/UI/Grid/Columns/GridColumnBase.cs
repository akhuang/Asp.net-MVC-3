using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.UI;

namespace Zing.Framework.UI
{
    public abstract class GridColumnBase : IGridColumn
    {
        public GridColumnBase()
        {
            Settings = new GridColumnSettings();
        }
        internal GridColumnSettings Settings
        {
            get;
            set;
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

    }
}
