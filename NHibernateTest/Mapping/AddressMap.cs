using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateTest.Domain;

namespace NHibernateTest.Mapping
{
    public class AddressMap: ClassMapping<Address>
    {
        public AddressMap()
        {
            Id(x=>x.Id, m=>m.Generator(Generators.Guid));
            Property(x=>x.HouseNumber);
            Property(x=>x.StreetName);
            Property(x=>x.PostCode);
            Property(x=>x.City);
        }
    }
}
