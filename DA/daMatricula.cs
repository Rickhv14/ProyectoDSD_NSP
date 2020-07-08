using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using BE;
namespace DA
{
    public class daMatricula
    {
        public int Insert(SqlConnection cn, SqlTransaction ts, beMatricula obj)
        {
            int rowsaffected = 0;

            SqlCommand cmd = new SqlCommand("uspMatriculaInsert", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (ts != null)
            {
                cmd.Transaction = ts;
            }


            SqlParameter CodigoAlumno = cmd.Parameters.Add("@CodigoAlumno", SqlDbType.VarChar);
            CodigoAlumno.Direction = ParameterDirection.Input;
            CodigoAlumno.Value = obj.CodigoAlumno;

            SqlParameter Comentario = cmd.Parameters.Add("@Comentario", SqlDbType.VarChar);
            Comentario.Direction = ParameterDirection.Input;
            Comentario.Value = obj.Comentario;

            SqlParameter Turno = cmd.Parameters.Add("@Turno", SqlDbType.VarChar);
            Turno.Direction = ParameterDirection.Input;
            Turno.Value = obj.Turno;

            SqlParameter EstadoMatricula = cmd.Parameters.Add("@EstadoMatricula", SqlDbType.VarChar);
            EstadoMatricula.Direction = ParameterDirection.Input;
            EstadoMatricula.Value = obj.EstadoMatricula;


            rowsaffected = cmd.ExecuteNonQuery();

            return rowsaffected;

        }

        public List<beMatricula> Buscar(SqlConnection cn,string Usuario)
        {

            List<beMatricula> Lista = null;

            SqlCommand cmd = new SqlCommand("uspMatriculaBuscar", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pUsuario = cmd.Parameters.Add("@Usuario", SqlDbType.VarChar);
            pUsuario.Direction = ParameterDirection.Input;
            pUsuario.Value = Usuario;

            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dr != null)
                {
                    if (dr.HasRows)
                    {

                        Lista = new List<beMatricula>();
                        beMatricula obeMatricula = null;
                        while (dr.Read())
                        {
                            obeMatricula = new beMatricula();
                            obeMatricula.Id  = dr.GetInt32(0);
                            obeMatricula.CodigoAlumno = dr.GetString(1);
                            obeMatricula.DNIAlumno = dr.GetString(2);
                            obeMatricula.Nombre = dr.GetString(3);
                            obeMatricula.EstadoMatricula = dr.GetString(4);
                            obeMatricula.Comentario = dr.GetString(5);
                            obeMatricula.Fecha = dr.GetString(6);
                            Lista.Add(obeMatricula);
                        }
                    }
                }
            }

            return Lista;

        }

    }
}
