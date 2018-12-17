using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SHARE.Entities;
using WebPresentation.Models;
using BusinessLayer.Controladores;
using System.Web.Security;

namespace WebPresentation.Controllers
{
<<<<<<< Updated upstream
    [Authorize(Roles = "A,V")]
=======
<<<<<<< Updated upstream
    //[Authorize(Roles = "A,V")]
=======
   
>>>>>>> Stashed changes
>>>>>>> Stashed changes

    public class EventoController : Controller
    {
        private BLEmpresa  db = new BLEmpresa();

        // GET: Eventoes
        public async Task<ActionResult> Index()
        {
            return View(db.GetEventos(User.Identity.Name));
        }

        
    }
}
