using BooksStore.DAO;
using BooksStore.Services;
using Microsoft.AspNetCore.Mvc;
namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("/api/authors")]
        public ActionResult GetAuthors()
        {
            IEnumerable<Author> authors = _authorService.GetAll();
            if (authors == null || !authors.Any())
                return NotFound("Not Authors Found!");

            return Ok(authors);
        }

        [HttpGet("/api/authors/{id}")]
        public ActionResult GetAuthor(int id)
        {
            Author author = _authorService.GetById(id);
            if (author == null)
                return NotFound($"No Author With ID : {id} Found!");
            return Ok(author);
        }

        [HttpPost("/api/authors")]
        public ActionResult CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            _authorService.Add(author);

            return Ok($"Author : {author.AuthorName} Added Successfully!");
        }

        [HttpDelete("/api/authors/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            Author author = _authorService.GetById(id);

            if (author != null)
            {
                _authorService.Delete(id);
                return Ok($"Author with ID = {id} is Deleted Successfully.");
            }
            return NotFound($"No Author With ID : {id} Found!");
        }

        [HttpPut("/api/authors/{id}")]
        public ActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.AuthorId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_authorService.GetById(id) == null)
                return NotFound($"No Author With ID : {id} Found!");

            var updated = _authorService.GetById(id);
            updated.AuthorName = author.AuthorName;
            _authorService.Update(updated);

            return Ok($"Updated Successfully.");
        }
    }
}
