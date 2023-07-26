using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IProductSaleService : IRepository<SaleProduct>
    {
        List<SaleProduct> GetAllBl();
        List<SaleProduct> GetList();
    }
}
