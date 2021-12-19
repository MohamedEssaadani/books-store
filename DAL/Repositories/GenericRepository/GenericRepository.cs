using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.DAL.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreDb _context;
        private DbSet<T> table;
        public GenericRepository(BookStoreDb context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public void Add(T obj)
        {
            table.Add(obj);
        }

        public T GetById(int id)
        {
            var result = table.Find(id);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void Delete(int id)
        {
            var result = table.Find(id);
            _context.Remove(result);
        }

        public void Update(T obj)
        {
            _context.Update(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    
}
}
