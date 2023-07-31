using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class ProductSaleManager : Repository<SaleProduct>, IProductSaleService
	{
		public int GenerateTransactionNumber()
		{
			int TotalSale = base.Count();
			string Date = DateTime.Today.ToString("ddMMyyyy");
			Date += TotalSale.ToString();
			return Convert.ToInt32(Date);
		}

		public List<SaleProduct> GetAllBl()
		{
			return base.List();
		}

		public List<SaleProduct> GetList(int id)
		{
			return base.List(x => x.User.Id == id);
		}

		public List<SaleProduct> GetList()
		{
			throw new System.NotImplementedException();
		}

		public void ProductSaleInsert(SaleProduct product)
		{
			base.Insert(product);
		}
	}
}
