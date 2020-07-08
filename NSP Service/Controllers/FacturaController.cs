using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE;
using BR;
namespace NSP_Service.Controllers
{
    public class FacturaController : ApiController
    {



        [ActionName("Post")]
        [HttpPost]
        [Route("api/Factura/Pendiente")]
        public string Pendiente([FromBody]string codigo)
        {
            string  result = "";
            try
            {
                brFactura obrFactura = new brFactura();
                result = obrFactura.TieneFacturaPendienteAlumno(codigo);
            }
            catch (Exception ex)
            {
                result = "";
            }

            return result;
        }




        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}