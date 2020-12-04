using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Entities;

namespace Applications
{
    public class ClientesApplications
    {
        public ClientesApplications(){}
        public void Insert(clientes entity)
        {
            new ClientesDomain().Insert(entity);
        }
        public void Update(clientes entity)
        {
            new ClientesDomain().Update(entity);
        }
        public void Delete(clientes entity)
        {
            new ClientesDomain().Delete(entity);
        }
        public IEnumerable<clientes> SelectAll()
        {
            var response = new ClientesDomain().SelectAll();
            return response;
        }

        public clientes SelectId(int id)
        {
            var response = new ClientesDomain().SelectId(id);
            return response;
        }

        public clientes SelectId(string id)
        {
            var response = new ClientesDomain().SelectId(id);
            return response;
        }
    }
}
