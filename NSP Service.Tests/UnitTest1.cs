using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSP_Service.Tests.AlumnoServiceReference;
using NSP_Service.Tests.LoginServiceReference;
using System.Net.Http;
using BE;
namespace NSP_Service.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTestSuccess()
        {
            LoginServiceClient objLogin = new LoginServiceClient();
            string userTest = "70117292";
            string passwordTest = "123456";
            string userReturn = objLogin.Login(userTest, passwordTest);
            Assert.IsTrue(userReturn.Length > 0, "Success");
        }

        [TestMethod]
        public void LoginTestError()
        {
            LoginServiceClient objLogin = new LoginServiceClient();
            string userTest = "70117292";
            string passwordTest = "1234567";
            string userReturn = objLogin.Login(userTest, passwordTest);
            Assert.IsTrue(userReturn.Length == 0, "Error");
        }

        [TestMethod]
        public void ConsultaNotaTestSuccess()
        {
            AlumnoServiceClient objAlumno = new AlumnoServiceClient();
            string DNI = "";
            string Codigo = "NSP201120";
            string result = objAlumno.ConsultarNota(DNI, Codigo);
            Assert.IsTrue(result.Length > 0, "Success");
        }

        [TestMethod]
        public void ConsultaNotaTesttError()
        {
            AlumnoServiceClient objAlumno = new AlumnoServiceClient();
            string DNI = "70117292";
            string Codigo = "123456";
            string result = objAlumno.ConsultarNota(DNI, Codigo);
            Assert.IsTrue(result.Length == 0, "Error");
        }
        [TestMethod]
        public void Obtener()
        {
            string POs = "";
            using (var client = new HttpClient())
            {
                beAlumno oAlumno = new beAlumno();
                oAlumno.DNI = "70125788";
                oAlumno.Usuario = "70117292";
                var postTask = client.PostAsJsonAsync<beAlumno>("https://localhost:44346/api/Alumno/Obtener", oAlumno);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync(); //<List<bePo>>();
                    readTask.Wait();
                    POs = readTask.Result;
                }
            }
            Assert.IsNotNull(POs, "Correcto");
        }

    }
}
