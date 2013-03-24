using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Security
{
    public interface IMembershipService
    {
        MembershipSettings GetSettings();

        IUser CreateUser(CreateUserParams createUserParams);
        IUser GetUser(string userName);

        IUser ValidateUser(string userNameOrEmail, string password);
        void SetPassword(IUser user, string password);
    }
}
