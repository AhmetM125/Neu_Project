using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ProductSaleManager : Repository<SaleProduct>, IProductSaleService
    {

        public List<SaleProduct> GetAllBl()
        {
            return base.List();
        }


    }
}
