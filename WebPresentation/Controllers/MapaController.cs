using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
    public class MapaController : Controller
    {
        BLEmpleado blemp = new BLEmpleado();
        BLEmpresa blEmpresa = new BLEmpresa();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ControlFlota(int id)
        {
            string markers = "[";
            Empresa emp = blEmpresa.GetEmpresa(id);
            foreach( Vehiculo v in emp.Lista_Vehiculos)
            {
                markers += "{";
                markers += "title: ' ";
                markers += v.Marca;
                markers +="  "+ v.Modelo+"' ,";
                markers += "Description:'" + blemp.GetEmpleado(v.Id_Empleado).Nombre +"', ";
                foreach(Sensor s in v.Lista_Sensores)
                {
                    if (s.Tipo_Sensor.Equals("G"))
                    {
                        LecturaSensor l= s.GetUltimaLectura();
                        markers += "lat: '" + l.Latitud.ToString()+" ',";
                        markers += "lng: '" + l.Longitud.ToString() + "' }";
                    }

                }
                if(!v.Equals(emp.Lista_Vehiculos.Last()))
                {
                    markers += " , ";
                }
            }
            markers += "]";
            ViewBag.Markers = markers;
            return View();
        }
    }
}