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
			int TotalSale = base.Count() + 1;
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

		public int TotalCount() => base.Count();
		
		public void PaymentProcess(Sale sale, int Uid)
		{
			sale.UserId = Uid;
			sale.TransactionNo = GenerateTransactionNumber();
		//	sale.SaleDate = DateTime.Today;
			
			var saleItems = NEUComponent.Instance.ChartService.GetAllBl(sale.UserId).ToList();

			foreach (var item in saleItems)
			{
				sale.Price = (float)item.Price;
				sale.ProductId = item.ProductId;
				sale.Quantity = item.Quantity;
				base.Insert(sale);
				NEUComponent.Instance.ProductService.DecreaseQuantity(item.Quantity, item.ProductId);
				
			}
			NEUComponent.Instance.ChartService.ChartDelete(Uid);
		}

		public void ProductSaleInsert(Sale product)
		{
			base.Insert(product);
		}

		
	}
}
