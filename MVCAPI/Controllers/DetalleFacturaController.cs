using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Applications;

namespace MVCAPI.Controllers
{
    public class DetalleFacturaController : ApiController
    {
        private DetalleFacturaApplication applications;
        public DetalleFacturaController()
        {
            applications = new DetalleFacturaApplication();
        }
        public IEnumerable<detalle_factura> Get()
        {
            return applications.SelectAll();
        }

        public detalle_factura Get(int id)
        {
            return applications.SelectId(id);
        }

        public IHttpActionResult Post([FromBody] detalle_factura entity)
        {
            try
            {
                applications.Insert(entity);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

    }
}
