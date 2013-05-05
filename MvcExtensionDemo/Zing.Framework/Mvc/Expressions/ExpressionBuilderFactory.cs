// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.Mvc.Expressions
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Xml;
    using Zing.Framework.Utility.Extensions;

    internal static class ExpressionBuilderFactory
    {
        public static MemberAccessExpressionBuilderBase MemberAccess(Type elementType, Type memberType, string memberName)
        {
            memberType = memberType ?? typeof(object);

            if (elementType.IsCompatibleWith(typeof(DataRow)))
            {
                return new DataRowFieldAccessExpressionBuilder(memberType, memberName);
            }

            if (elementType.IsCompatibleWith(typeof(ICustomTypeDescriptor)))
            {
                return new CustomTypeDescriptorPropertyAccessExpressionBuilder(elementType, memberType, memberName);
            }

            if (elementType.IsCompatibleWith(typeof(XmlNode)))
            {
                return new XmlNodeChildElementAccessExpressionBuilder(memberName);
            }

            if (elementType == typeof(object) || elementType.IsCompatibleWith(typeof(System.Dynamic.IDynamicMetaObjectProvider)))
            {
                return new DynamicPropertyAccessExpressionBuilder(elementType, memberName);
            }

            return new PropertyAccessExpressionBuilder(elementType, memberName);
        }

        public static MemberAccessExpressionBuilderBase MemberAccess(Type elementType, string memberName, bool liftMemberAccess)
        {
            var builder = MemberAccess(elementType, null, memberName);

            builder.Options.LiftMemberAccessToNull = liftMemberAccess;

            return builder;
        }

        public static MemberAccessExpressionBuilderBase MemberAccess(Type elementType, Type memberType, string memberName, bool liftMemberAccess)
        {
            var builder = MemberAccess(elementType, memberType, memberName);

            builder.Options.LiftMemberAccessToNull = liftMemberAccess;

            return builder;
        }
        public static MemberAccessExpressionBuilderBase MemberAccess(IQueryable source, Type memberType, string memberName)
        {
            var builder = MemberAccess(source.ElementType, memberType, memberName);
            builder.Options.LiftMemberAccessToNull = source.Provider.IsLinqToObjectsProvider();

            return builder;
        }
    }
}