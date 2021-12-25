using BooksStore.DAO;

namespace BooksStore.DAO
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(BookStoreDb context) : base(context)
        {
        }
    }
}
