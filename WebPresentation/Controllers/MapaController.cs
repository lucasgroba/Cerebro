using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    public class MapaController : Controller
    {
        // GET: Mapa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormMap()
        {
            return View();
        }
    }
}