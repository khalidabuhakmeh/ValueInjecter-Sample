using System;

namespace ValueInjector.Models
{
    public class Person : IAudit<Person>
    {
        public Person() {
            Address = new Address();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public Address Address { get; set; }

        public string Hobby { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
    }
}