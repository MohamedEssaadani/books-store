using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.DAO
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDb(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreDb>>()))
            {
                // Look for any records.
                if (context.Categories.Any())
                {
                  return;   // DB has been seeded
                }

                context.SaveChanges();


                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Autobiography"
                    },
                    new Category
                     {
                         CategoryName = "Romance"
                     },

                    new Category
                     {
                         CategoryName = "Teen & Young Adult"
                     },

                    new Category
                     {
                         CategoryName = "Literary Fiction"
                     },

                    new Category
                      {
                          CategoryName = "Horror"
                      }

                );

                context.SaveChanges();




                context.Authors.AddRange(
                     new Author
                     {
                          AuthorName = "Dr. A.P.J. Abdul Kalam"
                     },
                     new Author
                     {
                         AuthorName = "Lynsay Sands"
                     },
                     new Author
                      {
                          AuthorName = "Garth Nix"
                     },
                      new Author
                       {
                           AuthorName = "Insight Editions"
                      }

                );
                context.SaveChanges();


                context.Books.AddRange(
                    new Book
                    {
                        BookName = "Wings of Fire",
                        Author = context.Authors.SingleOrDefault(x => x.AuthorName == "Dr. A.P.J. Abdul Kalam"),
                        AuthorId = context.Authors.SingleOrDefault(x => x.AuthorName == "Dr. A.P.J. Abdul Kalam").AuthorId,
                        Category = context.Categories.SingleOrDefault(x => x.CategoryName == "Autobiography"),
                        CategoryId = context.Categories.SingleOrDefault(x => x.CategoryName == "Autobiography").CategoryId,
                        Price = 37.33,
                        ReleaseDate = new DateTime(2015, 12, 31),

                    },
                     new Book
                     {
                         BookName = "Mile High with a Vampire [Large Print]",
                         Author = context.Authors.SingleOrDefault(x => x.AuthorName == "Lynsay Sands"),
                         AuthorId = context.Authors.SingleOrDefault(x => x.AuthorName == "Lynsay Sands").AuthorId,
                         Category = context.Categories.SingleOrDefault(x => x.CategoryName == "Romance"),
                         CategoryId = context.Categories.SingleOrDefault(x => x.CategoryName == "Romance").CategoryId,
                         Price = 49,
                         ReleaseDate = new DateTime(1998, 01, 18),

                     },
                      new Book
                      {
                          BookName = "Terciel & Elinor",
                          Author = context.Authors.SingleOrDefault(x => x.AuthorName == "Garth Nix"),
                          AuthorId = context.Authors.SingleOrDefault(x => x.AuthorName == "Garth Nix").AuthorId,
                          Category = context.Categories.SingleOrDefault(x => x.CategoryName == "Literary Fiction"),
                          CategoryId = context.Categories.SingleOrDefault(x => x.CategoryName == "Literary Fiction").CategoryId,
                          Price = 39.12,
                          ReleaseDate = new DateTime(2000, 10, 01),


                      },
                       new Book
                       {
                           BookName = "Harry Potter: Holiday Magic: The Official Advent Calendar",
                           Author = context.Authors.SingleOrDefault(x => x.AuthorName == "Insight Editions"),
                           AuthorId = context.Authors.SingleOrDefault(x => x.AuthorName == "Insight Editions").AuthorId,
                           Category = context.Categories.SingleOrDefault(x => x.CategoryName == "Horror"),
                           CategoryId = context.Categories.SingleOrDefault(x => x.CategoryName == "Horror").CategoryId,
                           Price = 77,
                           ReleaseDate = new DateTime(1995, 02, 18),

                       }
                    );
                context.SaveChanges();
            }
        }
    }
}
