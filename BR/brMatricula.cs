using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BE;
using DA;
namespace BR
{
    public class brMatricula
    {
        public bool Insert(beMatricula obj)
        {
            bool result = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(Util.Default))
                {
                    cn.Open();
                    daMatricula odaMatricula = new daMatricula();
                    int rowsaffected = odaMatricula.Insert(cn, null, obj);
                    if (rowsaffected > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public List<beMatricula> Buscar(string Usuario)
        {

            List<beMatricula> Lista = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(Util.Default))
                {
                    cn.Open();
                    daMatricula odaMatricula = new daMatricula();
                    Lista = odaMatricula.Buscar(cn, Usuario);

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Lista;

        }
    }
}
