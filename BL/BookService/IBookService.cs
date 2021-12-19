using BooksStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BookService
{
    public interface IBookService : IGenericService<Book>
    {
    }
}
