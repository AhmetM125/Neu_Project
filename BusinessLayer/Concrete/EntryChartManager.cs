using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
	public class EntryChartManager : Repository<EntryCart>, IStockEntryChart
	{
		public List<EntryCart> GetAllChart() => base.List();
	}
}
