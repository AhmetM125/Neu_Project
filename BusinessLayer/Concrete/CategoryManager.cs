using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : Repository<Category>, ICategoryService
    {
        public List<Category> GetAllBl()
        {
            return base.List();
        }

        public void CategoryAddBl(Category p)
        {
            base.Insert(p);
        }
        public Category GetById(int id)
        {
            return base.Get(x => x.CategoryId == id);
        }

        public void CategoryDelete(Category category)
        {
            base.Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            base.Update(category);
        }
    }
}
