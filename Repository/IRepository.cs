using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> SelectAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> pred);
        IEnumerable<T> Select(Expression<Func<T, bool>> pred);
        T SelectId(int id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
