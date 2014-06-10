using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using NHibernate.Mapping.ByCode;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhConfig = new Configuration()
                .Proxy(proxy =>
                       proxy.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
                .DataBaseIntegration(db =>
                    {
                        db.Dialect<MsSql2008Dialect>();
                        //db.ConnectionString = @"Server=localhost;initial catalog=Test;User Id=sa;Password=cleanAdmin01";
                        db.ConnectionStringName = "db";
                    }).AddAssembly(typeof (Person).Assembly);
                //.AddAssembly((typeof (Person).Assembly));
                //.AddAssembly("NHibernateTest");

            var mapper = new ModelMapper();
            mapper.AddMapping<PersonMap>();

            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            nhConfig.AddMapping(mapping);

            var sessionFactory = nhConfig.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using(var tran = session.BeginTransaction())
            {
                var person = new Person
                    {
                        fName = "Test",
                        sName = "Test"
                    };
                session.Save(person);
                tran.Commit();
            }

            Console.WriteLine(("hello"));

            Console.ReadLine();
        }
    }
}
