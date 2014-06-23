using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest.Domain
{
    public class Borough
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
