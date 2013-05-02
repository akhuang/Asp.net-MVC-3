using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.Mvc.Expressions
{
    internal class DataRowFieldAccessExpressionBuilder : MemberAccessExpressionBuilderBase
    {
        private readonly Type columnDataType;

        private static readonly MethodInfo DataRowFieldMethod =
            typeof(DataRowExtensions).GetMethod("Field", new[] { typeof(DataRow), typeof(string) });

        public DataRowFieldAccessExpressionBuilder(Type memberType, string memberName)
            : base(typeof(DataRow), memberName)
        {
            //Handle value types for null and DBNull.Value support converting them to Nullable<>
            if (memberType.IsValueType && !memberType.IsNullableType())
            {
                this.columnDataType = typeof(Nullable<>).MakeGenericType(memberType);
            }
            else
            {
                this.columnDataType = memberType;
            }
        }

        public Type ColumnDataType
        {
            get
            {
                return this.columnDataType;
            }
        }

        public override Expression CreateMemberAccessExpression()
        {
            ConstantExpression columnNameExpression = Expression.Constant(this.MemberName);

            MethodCallExpression fieldExtensionMethodExpression =
                Expression.Call(
                    DataRowFieldMethod.MakeGenericMethod(this.columnDataType),
                    this.ParameterExpression,
                    columnNameExpression);

            return fieldExtensionMethodExpression;
        }
    }
}
