using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public class AddressRepository : IAddressRepository
    {
        public void Add(Address address)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Save(address);
                tran.Commit();
            }
        }

        public void Update(Address address)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Update(address);
                tran.Commit();
            }
        }

        public void Remove(Address address)
        {
            using(var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using (var tran = session.BeginTransaction())
            {
                session.Delete(address);
                tran.Commit();
            }
        }

        public Address GetAddressById(Guid addressId)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                return session.Get<Address>(addressId);
            }
        }

        public Address GetAddressByStreetName(string name)
        {
            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var address =
                    session.CreateCriteria(typeof(Address)).Add(Restrictions.Eq("StreetName", name)).UniqueResult<Address>();

                return address;
            }
        }

        public Address GetAddressForPerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
