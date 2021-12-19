using BooksStore.DAL.Models;
using BooksStore.DAL.Repositories.GenericRepository;

namespace BooksStore.DAL.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(BookStoreDb context) : base(context)
        {
        }
    }
}
