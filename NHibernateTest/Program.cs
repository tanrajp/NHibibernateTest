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
    public class Program
    {

        public static void AddPerson(Person p)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(p);
                tran.Commit();
            }
        }

        public static void DeletePerson(Person p)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Delete(p);
                tran.Commit();
            }
        }

        public static void UpdatePerson(Person p)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Update(p);
                tran.Commit();
            }
        }

        public static void ReadTable()
        {
            IList<Person> personList = new List<Person>();
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                personList = session.QueryOver<Person>().List<Person>();
            }

            foreach (var p in (personList))
            {
                Console.WriteLine(p.fName);
                Console.WriteLine(p.sName);
                Console.WriteLine(" ");
            }
        }

        static void Main(string[] args)
        {
            var Person1 = new Person
                {
                    Id = 1,
                    fName = "Client",
                    sName = "One"
                };

            var Person2 = new Person
                {
                    Id = 2,
                    fName = "Client",
                    sName = "Two"
                };

            var Person3 = new Person
                {
                    Id = 3,
                    fName = "Client",
                    sName = "Three"
                };

            AddPerson(Person1);
            AddPerson(Person2);
            AddPerson(Person3);
            ReadTable();

            DeletePerson(Person1);
            ReadTable();

            var newPerson = new Person
                {
                    Id = 3,
                    fName = "Update",
                    sName= "Three"
                };
            UpdatePerson(newPerson);
            ReadTable();

            Console.ReadLine();
        }
    }
}
