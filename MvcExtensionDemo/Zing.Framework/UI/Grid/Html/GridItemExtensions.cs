using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI.Grid.Html
{
    internal static class GridItemExtensions
    {
        public static void AsAlternating(this GridItem item)
        {
            if (item.Index % 2 != 0)
            {
                item.State |= GridItemStates.Alternating;
            }
        }
    }
}
