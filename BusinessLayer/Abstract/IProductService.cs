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
		void ChangeCategoryNameOfProduct(Product product);
		void DecreaseQuantity(int Quantity, int ProductId);

		int GetQuantity(int Pid);
		void IncreaseQuantity(int Quantity, int ProducId);

	}
}
