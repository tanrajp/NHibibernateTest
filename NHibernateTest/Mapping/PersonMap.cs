using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateTest.Domain;

namespace NHibernateTest.Mapping
{
    public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            Id(x=>x.Id, m=>m.Generator(Generators.Guid));
            Property(x=>x.fName);
            Property(x=>x.sName);
        }
    }
}
