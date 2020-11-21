

namespace WebApplication2.Models
{
    public class OrderDetails
    {
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public double PriceEach{ get; set; }
        public string OrderLineNumber { get; set; }

    }
}