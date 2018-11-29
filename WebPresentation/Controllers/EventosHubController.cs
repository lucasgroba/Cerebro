using Microsoft.AspNet.SignalR;
using SHARE.DTOs;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPresentation.Hubs;

namespace WebPresentation.Controllers
{
    public class EventosHubController : Controller
    {
        
        // POST: EventosHub/Create
        [HttpPost]
        public void Create(List<Evento> e)
        {
            try
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<ActualizacionLocation>();
                hubContext.Clients.All.MostrarNuevosEventosCoord(e);

            }
            catch
            {
                
            }
        }


    }
}
