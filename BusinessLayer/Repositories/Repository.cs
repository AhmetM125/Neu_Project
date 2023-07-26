using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace BusinessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private NEUContext _context = new NEUContext(NEUComponent.ConnectionString);


        public void Delete(T p1)
        {
            var deletedEntity = _context.Entry(p1);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);
            Delete(obj);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().SingleOrDefault(filter);            //return only one value 
        }

        public void Insert(T obj)
        {
            var addedEntity = _context.Entry(obj);
            addedEntity.State = EntityState.Added;
           // var result = _context.Set<T>().Add(obj);
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

    }
}
