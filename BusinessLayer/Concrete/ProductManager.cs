using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ProductManager : Repository<Product>, IProductService
    {
        public  void ChangeCategoryNameOfProduct(Product product)
        {
            product.CategoryId = 4;
            base.Update(product);
        }
        public List<Product> GetAllBl()
        {
            return base.List();
        }

        public Product GetById(int id)
        {
            return base.Get(x => x.ProductId == id);
        }

        public void ProductDelete(Product product)
        {
            base.Delete(product);
        }

        public void UpdateProduct(Product product)
        {
            base.Update(product);
        }
    }
}