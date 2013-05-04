﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zing.Framework.Mvc.Expressions
{
    internal abstract class FilterExpressionBuilder : ExpressionBuilderBase
    {
        protected FilterExpressionBuilder(ParameterExpression parameterExpression) :
            base(parameterExpression.Type)
        {
            this.ParameterExpression = parameterExpression;
        }

        public abstract Expression CreateBodyExpression();

        /// <exception cref="ArgumentException"><c>ArgumentException</c>.</exception>
        public LambdaExpression CreateFilterExpression()
        {
            Expression bodyExpression = this.CreateBodyExpression();
            return Expression.Lambda(bodyExpression, this.ParameterExpression);
        }
    }
}