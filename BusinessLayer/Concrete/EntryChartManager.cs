using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
	public class EntryChartManager : Repository<EntryCart>, IStockEntryChart
	{
		public float CalculateTotal(int Uid)
		{
			using (NEUContext context = new NEUContext())
			{
				bool IsValid = context.EntryCarts.Where(x => x.UserId == Uid).Any();
				return IsValid == true ? context.EntryCarts.Where(x => x.UserId == Uid).Sum(x => x.Price * x.Quantity) : 0;
			}
		}

		public void DeleteEntryChart(int Uid)
		{
			base.DeleteW(x => x.UserId == Uid);
		}

		public List<EntryCart> GetAllChart(int UserId) => base.List(x => x.UserId == UserId);


		public bool InsertToBasket(Product p, int Uid, int Quantity)
		{
			bool IsExist = base.List(x => x.UserId == Uid).Where(x => x.ProductId == p.ProductId).Any();
			if (!IsExist)
			{
				EntryCart entryCart = new EntryCart
				{
					ProductId = p.ProductId,
					Quantity = Quantity,
					UserId = Uid,
					Price = p.Price
				};
				base.Insert(entryCart);
				return true;
			}
			else
				return false;
		}
	}
}
