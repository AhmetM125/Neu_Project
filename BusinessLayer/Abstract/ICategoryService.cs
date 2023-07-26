using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IRepository<Category>
    {
        List<Category> GetAllBl();
        Category GetById(int id);
        void CategoryDelete(Category category);
        void UpdateCategory(Category category);
    }
}
