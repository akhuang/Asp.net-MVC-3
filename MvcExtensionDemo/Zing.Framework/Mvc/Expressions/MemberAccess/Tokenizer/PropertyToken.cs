using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Mvc.Expressions
{
    internal class PropertyToken : IMemberAccessToken
    {
        private readonly string propertyName;

        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }

        public PropertyToken(string propertyName)
        {
            this.propertyName = propertyName;
        }
    }
}
