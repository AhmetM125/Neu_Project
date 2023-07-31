using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IStockEntry : IRepository<StockEntry>
    {
        List<StockEntry> GetAllBl();
       /* StockEntry GetById(int id);*//*
        void CategoryDelete(Category category);
        void UpdateCategory(Category category);*/
    }
}
