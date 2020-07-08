using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using System.Reflection;
namespace BR
{
  public  class Util
    {

        public static string Default
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["cone"].ConnectionString;
                
            }            
        }
        
    }
}
