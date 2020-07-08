using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DA
{
    public class daFactura
    {
        public string TieneFacturaPendienteAlumno(SqlConnection cn,string CodigoAlumno)
        {
            int rowsaffected = 0;

            SqlCommand cmd = new SqlCommand("uspFacturaPendienteAlumno", cn);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter pCodigoAlumno = cmd.Parameters.Add("@CodigoAlumno", SqlDbType.VarChar);
            pCodigoAlumno.Direction = ParameterDirection.Input;
            pCodigoAlumno.Value = CodigoAlumno;


            var obj = cmd.ExecuteScalar();

            string result = "";

            if (obj != null)
            {
                result =(string)obj;
            }
            return result;

        }
    }
}
