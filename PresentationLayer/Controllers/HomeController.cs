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
            //ALTA LECTURA SENSOR
            //LecturaSensor nuevo = new LecturaSensor();

            //nuevo.Aceleracion = 10;
            //nuevo.Alarma_Activa = true;
            //nuevo.FechaLectura = new DateTime(2018,11,2);
            //nuevo.Latitud = (float)1.2323;
            //nuevo.Longitud = (float)1.434312;
            //nuevo.Nivel_Combustible = 10;
            //nuevo.Presion = 23;
            //nuevo.SensorRef = 1;
            //nuevo.Temperatura = 90;
            //nuevo.Velocidad = 100;
            //BLLecturaSensor lsen = new BLLecturaSensor();
            //lsen.AltaLectura(nuevo);
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