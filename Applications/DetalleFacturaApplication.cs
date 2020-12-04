using System;
using Entities;
using Domain;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applications
{
    public class DetalleFacturaApplication
    {
        public DetalleFacturaApplication() { }
        public void Insert(detalle_factura entity)
        {
            new DetalleFacturaDomain().Insert(entity);
        }
        public void Update(detalle_factura entity)
        {
            new DetalleFacturaDomain().Update(entity);
        }
        public void Delete(detalle_factura entity)
        {
            new DetalleFacturaDomain().Delete(entity);
        }
        public IEnumerable<detalle_factura> SelectAll()
        {
            var response = new DetalleFacturaDomain().SelectAll();
            return response;
        }

        public detalle_factura SelectId(int id)
        {
            var response = new DetalleFacturaDomain().SelectId(id);
            return response;
        }
        public IEnumerable<detalle_factura> SelectxNameColumn(Expression<Func<detalle_factura, bool>> pred)
        {
            var response = new DetalleFacturaDomain().SelectxNameColumn(pred);
            return response;
        }
    }
}
