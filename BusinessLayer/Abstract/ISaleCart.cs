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
        List<SaleCart> GetAllBl();
        void ChartDelete(SaleCart saleCart);
        void InsertChart(SaleCart saleCart);
        SaleCart GetById(SaleCart saleCart);
        SaleCart SetProduct(Product p);
    }
}
