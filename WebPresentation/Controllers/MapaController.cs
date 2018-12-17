using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresentation.Controllers
{
<<<<<<< Updated upstream
    [Authorize(Roles = "SUPERADMIN,ADMINISTRADOR,VISUALIZADOR")]
=======
<<<<<<< Updated upstream
    //[Authorize(Roles = "S,A,V")]
=======
    
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    public class MapaController : Controller
    {
        BLEmpleado blemp = new BLEmpleado();
        BLEmpresa blEmpresa = new BLEmpresa();
        Empresa emp = new Empresa();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ControlFlota(int id)
        {
            List<Evento> listaEventos = new List<Evento>();
            string markers = "[";
<<<<<<< Updated upstream
            Empresa emp = blEmpresa.GetEmpresa(id);
=======
<<<<<<< Updated upstream
            Empresa emp = new UserRole().GetEmpresaUser(HttpContext.User.Identity.Name);
>>>>>>> Stashed changes
            foreach( Vehiculo v in emp.Lista_Vehiculos)
=======
            emp = new UserRole().GetEmpresaUser(HttpContext.User.Identity.Name);

            if (emp.Nombre == null) {
                return View("Index");
            }
            else
>>>>>>> Stashed changes
            {
                foreach (Vehiculo v in emp.Lista_Vehiculos)
                {
                    listaEventos.AddRange(v.Lista_Eventos);
                    markers += "{";
                    markers += "'title': ' ";
                    markers += v.Marca;
                    markers += "  " + v.Modelo + "' ,";
                    markers += "'description':'" + blemp.GetEmpleado(v.Id_Empleado).Nombre + "', ";
                    foreach (Sensor s in v.Lista_Sensores)
                    {
                        if (s.Tipo_Sensor.Equals("G"))
                        {
                            LecturaSensor l = s.GetUltimaLectura();
                            markers += "'lat': '" + l.Latitud.ToString() + " ',";
                            markers += "'lng': '" + l.Longitud.ToString() + "',";
                            markers += "'id': '" + v.Id.ToString() + "'}";

                        }

                    }
                    if (!v.Equals(emp.Lista_Vehiculos.Last()))
                    {
                        markers += " , ";
                    }

                }
                markers += "]";
                ViewBag.Markers = markers;
                ViewBag.Eventos = listaEventos;
                return View();
            }
            
        }
    }
}