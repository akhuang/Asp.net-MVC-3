using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.UI
{
    public interface IClientSerializable
    {
        void SerializeTo(string key, IClientSideObjectWriter writer);
    }
}
