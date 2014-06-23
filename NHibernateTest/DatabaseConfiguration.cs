using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernateTest.Domain;
using NHibernateTest.Mapping;

namespace NHibernateTest
{
    public class DatabaseConfiguration
    {
        private static Configuration ConfigureNhibernate()
        {
            var nhConfig = new Configuration()
                .Proxy(proxy =>proxy.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
                    .DataBaseIntegration(db =>
                        {
                            db.Dialect<MsSql2008Dialect>();
                            db.ConnectionStringName = "db";
                        })
                        .AddAssembly(typeof(Person).Assembly);

                var mapper = new ModelMapper();
                mapper.AddMapping<PersonMap>();
                mapper.AddMapping<AddressMap>();

                var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                nhConfig.AddMapping(mapping);

            return nhConfig;
        }

        public static ISessionFactory SessionFactory()
        {
            return ConfigureNhibernate().BuildSessionFactory();
        }
    }
}
