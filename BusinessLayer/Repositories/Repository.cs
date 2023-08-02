using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;


namespace BusinessLayer.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly NEUContext _context = new NEUContext(NEUComponent.ConnectionString);
		public void Delete(T p1)
		{
			var deletedEntity = _context.Entry(p1);
			deletedEntity.State = EntityState.Deleted;
			_context.SaveChanges();

		}
		public void DeleteW(Expression<Func<T, bool>> filter)
		{
			var Deleting = _context.Set<T>().Where(filter);
			_context.Set<T>().RemoveRange(Deleting);
			_context.SaveChanges();

		}
		public T Get(Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().SingleOrDefault(filter);
			//return only one value 
		}



		public void Insert(T obj)
		{
			var addedEntity = _context.Entry(obj);
			addedEntity.State = EntityState.Added;
			_context.SaveChanges();
		}


		public List<T> List()
		{
			return _context.Set<T>().ToList();
		}
		public List<T> List(Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().Where(filter).ToList();
		}
		public void Update(T p1)
		{
			var track = _context.Entry(p1);
			track.State = EntityState.Modified;
			_context.SaveChanges();
		}
		public int Count()
		{
			return _context.Set<T>().Count();
		}


		public float GeneralSum()
		{
			bool Summation = _context.SaleCarts.Select(d => d.TotalPrice).Any();
			return Summation == true ? _context.SaleCarts.Select(d => d.TotalPrice).Sum() : 0;
		}
	}
}
