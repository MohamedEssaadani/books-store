using BooksStore.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAO
{
    public class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository(BookStoreDb context) : base(context)
        {
        }
    }
}
