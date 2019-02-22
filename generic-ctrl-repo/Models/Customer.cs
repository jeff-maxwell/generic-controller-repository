namespace GenericControllerRepository.Models
{
    public class Customer : People
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
    }
}