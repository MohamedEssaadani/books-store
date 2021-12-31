using BooksStore.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAO
{
    public class BookStoreDb : DbContext
    {
        public BookStoreDb(DbContextOptions<BookStoreDb> options) : base(options)
        {
           Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
