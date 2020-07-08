using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using BE;
using System.Web;

namespace App.Models
{
    public class _
    {
        public static string Post(string campo)
        {
            bool existeParametro = HttpContext.Current.Request.Form[campo] != null;
            string parametro = existeParametro ? HttpContext.Current.Request.Form[campo].ToString().Trim() : string.Empty;
            return parametro;
        }

        public static string Get(string campo)
        {
            bool existeParametro = HttpContext.Current.Request.QueryString[campo] != null;
            string parametro = existeParametro ? HttpContext.Current.Request.QueryString[campo].ToString().Trim() : string.Empty;
            return parametro;
        }
    }
}