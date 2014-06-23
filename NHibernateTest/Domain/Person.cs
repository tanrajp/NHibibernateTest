using System;

namespace NHibernateTest.Domain
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string fName { get; set; }
        public virtual string sName { get; set; }
        public virtual Borough borough { get; set; }
    }
}
