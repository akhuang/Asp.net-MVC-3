// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.Mvc.Expressions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Zing.Framework.UI;
    using Zing.Framework.Utility.Extensions;
    
    internal class QueryableAggregatesExpressionBuilder : GroupDescriptorExpressionBuilder
    {
        public QueryableAggregatesExpressionBuilder(IQueryable queryable, IEnumerable<AggregateFunction> aggregateFunctions)
            : base(queryable, CreateDescriptor(aggregateFunctions))
        {
        }

        private static GroupDescriptor CreateDescriptor(IEnumerable<AggregateFunction> aggregateFunctions)
        {
            var groupDescriptor = new GroupDescriptor();
            groupDescriptor.AggregateFunctions.AddRange(aggregateFunctions);

            return groupDescriptor;
        }

        protected override LambdaExpression CreateGroupByExpression()
        {
            return Expression.Lambda(Expression.Constant(1), this.ParameterExpression);
        }

        protected override IEnumerable<MemberBinding> CreateMemberBindings()
        {
            yield return this.CreateKeyMemberBinding();
            yield return this.CreateCountMemberBinding();
            yield return this.CreateHasSubgroupsMemberBinding();
            if (GroupDescriptor.AggregateFunctions.Count > 0)
            {
                yield return this.CreateAggregateFunctionsProjectionMemberBinding();
            }            
        }
    }
}