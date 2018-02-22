using Ecommerce.Common;
using Ecommerce.Data;
using Ecommerce.Interfaces;
using Ecommerce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class CategoryRepository : BaseRepository<EcommerceEntities>, ICategoryRepository
    {
        public bool AddCategory(CategoryViewModel category)
        {
            var cat = new Category()
            {
                CategotyName = category.name,
                Datecreated =DateTime.Now,
                slug = CommonHelpers.GenerateSlug(category.name),
                Description =category.description               
            };
            DataContext.Categories.Add(cat);

            return DataContext.SaveChanges() > 0;
        }

        public IQueryable<Category> GetCategories()
        {
            return DataContext.Categories;
        }

        public bool UpdateCategory(CategoryViewModel category, int id)
        {
            bool result = false;
            try
            {
                var targetCat = DataContext.Categories.Find(id);
                if (targetCat != null)
                {
                    targetCat.CategotyName = category.name;
                    targetCat.Description = category.description;
                    targetCat.slug = CommonHelpers.GenerateSlug(category.name);
                    DataContext.SaveChanges();
                    result= true;
                }
                result= false;
               
            }
            catch (Exception)
            {
                throw;                
            }

            return result;
     
        }
    }
}
