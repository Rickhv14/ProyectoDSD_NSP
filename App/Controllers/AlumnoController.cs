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
using System.Net.Http;
using System.Net.Http.Formatting;
using OfficeOpenXml.Style;
using RabbitMQ.Client;
using System.Web.Script.Serialization;
using System.Text;
using App.AlumnoServiceReference;
namespace App.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index()//
        {
            return View();
        }

        public ActionResult Matricula()//
        {
            return View();
        }
        public ActionResult Consulta()//
        {
            return View();
        }
        public string BuscarAlumno()
        {
            string resultstr = string.Empty;

            string DNI = _.Post("dni");
            _beUser oUser = (_beUser)Session["Usuario"];
            using (var client = new HttpClient())
            {
                beAlumno beResult = null;
                beAlumno oAlumno = new beAlumno();
                oAlumno.DNI = DNI;
                oAlumno.Usuario = oUser.Usuario;
                var postTask = client.PostAsJsonAsync<beAlumno>("https://localhost:44346/api/Alumno/Obtener", oAlumno);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<beAlumno>(); //<List<bePo>>();
                    readTask.Wait();
                    beResult = readTask.Result;
                }
                if (beResult != null)
                {
                    resultstr = JsonConvert.SerializeObject(beResult);
                }
            }

            return resultstr;

        }


        private string TieneFacturaPendiente(string codigo)
        {
            string bresult = "";

            using (var client = new HttpClient())
            {

                var postTask = client.PostAsJsonAsync<string>("https://localhost:44346/api/Factura/Pendiente", codigo);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<string>(); //<List<bePo>>();
                    readTask.Wait();
                    bresult = readTask.Result;
                }
            }

            return bresult;

        }

        public string ConsultaNota()
        {

            string result = string.Empty;

            string DNI = _.Post("dni");
            string Codigo = _.Post("codigo");

            AlumnoServiceClient objAlumno = new AlumnoServiceClient();
            result = objAlumno.ConsultarNota(DNI, Codigo);

            return result;
        }

        public string GuardarMatricula()
        {

            string Message = "";

            string Codigo = _.Post("codigo");
            string Comentario = _.Post("comentario");
            string Turno = _.Post("turno");
            string Estado = "Pendiente";
            string Telefono = _.Post("telefono");

            string Factura = TieneFacturaPendiente(Codigo);


            if (Factura != "")
            {
                Message = "El alumno tiene facturas pendientes de Pago. Comuniquese con administracion";
                return Message;
            }

            bool transsaccion = false;

            beMatricula obeMatricula = new beMatricula();
            obeMatricula.CodigoAlumno = Codigo;
            obeMatricula.Comentario = Comentario;
            obeMatricula.Turno = Turno;
            obeMatricula.EstadoMatricula = Estado;

            using (var client = new HttpClient())
            {
                var postTask = client.PostAsJsonAsync<beMatricula>("https://localhost:44346/api/Matricula/Insert", obeMatricula);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>(); //<List<bePo>>();
                    readTask.Wait();
                    transsaccion = readTask.Result;
                }
            }

            if (transsaccion)
            {
                Message = "Se registro Correctamente";

                string MessageSMS = Notificar(Message, Telefono);
                var messageAgregar = new JavaScriptSerializer().Serialize(obeMatricula);
                SaveQueue(messageAgregar);
            }
            else
            {
                Message = "No se puedo registrar la solicitud. Comuniquese con Administracion.";
            }

            return Message;
        }

        private string Notificar(string Message, string telefono)
        {
            string resultStr = "";
            using (var client = new HttpClient())
            {
                //string Message = "Hello from Peru ";
                //string Number = "51962352907";

                beMensaje obeMensaje = new beMensaje();
                obeMensaje.Message = Message;
                obeMensaje.Number = telefono;
                var postTask = client.PostAsJsonAsync<beMensaje>("https://localhost:44346/api/Notificacion/SendSMS", obeMensaje);
                postTask.Wait();


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    resultStr = readTask.Result;
                }
            }
            return resultStr;
        }


        public string ListaRatificacion()
        {
            string resultstr = string.Empty;

            _beUser oUser = (_beUser)Session["Usuario"];
            List<beMatricula> Lista = null;
            using (var client = new HttpClient())
            {

                var postTask = client.PostAsJsonAsync<string>("https://localhost:44346/api/Matricula/Buscar", oUser.Usuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<beMatricula>>(); //<List<bePo>>();
                    readTask.Wait();
                    Lista = readTask.Result;
                }
                if (Lista != null)
                {
                    resultstr = JsonConvert.SerializeObject(Lista);
                }
            }

            return resultstr;
        }

        public void SaveQueue(string MessageQueue)
        {
            try
            {
                if (MessageQueue != "")
                {
                    string url = "amqp://hjbxcxue:T9_52j4vuQAWdIgxRzpu1Hodly3oy1er@shrimp.rmq.cloudamqp.com/hjbxcxue";
                    var connFactory = new ConnectionFactory();
                    connFactory.Uri = new Uri(url.Replace("amqp://", "amqps://"));

                    using (var conn = connFactory.CreateConnection())
                    using (var channel = conn.CreateModel())
                    {

                        var queueName = "Matricula";

                        var dataAgregar = Encoding.UTF8.GetBytes(MessageQueue);
                        bool durable = true;
                        bool exclusive = false;
                        bool autoDelete = false;
                        channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);
                        var exchangeName = "";
                        var routingKey = queueName;
                        channel.BasicPublish(exchangeName, routingKey, null, dataAgregar);

                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

     

    }
}