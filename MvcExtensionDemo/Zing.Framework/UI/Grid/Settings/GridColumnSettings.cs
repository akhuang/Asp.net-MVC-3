using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.UI
{
    public class GridColumnSettings
    {
        private string member;
        public string Member
        {
            get
            {
                return member;
            }
            set
            {
                member = value;

                if (!Title.HasValue())
                {
                    Title = member.AsTitle();
                }
            }
        }
        public Type MemberType
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
    }
}
