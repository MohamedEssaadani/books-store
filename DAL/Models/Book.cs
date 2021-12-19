using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAL.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }

        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
