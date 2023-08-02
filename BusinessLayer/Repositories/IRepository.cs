using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLayer.Repositories
{
	public interface IRepository<T>

	{

		/*List<T> JList();*/
		int Count();
		

		void Insert(T p1);
		List<T> List();
		void Delete(T p1);

		void DeleteW(Expression<Func<T, bool>> filter);

		T Get(Expression<Func<T, bool>> filter);

		void Update(T p1);
		

		List<T> List(Expression<Func<T, bool>> expression);

		float GeneralSum();


	}
}
