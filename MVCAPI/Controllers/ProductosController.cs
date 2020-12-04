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
    public class ProductosController : ApiController
    {
        private ProductosApplication applications;
        public ProductosController()
        {
            applications = new ProductosApplication();
        }
        public IHttpActionResult Get()
        {

            try
            {
                var res = applications.SelectAll();
                if (res != null)
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

        public IHttpActionResult Get(int id)
        {
            try
            {
                var res = applications.SelectId(id);
                if (res != null)
                {
                    return Ok(res);
                }
                else {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            catch (Exception e) {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

        }

        public IHttpActionResult GetXame(string item)
        {
            try
            {
                var res = applications.SelectxNameColumn(x => x.producto.StartsWith(item) || x.codigo_producto.ToString() == item);
                
                if (res != null)
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

    }
}
