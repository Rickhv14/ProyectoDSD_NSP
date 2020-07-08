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
    public class AlumnoController : ApiController
    {



        [ActionName("Post")]
        [HttpPost]
        [Route("api/Alumno/Obtener")]
        public beAlumno Obtener(beAlumno obeAlumno)
        {
            beAlumno obeAlumnoResult = null;
            try
            {
                brAlumno obrAlumno = new brAlumno();
                obeAlumnoResult = obrAlumno.Obtener(obeAlumno.DNI, obeAlumno.Usuario);
            }
            catch (Exception ex)
            {
                obeAlumnoResult = null;
            }

            return obeAlumnoResult;
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