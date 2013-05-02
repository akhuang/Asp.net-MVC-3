using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Zing.Framework.Utility.Extensions;

namespace Zing.Framework.Mvc.Expressions
{
    internal class IndexerToken : IMemberAccessToken
    {
        private readonly ReadOnlyCollection<object> arguments;

        public IndexerToken(IEnumerable<object> arguments)
        {
            this.arguments = arguments.ToReadOnlyCollection();
        }

        public IndexerToken(params object[] arguments)
            : this((IEnumerable<object>)arguments)
        {
        }

        public ReadOnlyCollection<object> Arguments
        {
            get
            {
                return this.arguments;
            }
        }
    }
}
