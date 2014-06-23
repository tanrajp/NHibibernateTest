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
    public class PersonTests
    {
        [Test]
        public void Can_Add_Person()
        {
            var Person1 = new Person { Id = 1, fName = "Client", sName = "One" };
            IPersonRepository repo = new PersonRepository();
            repo.Add(Person1);

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var fromDb = session.Get<Person>(Person1.Id);

                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(Person1, fromDb);
                Assert.AreEqual(Person1.fName, fromDb.fName);
                Assert.AreEqual(Person1.sName, fromDb.sName);
            }
        }
    }
}
