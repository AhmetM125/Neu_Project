using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class StockEntryManager : Repository<StockEntry>, IStockEntry
	{
		public void ConfirmEntry(int Uid)
		{

			StockEntry stockEntry = new StockEntry();
			var ChartList = NEUComponent.Instance.StockEntryChart.GetAllChart(Uid);
			stockEntry.TransactionNo = NEUComponent.Instance.ProductSaleService.GenerateTransactionNumber();
			stockEntry.UserId = Uid;
			stockEntry.Date = DateTime.Today;
			foreach (var item in ChartList)
			{
				
				stockEntry.ProducId = item.ProductId;
				stockEntry.Quantity = (int)item.Quantity;
				stockEntry.Price = item.Price;
				stockEntry.Date = DateTime.Today;
				base.Insert(stockEntry);
				NEUComponent.Instance.ProductService.IncreaseQuantity(stockEntry.Quantity, stockEntry.ProducId);

			}
			NEUComponent.Instance.StockEntryChart.DeleteEntryChart(Uid);
		}

		public List<StockEntry> GetAllBl() => base.List();


	}
}
