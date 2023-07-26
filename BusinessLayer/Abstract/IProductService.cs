using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IRepository<Product>
    {
        List<Product> GetAllBl();
        Product GetById(int id);
        void ProductDelete(Product product);
        void UpdateProduct(Product product);

    }
}
