using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EVENTUM.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingreso()
        {
            return View();
        }
    }
}