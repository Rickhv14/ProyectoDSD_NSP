using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace NSP_Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public string ConsultarNota(string dni, string codigo)
        {
            string result = "";
            try
            {


                using (SqlConnection cn = new SqlConnection("server=.;uid=sa;pwd=123456;database=NSP;"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("uspConsultarNotaAlumno", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = cmd.Parameters.Add("@DNIAlumno", SqlDbType.VarChar);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = dni;

                    SqlParameter p2 = cmd.Parameters.Add("@CodigoAlumno", SqlDbType.VarChar);
                    p2.Direction = ParameterDirection.Input;
                    p2.Value = codigo;


                    result = cmd.ExecuteScalar().ToString();



                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return result;
        }

    }
}
