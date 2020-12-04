using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain
{
    public class FacturaDomain
    {
        private Repository<factura> repository = new Repository<factura>(new facturacion());

        public IEnumerable<factura> SelectAll()
        {
            return repository.SelectAll().ToList();
        }
        public factura SelectId(int id)
        {
            return repository.SelectId(id);
        }
        public void Insert(factura entity)
        {
            repository.Insert(entity);
            repository.Save();
        }
        public void Update(factura entity)
        {
            repository.Update(entity);
            repository.Save();
        }
        public void Delete(factura entity)
        {
            repository.Delete(entity);
            repository.Save();
        }
        public IEnumerable<factura> SelectxNameColumn(Expression<Func<factura, bool>> pred)
        {
            return repository.Select(pred);
        }

    }
}
