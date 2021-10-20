namespace EVENTUM.Controllers
{
    using EVENTUM.Models;
    using System.Net.Mail;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IngresoViewModels model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            string mensaje = "Gracias ";

            return RedirectToAction("Ingreso", "Cuenta", new { strMensaje = mensaje });
        }

        /// <summary>
        /// Envia correo
        /// </summary>
        /// <param name="strEmail">Email</param>
        /// <param name="strAsunto">Asunto</param>
        /// <param name="strSocio">Socio</param>
        /// <param name="strParametro2">Parametro 2</param>
        /// <param name="bandera">True envia correo clave false envia preventa ok</param>
        public void EnviarCorreo(string strEmail, string strAsunto, string strSocio, string strParametro2, bool bandera)
        {
            string strHost = "send.smtp.com";
            string strCorreo = "reserva.boletos@obtelsa.com";
            string strPassword = "Colon548";
            string strBody = string.Empty;
            string strPlantillaCorreo = string.Empty;
            if (bandera)
                strPlantillaCorreo = Server.MapPath("~/Plantillas/correoEnvioClave.html");
            else
                strPlantillaCorreo = Server.MapPath("~/Plantillas/correoPreventaOK.html");

            string strMensaje = "Mensaje enviado correctamente";

            System.IO.StreamReader _streamReader = new System.IO.StreamReader(strPlantillaCorreo, System.Text.Encoding.UTF8);
            strBody = _streamReader.ReadToEnd();
            strBody = strBody.Replace("[#PARAMETRO1]", strSocio);
            strBody = strBody.Replace("[#PARAMETRO2]", strParametro2);
            _streamReader.Close();

            MailMessage mmCorreo = new MailMessage()
            {
                From = new MailAddress(strCorreo),
                Subject = strAsunto,
                Body = strBody,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };
            mmCorreo.To.Add(strEmail);
            SmtpClient smtp = new SmtpClient()
            {
                Host = strHost,
                Port = 2525,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new System.Net.NetworkCredential(strCorreo, strPassword)
            };

            smtp.Send(mmCorreo);
            ViewBag.Mensaje = strMensaje;
        }
    }
}