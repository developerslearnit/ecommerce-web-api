using Ecommerce.Data;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();

        bool AddCategory(CategoryViewModel category);

        bool UpdateCategory(CategoryViewModel category, int id);
    }
}
