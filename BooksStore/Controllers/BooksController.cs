using BooksStore.DAO;
using BooksStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = _bookService.GetAll();
           // if (books == null || !books.Any())
             //   return null;

            return books.ToArray();
        }

        [HttpGet("/{id}")]
        public ActionResult GetBook(int id)
        {
            Book book = _bookService.GetById(id);
            if (book == null)
                return NotFound($"No Book With ID : {id} Found!");
            return Ok(book);
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model State is Not Valid!!");

            _bookService.Add(book);

            return Ok($"Book : {book.BookName} Added Successfully!");
        }

        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            Book book = _bookService.GetById(id);

            if (book != null)
            {
                _bookService.Delete(id);
                return Ok($"Book with ID = {id} is Deleted Successfully.");
            }
            return NotFound($"No Book With ID : {id} Found!");
        }

        [HttpPut]
        public ActionResult UpdateBook(int id, Book book)
        {
            if (id != book.CategoryId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_bookService.GetById(id) == null)
                return NotFound($"No Book With ID : {id} Found!");

            var updated = _bookService.GetById(id);
            updated.BookName = book.BookName;
            updated.CategoryId = book.CategoryId;
            updated.Category = book.Category;
            updated.AuthorId = book.AuthorId;
            updated.Author = book.Author;
            updated.Price = book.Price;

            _bookService.Update(updated);

            return Ok($"Updated Successfully.");
        }
    }
}
