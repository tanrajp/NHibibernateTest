using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public interface IAddressRepository
    {
        void Add(Address address);
        void Update(Address address);
        void Remove(Address address);
        Address GetAddressById(Guid addressId);
        Address GetAddressByStreetName(string name);
        Address GetAddressForPerson(Person person);

    }
}
