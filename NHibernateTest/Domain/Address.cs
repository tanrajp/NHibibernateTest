namespace NHibernateTest.Domain
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
