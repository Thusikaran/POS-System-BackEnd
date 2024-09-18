﻿using Microsoft.AspNetCore.Mvc;
using POS_System.DB;
using POS_System.Models;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
               return Ok(product);
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.ProductId== id);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            List<Product> products= new List<Product>();
            products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(Product product) 
        {
            _db.Update(product);
            _db.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _db.Products.FirstOrDefault(x => x.ProductId== id);
            _db.Remove(product);
            _db.SaveChanges();
                return Ok(product);
        }


    }
}
