namespace EVENTUM.Controllers
{
    using EVENTUM.Comun;
    using EVENTUM.Models;
    using System.Net.Mail;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class HomeController : ClsUtilitarios
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
       
    }
}