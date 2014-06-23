using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public interface IPersonRepository
    {
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
        Person GetPersonById(Guid personId);
        Person GetPersonByName(string name);
    }
}
