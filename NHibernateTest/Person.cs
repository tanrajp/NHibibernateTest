using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernateTest
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string fName { get; set; }
        public virtual string sName { get; set; }
    }
}
