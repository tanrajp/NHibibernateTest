using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernateTest.Domain;
using NUnit.Framework;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public class PersonRepository:IPersonRepository
    {
        public void Add(Person person)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(person);
                tran.Commit();
            }

        }

        public void Update(Person person)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Update(person);
                tran.Commit();
            }
        }

        public void Remove(Person person)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Delete(person);
                tran.Commit();
            }
        }

        public Person GetPersonById(Guid personId)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                return session.Get<Person>(personId);
            }
        }

        public Person GetPersonByName(string name)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var person =
                    session.CreateCriteria(typeof (Person)).Add(Restrictions.Eq("fName", name)).UniqueResult<Person>();

                return person;
            }
        }
    }
}
