using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		Context c = new Context();
		DbSet<T> _obj;

		public GenericRepository()
		{
			_obj = c.Set<T>();
		}

		public void Delete(T p1)
		{
			var DeletedEntity = c.Entry(p1);
			DeletedEntity.State = EntityState.Deleted;
			//_obj.Remove(p1);
			c.SaveChanges();
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			return _obj.SingleOrDefault(filter); //return only one value 
		}

		public void Insert(T p1)
		{
			var addedEntity = c.Entry(p1);
			addedEntity.State = EntityState.Added;
			//_obj.Add(p1);
			c.SaveChanges();
		}

		public List<T> List()
		{
			return _obj.ToList();
		}
		public List<T> List(Expression<Func<T, bool>> expression)
		{
			return _obj.Where(expression).ToList();
		}
		public void Update(T p1)
		{
			var UpdatedEntity = c.Entry(p1);
			UpdatedEntity.State = EntityState.Modified;
			c.SaveChanges();
		}
	}
}
