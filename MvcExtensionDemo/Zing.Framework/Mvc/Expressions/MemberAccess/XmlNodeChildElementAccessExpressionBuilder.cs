using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Zing.Framework.Mvc.Expressions
{

    internal class XmlNodeChildElementAccessExpressionBuilder : MemberAccessExpressionBuilderBase
    {
        private static readonly MethodInfo ChildElementInnerTextMethod =
            typeof(XmlNodeExtensions).GetMethod("ChildElementInnerText", new[] { typeof(XmlNode), typeof(string) });

        public XmlNodeChildElementAccessExpressionBuilder(string memberName)
            : base(typeof(XmlNode), memberName)
        {
        }

        public override Expression CreateMemberAccessExpression()
        {
            ConstantExpression childNameExpression = Expression.Constant(this.MemberName);

            MethodCallExpression childElementInnterTextExtensionMethodExpression =
                Expression.Call(
                    ChildElementInnerTextMethod,
                    this.ParameterExpression,
                    childNameExpression);

            return childElementInnterTextExtensionMethodExpression;
        }
    }
}
