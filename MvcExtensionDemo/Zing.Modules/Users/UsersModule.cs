using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Zing.Modules.Users.Services;
using Zing.Modules.Users.Repositories;
using Zing.Framework.Security;

namespace Zing.Modules.Users
{
    public class UsersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MembershipService>().As<IMembershipService>();
            builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();
        }
    }
}
