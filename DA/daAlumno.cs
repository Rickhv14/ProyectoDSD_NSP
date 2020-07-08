using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;
namespace DA
{
    public class daAlumno
    {
        public beAlumno Obtener(SqlConnection cn, string DNI,string Usuario)
        {

            beAlumno obeAlumno = null;

            SqlCommand cmd = new SqlCommand("uspAlumnoObtenerNombreCompleto", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pUsuario = cmd.Parameters.Add("@Usuario", SqlDbType.VarChar);
            pUsuario.Direction = ParameterDirection.Input;
            pUsuario.Value = Usuario;

            SqlParameter pDNI = cmd.Parameters.Add("@DNI", SqlDbType.VarChar);
            pDNI.Direction = ParameterDirection.Input;
            pDNI.Value = DNI;

            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            obeAlumno = new beAlumno();
                            obeAlumno.CodigoAlumno = dr.GetString(0);
                            obeAlumno.NombreCompleto = dr.GetString(1);
                            obeAlumno.Telefono = dr.GetString(2);
                        }
                    }
                }
            }

            return obeAlumno;

        }
    }
}
