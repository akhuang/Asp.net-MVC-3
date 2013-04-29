using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Modules.Users.Models;
using NHibernate;
using Zing.Framework.Data;
using Zing.Framework.Security;

namespace Zing.Modules.Users.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        public IUser Add(IUser model)
        {
            ISessionFactory factory = SessionFactoryHolder.CreateSessionFactory();
            using (ISession session = factory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(model);

                    transaction.Commit();
                }
            }
            return model;
        }

    }
}
