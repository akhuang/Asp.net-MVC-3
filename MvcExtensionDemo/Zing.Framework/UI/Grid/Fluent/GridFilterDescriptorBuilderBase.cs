// (c) Copyright 2002-2010 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI.Fluent
{
    using System;

    using Zing.Framework.Mvc;
    using Zing.Framework.Mvc;
    using Zing.Framework.Utility;

    public abstract class GridFilterDescriptorBuilderBase : IHideObjectMembers
    {
        protected GridFilterDescriptorBuilderBase(CompositeFilterDescriptor descriptor)
        {
            Guard.IsNotNull(descriptor, "descriptor");

            Descriptor = descriptor;
        }

        protected CompositeFilterDescriptor Descriptor { get; private set; }

        protected virtual void SetOperatorAndValue(FilterOperator filterOperator, object value)
        {
            FilterDescriptor descriptor = Descriptor.FilterDescriptors[Descriptor.FilterDescriptors.Count - 1] as FilterDescriptor;

            if (descriptor == null)
            {
                throw new InvalidCastException();
            }

            descriptor.Operator = filterOperator;
            descriptor.Value = value;
        }
    }
}