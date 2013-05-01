using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public interface IGridBoundColumn : IGridColumn
    {
        string Member
        {
            get;
            set;
        }
    }
}
