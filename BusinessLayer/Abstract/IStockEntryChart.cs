using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
	public interface IStockEntryChart : IRepository<EntryCart>
	{
		List<EntryCart> GetAllChart(int UserId);
		bool InsertToBasket(Product p, int Uid, int Quantity);
		float CalculateTotal(int Uid);
		void DeleteEntryChart(int Uid);

	}
}
