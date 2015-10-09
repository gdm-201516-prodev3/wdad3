using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int categoryId);
        Category AddCategory(Category category);
        bool DeleteCategory(int categoryId);
    }
}
