using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace POS_System.Models

{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }   //one-to-many
    }
}
