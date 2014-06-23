using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateTest
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string StreetName { get; set; }
        public virtual string PostCode { get; set; }
        public virtual string City { get; set; }
    }
}
