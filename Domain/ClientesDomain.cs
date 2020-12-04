using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ClientesDomain
    {
        private Repository<clientes> repository = new Repository<clientes>(new facturacion());

        public IEnumerable<clientes> SelectAll() {
            return repository.SelectAll().ToList();
        }
        public clientes SelectId(int id)
        {
            return repository.SelectId(id);
        }

        public clientes SelectId(string id)
        {
            return repository.SelectId(id);
        }

        public void Insert(clientes entity) {
            repository.Insert(entity);
            repository.Save();
        }

        public void Update(clientes entity) {
            repository.Update(entity);
            repository.Save();
        }

        public void Delete(clientes entity)
        {
            repository.Delete(entity);
            repository.Save();
        }

    }
}
