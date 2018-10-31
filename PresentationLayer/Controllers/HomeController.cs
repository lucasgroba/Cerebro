using SHARE.Entities;
using BusinessLayer.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //ALTA  EMPRESA
            //Empresa emp = new Empresa();
            //emp.Activo = true;
            //emp.Nombre = "LGROBA_ENTERPRISE";
            //emp.RUT = 1;
            //emp.Zona_Latitud = 1.2222;
            //emp.Zona_Longitud = 1.33333;
            //BLEmpresa BLEmp = new BLEmpresa();
            //BLEmp.AltaEmpresa(emp);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}