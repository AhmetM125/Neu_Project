using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		readonly ICategoryDal _categoryDal;

		//Constructor
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public List<Category> GetAllBl()
		{
			return _categoryDal.List();
		}

		public void CategoryAddBl(Category p)
		{
				_categoryDal.Insert(p);
			
		}	
		public Category GetById(int id)
		{
			return _categoryDal.Get(x=>x.CategoryId== id);
		}

		public void CategoryDelete(Category category)
		{
			_categoryDal.Delete(category);
		}

		public void UpdateCategory(Category category)
		{
			_categoryDal.Update(category);
		}
	}
}
