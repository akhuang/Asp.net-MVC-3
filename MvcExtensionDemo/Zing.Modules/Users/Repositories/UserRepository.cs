using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Modules.Users.Models;
using NHibernate;
using Zing.Modules.Data;

namespace Zing.Modules.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserEntity Add(UserEntity model)
        {
            ISessionFactory factory = SessionFactoryHolder.CreateSessionFactory();
            using (ISession session = factory.OpenSession())
            {
                session.SaveOrUpdate(model);
            }
            return model;
        }
    }
}
