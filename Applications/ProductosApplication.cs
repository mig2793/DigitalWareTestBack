using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Domain;
using Entities;

namespace Applications
{
    public class ProductosApplication
    {
        public ProductosApplication() { 
        
        }
        public void Insert(productos entity)
        {
            new ProductosDomain().Insert(entity);
        }
        public void Update(productos entity)
        {
            new ProductosDomain().Update(entity);
        }
        public void Delete(productos entity)
        {
            new ProductosDomain().Delete(entity);
        }
        public IEnumerable<productos> SelectAll()
        {
            var response = new ProductosDomain().SelectAll();
            return response;
        }

        public productos SelectId(int id)
        {
            var response = new ProductosDomain().SelectId(id);
            return response;
        }

        public IEnumerable<productos> SelectxNameColumn(Expression<Func<productos, bool>> pred)
        {
            var response = new ProductosDomain().SelectxNameColumn(pred);
            return response;
        }

    }
}
