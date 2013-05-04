﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zing.Framework.Mvc.Expressions;

namespace Zing.Framework.UI
{
    /// <summary>
    /// Base class for all <see cref="IFilterDescriptor"/> used for 
    /// handling the logic for property changed notifications.
    /// </summary>
    public class FilterDescriptorBase : IFilterDescriptor
    {
        /// <summary>
        /// Creates a filter expression by delegating its creation to 
        /// <see cref="CreateFilterExpression(System.Linq.Expressions.ParameterExpression)"/>, if 
        /// <paramref name="instance"/> is <see cref="ParameterExpression"/>, otherwise throws <see cref="ArgumentException"/>
        /// </summary>
        /// <param name="instance">The instance expression, which will be used for filtering.</param>
        /// <returns>A predicate filter expression.</returns>
        /// <exception cref="ArgumentException">Parameter should be of type <see cref="ParameterExpression"/></exception>
        public virtual Expression CreateFilterExpression(Expression instance)
        {
            ParameterExpression parameterExpression = instance as ParameterExpression;

            if (parameterExpression == null)
            {
                throw new ArgumentException("Parameter should be of type ParameterExpression", "instance");
            }

            return this.CreateFilterExpression(parameterExpression);
        }

        /// <summary>
        /// Creates a predicate filter expression used for collection filtering.
        /// </summary>
        /// <param name="parameterExpression">The parameter expression, which will be used for filtering.</param>
        /// <returns>A predicate filter expression.</returns>
        protected virtual Expression CreateFilterExpression(ParameterExpression parameterExpression)
        {
            return parameterExpression;
        }

        private ExpressionBuilderOptions options;
        internal ExpressionBuilderOptions ExpressionBuilderOptions
        {
            get
            {
                if (this.options == null)
                {
                    this.options = new ExpressionBuilderOptions();
                }

                return this.options;
            }
        }

    }
}