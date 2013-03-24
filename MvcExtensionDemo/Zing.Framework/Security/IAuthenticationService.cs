using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Framework.Security
{
    public interface IAuthenticationService  
    {
        void SignIn(IUser user, bool createPersistentCookie);
        void SignOut();
        void SetAuthenticatedUserForRequest(IUser user);
        IUser GetAuthenticatedUser();
    }
}
