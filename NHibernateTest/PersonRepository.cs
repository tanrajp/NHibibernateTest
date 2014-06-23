using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateTest.Domain;
using NUnit.Framework;

namespace NHibernateTest
{
    public class PersonRepository:IPersonRepository
    {
        public void Add(Domain.Person person)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(person);
                tran.Commit();
            }

        }

        public void Update(Domain.Person person)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Person person)
        {
            throw new NotImplementedException();
        }

        public Domain.Person GetPersonById(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Domain.Person GetPersonByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
