using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class EmpresaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}