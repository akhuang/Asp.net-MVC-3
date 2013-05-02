using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcExtensions;


namespace Zing.Modules.Users.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserViewModelMetadata : ModelMetadataConfiguration<UserViewModel>
    {
        public UserViewModelMetadata()
        {
            Configure(x => x.UserName)
                .DisplayName("用户姓名")
                .Required();

            Configure(x => x.Email)
                .DisplayName("Email")
                .AsEmail()
                .Required();

            Configure(x => x.NormalizedUserName)
                .DisplayName("用户登录名")
                .MaximumLength(50)
                .MinimumLength(7);

            Configure(x => x.UserPassword)
                .DisplayName("密码")
                .AsPassword()
                .MaximumLength(50)
                .MinimumLength(7);

            Configure(x => x.ConfirmPassword)
                .DisplayName("确认密码")
                .AsPassword()
                .Compare("UserPassword");
        }
    }
}
