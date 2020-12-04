using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public Repository(DbContext contexto) {
            _context = contexto;
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Delete(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);

          _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Dispose()
        {
            return;
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> pred)
        {
            return _context.Set<T>().Where(pred);
        }

        public IEnumerable<T> SelectAll()
        {
            return _context.Set<T>(); 
        }

        public T SelectId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T SelectId(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (_context.Entry<T>(entity).State != System.Data.Entity.EntityState.Detached)
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            else
                _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);

            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;

        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> pred)
        {
            return _context.Set<T>().Where(pred);
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}
