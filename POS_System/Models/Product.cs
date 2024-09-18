using System.ComponentModel.DataAnnotations;

namespace POS_System.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string?   ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
