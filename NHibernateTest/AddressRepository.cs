using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest
{
    public class AddressRepository : IAddressRepository
    {
        public void Add(Domain.Address address)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Address address)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Address address)
        {
            throw new NotImplementedException();
        }

        public Domain.Address GetAddressById(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Domain.Address GetAddressByStreetName(string name)
        {
            throw new NotImplementedException();
        }

        public Domain.Address GetAddressForPerson(Domain.Person person)
        {
            throw new NotImplementedException();
        }
    }
}
