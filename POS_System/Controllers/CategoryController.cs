using Microsoft.AspNetCore.Mvc;
using POS_System.DB;
using POS_System.Models;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // create category 
        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            _db.Add(category);
            _db.SaveChanges();
            return Ok(category);
        }

        // get a category using Id
        [HttpGet]
        [Route("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _db.Categories.FirstOrDefault(x => x.CategoryId == id);
            return Ok(category);
        }

        // get all Category
        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategory()
        {
            List<Category>categories = new List<Category>();
            categories = _db.Categories.ToList();
            return Ok(categories);
        }

        //update category
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            _db.Update(category);
            _db.SaveChanges();
                return Ok(category);
        }

        // delete category
        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _db.Categories.FirstOrDefault(x => x.CategoryId== id);
            _db.Remove(category);
            _db.SaveChanges();
            return Ok(category);
        }
    }
}
