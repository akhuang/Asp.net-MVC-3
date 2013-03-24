using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Security
{
    public interface IUser
    {
        int Id { get; }
        string UserName { get; }
        string Email { get; }
    }
}
