using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using System.Security.Principal;
using BE;
using BR;
using App.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using App.LoginServiceReference;
namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//
        {
            if (Session["Usuario"] != null)
            {
                _beUser oUser = (_beUser)Session["Usuario"];
                ViewBag.Usuario = oUser.Nombre;
            }
            return View();
        }

        public string Acceso()
        {
            string Result = string.Empty;

            string Usuario = _.Post("usuario");
            string Password = _.Post("password");

            LoginServiceClient objLogin = new LoginServiceClient();
            string NombreUsuario = objLogin.Login(Usuario, Password);

            if (NombreUsuario != "")
            {
                _beUser oUser = new _beUser();
                oUser.Nombre = NombreUsuario;
                oUser.Usuario = Usuario;

                System.Web.HttpContext.Current.Session.Add("Usuario", oUser);

                Result = JsonConvert.SerializeObject(oUser);
      

            }

            return Result;
        }
        public ActionResult Login()//
        {
            return View();
        }

       
    }
}