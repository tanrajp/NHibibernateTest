using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Cfg.Loquacious;
using NHibernate.Mapping.ByCode;
using NHibernateTest.Domain;

namespace NHibernateTest
{
    public class Program
    {
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
            IPersonRepository repo = new PersonRepository();
            var person1 = new Person {fName = "Test1", sName = "One"};
            var person2 = new Person {fName = "Test2", sName = "Two"};
            var person3 = new Person {fName = "Test3", sName = "Three"};

            repo.Add(person1);
            repo.Add(person2);
            repo.Add(person3);

            person2.fName = "newName";
            repo.Update(person2);

            repo.Remove(person3);

            IAddressRepository addressRepo = new AddressRepository();
            var address1 = new Address {HouseNumber = "01", StreetName = "StreetName1",City = "London", PostCode = "AA1 1AA"};
            var address2 = new Address { HouseNumber = "02", StreetName = "StreetName2", City = "London", PostCode = "AA2 2AA" };
            var address3 = new Address { HouseNumber = "03", StreetName = "StreetName3", City = "London", PostCode = "AA3 3AA" };

            addressRepo.Add(address1);
            addressRepo.Add(address2);
            addressRepo.Add(address3);

            address2.StreetName = "Updated Street";
            addressRepo.Update(address2);
            
            addressRepo.Remove(address3);


            ReadTable();
            Console.WriteLine("done!");
            Console.ReadLine();
        }
    }
}
