using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateTest
{
    public class AddressMap: ClassMapping<Address>
    {
        public AddressMap()
        {
            Id(x=>x.Id, m=>m.Generator(Generators.Assigned));
            Property(x=>x.HouseNumber);
            Property(x=>x.StreetName);
            Property(x=>x.PostCode);
            Property(x=>x.City);
        }
    }
}
