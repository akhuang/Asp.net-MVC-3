using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public interface IFilterNode
    {
        void Accept(IFilterNodeVisitor visitor);
    }
}
