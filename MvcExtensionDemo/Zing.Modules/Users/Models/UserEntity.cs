using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Zing.Framework.Data;
using FluentNHibernate.Mapping;
using Zing.Framework.Security;

namespace Zing.Modules.Users.Models
{
    public class UserEntity : IUser
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

        public virtual int Id
        {
            get;
            set;
        }
    }

    public class UserEntityMap : ClassMap<UserEntity>
    {
        public UserEntityMap()
        {
            Id(x => x.Id);

            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.NormalizedUserName);
            Map(x => x.PasswordFormat);
            Map(x => x.HashAlgorithm);
            Map(x => x.PasswordSalt);
            Map(x => x.RegistrationStatus);
            Map(x => x.EmailStatus);
            Map(x => x.Email);

            Table("Users");
        }
    }
}
