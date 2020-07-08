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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LoginService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione LoginService.svc o LoginService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class LoginService : ILoginService
    {

        public string Login(string user, string password)
        {
            string userReturn = "";

            try
            {
                

                using (SqlConnection cn = new SqlConnection("server=.;uid=sa;pwd=123456;database=NSP;"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Login", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = cmd.Parameters.Add("@user", SqlDbType.VarChar);
                    p1.Direction = ParameterDirection.Input;
                    p1.Value = user;

                    SqlParameter p2 = cmd.Parameters.Add("@password", SqlDbType.VarChar);
                    p2.Direction = ParameterDirection.Input;
                    p2.Value = password;


                    userReturn = cmd.ExecuteScalar().ToString();

                    

                }
            }
            catch (Exception ex)
            {
                userReturn = string.Empty;
            }

            return userReturn;
        }
        
    }
}
