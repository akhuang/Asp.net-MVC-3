using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    public class GridDetailViewItem : GridItem
    {
        public GridItem Parent
        {
            get;
            set;
        }

        public override bool Expanded
        {
            get
            {
                return Parent.Expanded;
            }
            set
            {
                Parent.Expanded = value;
            }
        }
    }
}
