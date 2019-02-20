using System;

namespace GenericControllerRepository.Models
{
    public class Order : BaseModel
    {
	    public string CustomerID { get; set; }
	    public string EmployeeID { get; set; }
	    public DateTime OrderDate { get; set; }
	    public DateTime ShippedDate { get; set; }
	    public decimal ShippingCost { get; set; }
	    public Company Shipper { get; set; }
    }
}