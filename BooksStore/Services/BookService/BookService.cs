
using BooksStore.DAO;

namespace BooksStore.Services
{
    public class BookService: IBookService
    {
        private BookRepository _repository;

        public BookService(BookRepository repository)
        {
            _repository = repository;
        }

        public void Add(Book category)
        {
            _repository.Add(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Book book)
        {
            _repository.Update(book);
        }
    }
}
