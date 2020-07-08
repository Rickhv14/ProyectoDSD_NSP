using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DA;
namespace BR
{
    public class brFactura
    {
        public string TieneFacturaPendienteAlumno(string CodigoAlumno)
        {
            string result = "";

            try
            {
                using (SqlConnection cn = new SqlConnection(Util.Default))
                {
                    cn.Open();
                    daFactura odaFactura = new daFactura();
                    result = odaFactura.TieneFacturaPendienteAlumno(cn, CodigoAlumno);
                    
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
