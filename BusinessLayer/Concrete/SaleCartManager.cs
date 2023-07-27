using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SaleCartManager : Repository<EntityLayer.Concrete.SaleCart>, ISaleCart
    {
        public void ChartDelete(EntityLayer.Concrete.SaleCart shoppingChart)
        {
            throw new System.NotImplementedException();
        }

        public List<SaleCart> GetAllBl()
        {
            return base.List();
        }

        public SaleCart GetById(SaleCart saleCart)
        {
            return base.Get(x => x.ProductId == saleCart.ProductId);
        }

        public void InsertChart(SaleCart saleCart)
        {
             base.Insert(saleCart);
        }
        public SaleCart SetProduct(Product p)
        {
            SaleCart s = new SaleCart();
            s.ProductId = p.ProductId;
            s.Quantity = p.Quantity;
            s.Price = p.Price;
            s.TotalPrice = p.Price * p.Quantity;
            s.UserId = 1;

            return s;



        }
    }
}
