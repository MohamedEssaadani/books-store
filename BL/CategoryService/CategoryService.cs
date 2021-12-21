using BooksStore.DAL.Models;
using BooksStore.DAL.Repositories.CategoryRepository;
using BooksStore.DAL.Repositories.GenericRepository;

namespace BL.CategoryService
{
    public class CategoryService : ICategoryService
    {
        //private IGenericRepository<Category> _repository;
        private CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;   
        }

        public void Add(Category category)
        {
            _repository.Add(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }
    }
}
