using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain
{
    public class ProductosDomain
    {
        private Repository<productos> repository = new Repository<productos>(new facturacion());

        public IEnumerable<productos> SelectAll()
        {
            return repository.SelectAll().ToList();
        }
        public productos SelectId(int id)
        {
            return repository.SelectId(id);
        }
        public void Insert(productos entity)
        {
            repository.Insert(entity);
            repository.Save();
        }
        public void Update(productos entity)
        {
            repository.Update(entity);
            repository.Save();
        }
        public void Delete(productos entity)
        {
            repository.Delete(entity);
            repository.Save();
        }

        public IEnumerable<productos> SelectxNameColumn(Expression<Func<productos, bool>> pred) {
            return repository.Select(pred);
        }
    }
}
