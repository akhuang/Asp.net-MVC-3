using MvcExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Zing.Modules.Data;
using FluentNHibernate.Mapping;

namespace Zing.Modules.Users.Models
{
    public class UserEntity : EntityBase
    {
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string NormalizedUserName { get; set; }

        public virtual string Password { get; set; }
        public virtual MembershipPasswordFormat PasswordFormat { get; set; }
        public virtual string HashAlgorithm { get; set; }
        public virtual string PasswordSalt { get; set; }

        public virtual UserStatus RegistrationStatus { get; set; }
        public virtual UserStatus EmailStatus { get; set; }
        public virtual string EmailChallengeToken { get; set; }
    }

    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Table("Users");
        }
    }
}
