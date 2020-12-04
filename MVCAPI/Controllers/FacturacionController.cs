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
    public class FacturacionController : ApiController
    {
        private FacturaApplication applications;
        public FacturacionController() {
            applications = new FacturaApplication();
        }
        public IEnumerable<factura> Get()
        {
            return applications.SelectAll();
        }

        public factura Get(int id)
        {
            return applications.SelectId(id);
        }

        public IHttpActionResult GetXame(string item, int option)
        {
            try
            {
                IEnumerable<factura> res = null;

                if (option == 1)
                    res = applications.SelectxNameColumn(x => x.id.ToString() == item);
                else if (option == 2)
                    res = applications.SelectxNameColumn(x => x.id_cliente.ToString() == item);
                else if (option == 3)
                    res = applications.SelectxNameColumn(x => x.clientes.nombres.StartsWith(item));

                if (res.Count() > 0)
                {

                    return Ok(res);
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] factura entity)
        {
            try
            {
                entity.fecha = DateTime.Today;
                applications.Insert(entity);
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/Facturacion/delete")]
        public IHttpActionResult PostFactura([FromBody] factura entity)
        {
            try
            {
                applications.Delete(entity);
                return Ok(entity);

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

        }
    }
}
