using MvcExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.Modules.Users
{
    public class UserEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserMetadata : ModelMetadataConfiguration<UserEntity>
    {
        public UserMetadata()
        {
            Configure(x => x.UserId)
                .DisplayName("用户登录名")
                .Required();

            Configure(x => x.UserName)
                .DisplayName("用户姓名")
                .Required();

            Configure(x => x.UserPassword)
                .DisplayName("密码")
                .AsPassword();
        }
    }
}
