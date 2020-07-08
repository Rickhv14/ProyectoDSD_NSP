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
    public class MatriculaController : ApiController
    {

        [ActionName("Post")]
        [HttpPost]
        [Route("api/Matricula/Insert")]
        public bool Insert(beMatricula obeMatricula)
        {
            bool result = true;
            try
            {
                brMatricula obrMatricula = new brMatricula();
                result = obrMatricula.Insert(obeMatricula);
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        [ActionName("Post")]
        [HttpPost]
        [Route("api/Matricula/Buscar")]
        public List<beMatricula> Buscar([FromBody]string usuario)
        {
            List<beMatricula> Lista = null;
            try
            {
                brMatricula obrMatricula = new brMatricula();
                Lista = obrMatricula.Buscar(usuario);
            }
            catch (Exception ex)
            {
                Lista = null;
            }

            return Lista;
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