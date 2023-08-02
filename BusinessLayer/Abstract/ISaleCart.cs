using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISaleCart : IRepository<SaleCart>
	{
		List<SaleCart> GetAllBl(int Uid);
		void ChartDelete(int Uid);
		void InsertChart(SaleCart saleCart);
		SaleCart GetChartById(int Uid, int Pid);
		SaleCart GetChartById(int Uid);

		SaleCart SetProduct(Product p, int Uid);

		void DeleteChartProduct(int Pid,int Uid);
		void CreateSale(SaleCart s);
		//  float TotalPrice(int Uid);

	}
}
