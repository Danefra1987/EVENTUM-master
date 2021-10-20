using EVENTUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EVENTUM.Comun
{
    public class ClsUtilitarios : Controller
    {
        public ClsUtilitarios()
        {
        }
        private ObtelsaEntities DBContext = new ObtelsaEntities();
        /// <summary>
        /// Metodo para enviar correo
        /// </summary>
        /// <param name="objMdlEnviaCorreo">Modelo con informacion para enviar correo electronico</param>
        public void EnviarCorreo(MdlEnviaCorreo objMdlEnviaCorreo)
        {
            string strHost = "send.smtp.com";
            string strCorreo = "reserva.boletos@obtelsa.com";
            string strPassword = "Colon548";
            string strBody = string.Empty;
            string strPlantillaCorreo = string.Empty;
            if (objMdlEnviaCorreo.bandera)
                strPlantillaCorreo = Server.MapPath("~/Plantillas/correoEnvioClave.html");
            else
                strPlantillaCorreo = Server.MapPath("~/Plantillas/correoPreventaOK.html");

            string strMensaje = "Mensaje enviado correctamente";

            System.IO.StreamReader _streamReader = new System.IO.StreamReader(strPlantillaCorreo, System.Text.Encoding.UTF8);
            strBody = _streamReader.ReadToEnd();
            strBody = strBody.Replace("[#PARAMETRO1]", objMdlEnviaCorreo.Socio);
            strBody = strBody.Replace("[#PARAMETRO2]", objMdlEnviaCorreo.Parametro2);
            _streamReader.Close();

            MailMessage mmCorreo = new MailMessage()
            {
                From = new MailAddress(strCorreo),
                Subject = objMdlEnviaCorreo.Asunto,
                Body = strBody,
                IsBodyHtml = true,
                Priority = MailPriority.Normal
            };
            mmCorreo.To.Add(objMdlEnviaCorreo.Email);
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

        private void VerifyAuthhorized()
        {
            if (Session["IsAuthenticated"] != null)
            {
                bool Authorized = false;
                if (bool.TryParse(Session["IsAuthenticated"].ToString(), out Authorized))
                {
                    if (Authorized)
                    {
                        string UserName = Session["UserName"].ToString();
                        FormsAuthentication.SetAuthCookie(UserName, false);
                        RenewCurrentUser();
                        bool isAuth = Request.IsAuthenticated;
                        ViewBag.UserName = User.Identity.Name;
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                    }
                }

            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }
        /// <summary>
        /// Verifica la autorizacion de usuarios
        /// </summary>
        public void VerificarLogin()
        {
            if (Session["IsAuthenticated"] != null)
            {
                bool Authorized = false;
                if (bool.TryParse(Session["IsAuthenticated"].ToString(), out Authorized))
                {
                    if (Authorized)
                    {
                        string UserName = Session["UserName"].ToString();
                        FormsAuthentication.SetAuthCookie(UserName, false);
                        RenewCurrentUser();
                        bool isAuth = Request.IsAuthenticated;
                        ViewBag.UserName = User.Identity.Name;
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                    }
                }
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }

        public void RenewCurrentUser()
        {
            HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = null;
                try
                {
                    authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                }
                catch { }

                if (authTicket != null && !authTicket.Expired)
                {
                    FormsAuthenticationTicket newAuthTicket = authTicket;

                    if (FormsAuthentication.SlidingExpiration)
                    {
                        newAuthTicket = FormsAuthentication.RenewTicketIfOld(authTicket);
                    }
                    string userData = newAuthTicket.UserData;
                    string[] roles = userData.Split(',');

                    System.Web.HttpContext.Current.User =
                        new System.Security.Principal.GenericPrincipal(new FormsIdentity(newAuthTicket), roles);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (DBContext != null)
            {
                DBContext.Dispose();
                DBContext = null;
            }

            base.Dispose(disposing);
        }
    }
}