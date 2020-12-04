using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain
{
    public class DetalleFacturaDomain
    {
        private Repository<detalle_factura> repository = new Repository<detalle_factura>(new facturacion());

        public IEnumerable<detalle_factura> SelectAll()
        {
            return repository.SelectAll().ToList();
        }
        public detalle_factura SelectId(int id)
        {
            return repository.SelectId(id);
        }
        public void Insert(detalle_factura entity)
        {
            repository.Insert(entity);
            repository.Save();
        }
        public void Update(detalle_factura entity)
        {
            repository.Update(entity);
            repository.Save();
        }
        public void Delete(detalle_factura entity)
        {
            repository.Delete(entity);
            repository.Save();
        }

        public IEnumerable<detalle_factura> SelectxNameColumn(Expression<Func<detalle_factura, bool>> pred)
        {
            return repository.Select(pred);
        }
    }
}
