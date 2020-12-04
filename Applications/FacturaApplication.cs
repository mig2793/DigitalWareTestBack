using System;
using Entities;
using Domain;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applications
{
    public class FacturaApplication
    {

        public FacturaApplication() { }

        public void Insert(factura entity) {
            new FacturaDomain().Insert(entity);
        }
        public void Update(factura entity)
        {
            new FacturaDomain().Update(entity);
        }
        public void Delete(factura entity)
        {
            new FacturaDomain().Delete(entity);
        }
        public IEnumerable<factura> SelectAll() {
            var response = new FacturaDomain().SelectAll();
            return response;
        }

        public factura SelectId(int id)
        {
            var response = new FacturaDomain().SelectId(id);
            return response;
        }

        public IEnumerable<factura> SelectxNameColumn(Expression<Func<factura, bool>> pred)
        {
            var response = new FacturaDomain().SelectxNameColumn(pred);
            return response;
        }
    }
}
