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
        private Person[] personArray;

        [TestFixtureSetUp]
        public void Set_Up_Database()
        {
            personArray = new[]
                {
                    new Person {fName = "Test1", sName = "One"},
                    new Person {fName = "Test2", sName = "Two"},
                    new Person {fName = "Test3", sName = "Three"}
                };

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            using(var tran = session.BeginTransaction())
            {
                foreach (var person in personArray)
                {
                    session.Save(person);
                }
                tran.Commit();
            }
        }

        [Test]
        public void Can_Add_Person()
        {
            var person = new Person {fName = "Add", sName = "Test" };
            IPersonRepository repo = new PersonRepository();
            repo.Add(person);

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var fromDb = session.Get<Person>(person.Id);

                Assert.IsNotNull(fromDb);
                Assert.AreEqual(person.fName, fromDb.fName);
                Assert.AreEqual(person.sName, fromDb.sName);
            }
        }

        [Test]
        public void Can_Update_Person()
        {
            var person = new Person {fName = "Update", sName = "Test"};
            IPersonRepository repo = new PersonRepository();
            repo.Add(person);

            var newName = "Updated";

            person.fName = newName;

            repo.Update(person);

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var fromdb = session.Get<Person>(person.Id);
                Assert.IsNotNull(fromdb);
                Assert.AreEqual(person.fName, fromdb.fName);
            }
        }

        [Test]
        public void Can_Delete_Person()
        {
            var person = personArray[0];
            IPersonRepository repo = new PersonRepository();
            
            repo.Remove(person);

            using (var session = DatabaseConfiguration.SessionFactory().OpenSession())
            {
                var fromdb = session.Get<Person>(person.Id);
                Assert.IsNull(fromdb);
            }
        }

        [Test]
        public void Can_Get_Person_By_Id()
        {
            IPersonRepository repo = new PersonRepository();

            var fromDb = repo.GetPersonById(personArray[1].Id);

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(personArray[1].fName, fromDb.fName);
            Assert.AreEqual(personArray[1].sName, fromDb.sName);
        }

        [Test]
        public void Can_Get_Person_By_Name()
        {
            IPersonRepository repo = new PersonRepository();
            var fromDb = repo.GetPersonByName("Test3");

            Assert.IsNotNull(fromDb);
            Assert.AreEqual(personArray[2].fName, fromDb.fName);
            Assert.AreEqual(personArray[2].sName, fromDb.sName);
        }

    }
}
