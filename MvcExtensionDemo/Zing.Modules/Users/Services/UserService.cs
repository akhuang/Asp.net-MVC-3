using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Modules.Users.Models;
using Zing.Modules.Users.Repositories;

namespace Zing.Modules.Users.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRep;
        public UserService(IUserRepository userRep)
        {
            _userRep = userRep;
        }

        public UserEntity Add(UserEntity model)
        {
            return _userRep.Add(model);
        }
    }
}
