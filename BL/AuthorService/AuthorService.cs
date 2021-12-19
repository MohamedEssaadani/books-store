using BooksStore.DAL.Models;
using BooksStore.DAL.Repositories.AuthorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private AuthorRepository _repository;

        public AuthorService(AuthorRepository repository)
        {
            _repository = repository;
        }

        public void Add(Author category)
        {
            _repository.Add(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public Author GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Author author)
        {
            _repository.Update(author);
        }
    }
}
