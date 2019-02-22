namespace GenericControllerRepository.Models
{
    public class Company : BaseModel
    {
	    public string Address { get; set; }
	    public string City { get; set; }
	    public string Region { get; set; }
	    public string PostalCode { get; set; }
	    public string Country { get; set; }
        public string Phone { get; set; }
    }
}