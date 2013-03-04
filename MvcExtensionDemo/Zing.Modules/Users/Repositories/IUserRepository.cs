using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Modules.Users.Models;

namespace Zing.Modules.Users.Repositories
{
    public interface IUserRepository
    {
        UserEntity Add(UserEntity model);
    }
}
