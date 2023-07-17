using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		//	private readonly GenericRepository<Product> repo = new GenericRepository<Product>();

		readonly	IProductDal _productdal;

		//Constructor
		public ProductManager(IProductDal productdal)
		{
			_productdal = productdal;
		}

		

		public List<Product> GetAllBl()
		{
			return _productdal.List();
		}

		public void ProductAddBl(Product p)
		{
			if (false)
			{
			}
			else
			{
				_productdal.Insert(p);
				/*repo.Insert(p);*/
			}
		}
	}
}