namespace POS_System.Models
{
    public class Order
    {
        public List<OrderProducts> Products { get; set; } = new List<OrderProducts>();
    }
}
