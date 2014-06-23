using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateTest.Domain;
using NUnit.Framework;

namespace NHibernateTest.Tests
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        public void Can_Add_Address()
        {
            var address = new Address {HouseNumber = "67", StreetName = "Jubilee Close", City = "London",PostCode = "HA1 1BS"};
            IAddressRepository repo = new AddressRepository();

            repo.Add(address);

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var fromDb = session.Get<Address>(address.Id);

                Assert.IsNotNull(fromDb);
                Assert.AreEqual(address.HouseNumber, fromDb.HouseNumber);
                Assert.AreEqual(address.StreetName, fromDb.StreetName);
                Assert.AreEqual(address.City, fromDb.City);
                Assert.AreEqual(address.PostCode, fromDb.PostCode);
            }
        }

        [Test]
        public void Can_Update_Address()
        {
            
        }

        [Test]
        public void Can_Remove_Address()
        {
            
        }

        [Test]
        public void Can_GetAddress_By_Id()
        {
            
        }

        [Test]
        public void Can_GetAddress_By_Street()
        {
            
        }

        [Test]
        public void Can_Get_Address_For_Person()
        {
            
        }
    }
}
