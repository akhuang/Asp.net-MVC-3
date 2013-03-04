using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Zing.Modules.Users.Models;

namespace Zing.Modules.Data
{
    public class SessionFactoryHolder
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection")))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserEntityMap>())
              .BuildSessionFactory();
        }
    }
}
