using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class ProductManager : Repository<Product>, IProductService
    {
        public  void ChangeCategoryNameOfProduct(Product product)
        {
            product.CategoryId = 4;
            base.Update(product);
        }

		public void DecreaseQuantity(int Quantity, int ProductId)
		{
            Product p = GetById(ProductId);
            p.Quantity = p.Quantity - Quantity;
            base.Update(p);
		}

		public List<Product> GetAllBl()
        {
            return base.List();
        }

        public Product GetById(int id)
        {
            return base.Get(x => x.ProductId == id);
        }

        public int GetQuantity(int Pid)
        {
            using (NEUContext context = new NEUContext())
            {
                return context.Products.Where(x => x.ProductId == Pid).Select(x => x.Quantity).FirstOrDefault();
            }
        }

		public void IncreaseQuantity(int Quantity, int ProducId)
		{
            Product p = GetById(ProducId);
            p.Quantity = p.Quantity - Quantity;
            base.Update(p);
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