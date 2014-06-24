using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using NHibernate.Mapping.ByCode;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public class Program
    {
        public static void ReadTable()
        {
            IList<Person> personList = new List<Person>();
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                personList = session.QueryOver<Person>().List<Person>();
            }
            Console.WriteLine("All records in Person Table");
            foreach (var p in (personList))
            {
                Console.Write("First Name: " + p.fName + " Surname: " + p.sName);
                Console.WriteLine(" ");
            }
        }

        

        static void Main(string[] args)
        {
            var sessionFactory = DatabaseConfiguration.SessionFactory();
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            Borough[] boroughArray = new[]
                {
                    new Borough {Name = "borough1"},
                    new Borough {Name = "borough2"},
                    new Borough {Name = "borough3"}
                };

            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                foreach (var borough in boroughArray)
                {
                    session.Save(borough);
                }
                tran.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var updatePerson = boroughArray[1];
                updatePerson.Name = "updated name";
                session.Update(updatePerson);
                tran.Commit();
            }

            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Delete(boroughArray[2]);
                tran.Commit();
            }

            var person1 = new Person {fName = "John", sName = "Smith", borough = boroughArray[0]};

            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(person1);
                tran.Commit();
            }

            var person2 = new Person {fName = "Doctor", sName = "Who", borough = boroughArray[0]};
            using (var session = sessionFactory.OpenSession())
            using(var tran = session.BeginTransaction())
            {
                session.Save(person2);
                tran.Commit();
            }

            var person3 = new Person {fName = "John", sName = "John", borough = boroughArray[1]};
            using (var session = sessionFactory.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(person3);
                tran.Commit();
            }

            IList<Person> list = new List<Person>();
            using (var session = sessionFactory.OpenSession())
            {
                list = session.QueryOver<Person>()
                       .JoinQueryOver(Person => Person.borough)
                       .Where(c=>c.Name =="borough1")
                       .List<Person>();
            }

            Console.WriteLine("All people with the borough -'borough1'");
            foreach (var person in list)
            {
                Console.Write("First Name: "+ person.fName +" Surname: "+ person.sName);
                Console.WriteLine();
            }

            ReadTable();

            Console.WriteLine("Persone with the first name 'Doctor'");
            using (var session = sessionFactory.OpenSession())
            {
                var fromDb =
                            session.CreateCriteria(typeof(Person)).Add(Restrictions.Eq("fName", "Doctor")).UniqueResult<Person>();

                Console.WriteLine(fromDb.fName + " " + fromDb.sName);
            }

            Console.WriteLine("Persone with the first name 'Doctor'");
            using (var session = sessionFactory.OpenSession())
            {
                var fromDb =
                    session.QueryOver<Person>().Where(c => c.fName == "Doctor").SingleOrDefault();

                Console.WriteLine(fromDb.fName + " " + fromDb.sName);
            }

            Console.WriteLine("done!");
            Console.ReadLine();
        }
    }
}
