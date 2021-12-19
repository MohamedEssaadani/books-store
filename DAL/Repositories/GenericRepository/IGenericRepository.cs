using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAL.Repositories.GenericRepository
{
    internal interface IGenericRepository<T> where T : class
    {
        public void Add(T obj);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public void Delete(int id);
        public void Update(T obj);
        public void Save();
    }
}
