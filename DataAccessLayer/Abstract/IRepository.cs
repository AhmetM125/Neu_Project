 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
	public interface IRepository<T>

	{
		void Insert(T p1);
		List<T> List();
		void Delete(T p1);
		
		T Get(Expression<Func<T, bool>> filter);

		void Update(T p1);

		 List<T> List(Expression<Func<T, bool>> expression);
		
	}
}
