using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
	public class ProductSaleManager : Repository<Sale>, IProductSaleService
	{
		public int GenerateTransactionNumber()
		{
			int TotalSale = base.Count();
			string Date = DateTime.Today.ToString("ddMMyyyy");
			Date += TotalSale.ToString();
			return Convert.ToInt32(Date);
		}

		public List<Sale> GetAllBl()
		{
			return base.List();
		}






		public List<Sale> GetList(int id)
		{
			return base.List(x => x.User.UserId == id);
		}

		public List<Sale> GetList()
		{
			throw new System.NotImplementedException();
		}

		public void PaymentProcess(Sale sale, int Uid)
		{
			sale.TransactionNo = GenerateTransactionNumber();
			sale.SaleDate = DateTime.Today;

			var saleItems = NEUComponent.Instance.ChartService.GetAllBl(sale.UserId)
			.Where(x => x.UserId == sale.UserId)
			.ToList();

			/*var values = from x in NEUComponent.Instance.ChartService.GetAllBl(sale.UserId)
						 where x.UserId == sale.UserId
						 select new
						 {
							 ProductID = x.ProductId,
							 Quantity = x.Quantity
						 };*/

			foreach (var x in saleItems)
			{
				var Pvalue = NEUComponent.Instance.ProductService.GetById(x.ProductId);
				sale.Price = Pvalue.Price;
				sale.ProductId = Pvalue.ProductId;
				sale.Quantity = x.Quantity;
				sale.UserId = Uid;
				base.Insert(sale);
				var ChartValue = NEUComponent.Instance.ChartService.GetChartById(sale.UserId);
				//NEUComponent.Instance.ChartService.Delete(ChartValue);

			}
		}

		public void ProductSaleInsert(Sale product)
		{
			base.Insert(product);
		}
	}
}
