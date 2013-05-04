using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public class OrNode : IFilterNode, ILogicalNode
    {
        public IFilterNode First
        {
            get;
            set;
        }

        public IFilterNode Second
        {
            get;
            set;
        }

        public FilterCompositionLogicalOperator LogicalOperator
        {
            get
            {
                return FilterCompositionLogicalOperator.Or;
            }
        }

        public void Accept(IFilterNodeVisitor visitor)
        {
            visitor.StartVisit(this);

            First.Accept(visitor);
            Second.Accept(visitor);

            visitor.EndVisit();
        }
    }
}
