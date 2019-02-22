using System;

namespace GenericControllerRepository.Models
{
    public class People : BaseModel
    {
        public People()
        {
            Name = $"{FirstName} {LastName}";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }	
    }
}