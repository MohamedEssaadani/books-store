using BL.CategoryService;
using BooksStore.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/api/categories")]
        public ActionResult GetCategories()
        {
            IEnumerable<Category> categories = _categoryService.GetAll();
            if (categories == null || !categories.Any())
                return NotFound("Not Categories Found!");

            return Ok(categories);
        }

        [HttpGet("/api/categories/{id}")]
        public ActionResult GetCategory(int id)
        {
            Category category = _categoryService.GetById(id);
            if (category == null)
                return NotFound($"No Category With ID : {id} Found!");
            return Ok(category);
        }

        [HttpPost("/api/categories")]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            _categoryService.Add(category);

            return Ok($"Category : {category.CategoryName} Added Successfully!");
        }

        [HttpDelete("/api/categories/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            Category category = _categoryService.GetById(id);

            if (category != null)
            {
                _categoryService.Delete(id);
                return Ok($"Category with ID = {id} is Deleted Successfully.");
            }
            return NotFound($"No Category With ID : {id} Found!");
        }

        [HttpPut("/api/categories/{id}")]
        public ActionResult UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_categoryService.GetById(id) == null)
                return NotFound($"No Category With ID : {id} Found!");

            var updated = _categoryService.GetById(id);
            updated.CategoryName = category.CategoryName;
            _categoryService.Update(updated);

            return Ok($"Updated Successfully.");
        }
    }
}
