using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public interface IDescriptor
    {
        void Deserialize(string source);
        string Serialize();
    }
}
