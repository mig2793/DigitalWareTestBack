using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Applications;
using Entities;

namespace MVCAPI.Controllers
{
    public class ClienteController : ApiController
    {
        private ClientesApplications applications;
        public ClienteController()
        {
            applications = new ClientesApplications();
        }
        public IEnumerable<clientes> Get()
        {
            return applications.SelectAll();
        }

        // GET api/values/5
        public clientes Get(string id)
        {
            return applications.SelectId(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] clientes entity)
        {
            try
            {
                applications.Insert(entity);
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put([FromBody] clientes entity)
        {
            try
            {
                applications.Update(entity);
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

    }
}
