using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.Repositories;

namespace Zing.Modules.Users
{
    public class UsersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
