using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_System.DB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POSController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public POSController(ApplicationDbContext db)
        {
            _db = db;
        }


        // get productid and quantity
        [HttpPost]
        [Route("orderProducts")]
        public async Task<IActionResult> CalculateTotal([FromBody] List<OrderProductDto> orderItems)
        {
            if (orderItems == null || !orderItems.Any())
            {
                return BadRequest("required order products");
            }

            decimal total = 0;

            //  get all productids in list
            var productIds = orderItems.Select(item => item.ProductId).Distinct().ToList();

            // fetch the products using projectid
            var products = await _db.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound("products not found.");
            }

            // Create a dictionary 
            var dictionary = products.ToDictionary(p => p.ProductId);

            foreach (var item in orderItems)
            {
                if (dictionary.TryGetValue(item.ProductId, out var product))
                {
                    if (item.Quantity > product.Quantity)
                    {
                        return BadRequest($"Insufficient quantity for product ID {item.ProductId}. Available: {product.Quantity}, Requested: {item.Quantity}");
                    }

                    //calculate total
                    total += item.Quantity * product.Price;

                    // Update quantity
                    product.Quantity -= item.Quantity;
                }
                else
                {
                    return NotFound($"Product ID {item.ProductId} not found.");
                }
            }

            // Save changes to the database after processing all items
            await _db.SaveChangesAsync();

            // Return the total price as a response
            return Ok(new { TotalPrice = total });
        }

        public class OrderProductDto
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
