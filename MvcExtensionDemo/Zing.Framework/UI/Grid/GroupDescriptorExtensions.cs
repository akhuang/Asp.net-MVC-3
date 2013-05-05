// (c) Copyright 2002-2009 Telerik 
// This source is subject to the GNU General Public License, version 2
// See http://www.gnu.org/licenses/gpl-2.0.html. 
// All other rights reserved.

namespace Zing.Framework.UI
{
    using System.Collections.Generic;
    using Zing.Framework.Mvc;
    using Zing.Framework.Utility.Extensions;

    internal static class GroupDescriptorExtensions
    {
        private static void SetMemberTypeFrom(this GroupDescriptor descriptor, object item)
        {
            if (!descriptor.Member.HasValue())
                return;

            descriptor.MemberType = BindingHelper.ExtractMemberTypeFromObject(item, descriptor.Member);
        }

        internal static IEnumerable<GroupDescriptor> SetMemberTypeFrom(this IEnumerable<GroupDescriptor> descriptors, object item)
        {
            if (item != null)
            {
                descriptors.Each(g => g.SetMemberTypeFrom(item));
            }

            return descriptors;
        }
    }
}
