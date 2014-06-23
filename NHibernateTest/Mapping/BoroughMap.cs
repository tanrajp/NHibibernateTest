using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernateTest.Domain;

namespace NHibernateTest.Mapping
{
    public class BoroughMap : ClassMapping<Borough>
    {
        public BoroughMap()
        {
            Id(x=>x.Id, m=> m.Generator(Generators.Guid));
            Property(x=>x.Name);
        }
    }
}
