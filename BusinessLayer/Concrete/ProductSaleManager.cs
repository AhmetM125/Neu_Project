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
			return base.List(x => x.User.Id == id);
		}

		public List<Sale> GetList()
		{
			throw new System.NotImplementedException();
		}

        public void PaymentProcess(Sale sale,int Uid)
        {
			SaleCartManager saleCartManager = new SaleCartManager();

			sale.TransactionNo = GenerateTransactionNumber();
			sale.UserId = Uid;
			sale.SaleDate = DateTime.Today;

			var values = from x in saleCartManager.GetAllBl(sale.UserId)
						 select new
						 {
							 ProductID = x.ProductId,
							 Quantity = x.Quantity
						 };

            foreach (var x in values)
            {
				/*base.Insert();
				base.Delete();*/
            }
        }

        public void ProductSaleInsert(Sale product)
		{
			base.Insert(product);
		}
	}
}
