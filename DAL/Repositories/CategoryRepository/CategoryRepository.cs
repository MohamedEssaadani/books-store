using BooksStore.DAL.Models;
using BooksStore.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAL.Repositories.CategoryRepository
{
    internal class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(BookStoreDb context) : base(context)
        {
        }
    }
}
