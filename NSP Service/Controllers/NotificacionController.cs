using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE;
using System.Collections.Specialized;
using System.IO;
namespace NSP_Service.Controllers
{
    public class NotificacionController : ApiController
    {
        [ActionName("Post")]
        [HttpPost]
        [Route("api/Notificacion/SendSMS")]
        public bool SendSMS(beMensaje obeMensaje)
        {
            bool result = true;
            try
            {

                string MessageResponse = sendSMS1s2u(obeMensaje.Message, obeMensaje.Number);

                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
                        { "phone", obeMensaje.Number },
                        { "message", obeMensaje.Message },
                        { "key", "textbelt" },
                        });

                    //string resultMessage = Encoding.UTF8.GetString(response);
                    //if (resultMessage.Contains("error"))
                    //{
                    //    string MessageResponse = sendSMS1s2u(obeMensaje.Message, obeMensaje.Number);
                    //}
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        [ActionName("Get")]
        [HttpGet]
        [Route("api/Notification/SendSMSGET")]
        public bool SendSMSGET()
        {
            bool result = true;
            try
            {
                beMensaje obeMensaje = new beMensaje();
                obeMensaje.Message = "Holi";
                obeMensaje.Number = "51962352907";
                string MessageResponse = sendSMS1s2u(obeMensaje.Message, obeMensaje.Number);

                //using (WebClient client = new WebClient())
                //{
                //    byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
                //        { "phone", obeMensaje.Number },
                //        { "message", obeMensaje.Message },
                //        { "key", "textbelt" },
                //        });

                //    string resultMessage = Encoding.UTF8.GetString(response);
                //    if (resultMessage.Contains("error"))
                //    {
                //        string MessageResponse = sendSMS1s2u(obeMensaje.Message, obeMensaje.Number);
                //    }
                //}
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        private string sendSMS1s2u(string message, string number)
        {
            string messageId = "null";

            Stream update_objStream1 = Stream.Null, objStream1 = Stream.Null, objStream = Stream.Null;
            string sURL;
            sURL = "https://api.1s2u.io/bulksms?username=smsricardo.019&password=web11128&mt=0&fl=0&Sid=RHV&mno=" + number + "&msg=" + message;

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);

            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            try { objStream = wrGETURL.GetResponse().GetResponseStream(); }
            catch (Exception ex)
            {
                // handle exception here

            }
            StreamReader objReader = new StreamReader(objStream);
            messageId = objReader.ReadLine(); //final message id from stream object
            return messageId;


        }
    }
}