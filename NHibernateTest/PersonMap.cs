using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateTest
{
    public class PersonMap : ClassMapping<Person>
    {
        public PersonMap()
        {
            Id(x=>x.Id);
            Property(x=>x.fName);
            Property(x=>x.sName);
        }
    }
}
