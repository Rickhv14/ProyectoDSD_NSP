using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using DA;
namespace BR
{
    public class brAlumno
    {
        public beAlumno Obtener(string DNI, string Usuario)
        {
            beAlumno obeAlumno = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(Util.Default))
                {
                    cn.Open();
                    daAlumno odaAlumno = new daAlumno();
                    obeAlumno = odaAlumno.Obtener(cn, DNI, Usuario);
                }

            }
            catch (Exception ex)
            {

            }
            return obeAlumno;
        }
    }
}
