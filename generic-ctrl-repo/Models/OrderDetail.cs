namespace GenericControllerRepository.Models
{
    public class OrderDetail : BaseModel
    {
        public string OrderID { get; set; }
	    public string ProductID { get; set; }
	    public decimal UnitPrice { get; set; }
	    public int Quantity { get; set; }
	    public decimal Discount { get; set; }
    }
}