using BooksStore.DAL.Models;
using BooksStore.DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAL.Repositories.AuthorRepository
{
    internal class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository(BookStoreDb context) : base(context)
        {
        }
    }
}
