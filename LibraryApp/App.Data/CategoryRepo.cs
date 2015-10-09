using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly LibraryDbContext _db;

        public CategoryRepo(LibraryDbContext db)
        {
            _db = db;
        }

        public Category AddCategory(Category category)
        {
            _db.Categories.Add(category);

            if (_db.SaveChanges() > 0)
            {
                return category;
            }
            return null;
        }

        public bool DeleteCategory(int categoryId)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _db.Categories.Remove(category);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.AsEnumerable();
        }

        public Category GetCategory(int categoryId)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == categoryId);
        }
    }
}
