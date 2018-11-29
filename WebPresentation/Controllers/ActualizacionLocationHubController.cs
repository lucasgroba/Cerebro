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
    public class ActualizacionLocationHubController : Controller
    {
       

        

        // POST: ActualizacionLocationHub/Create
        [HttpPost]
        public void Create(DTOLecturaHub lec)
        {
            try
            {

                var hubContext = GlobalHost.ConnectionManager.GetHubContext<ActualizacionLocation>();
                hubContext.Clients.All.ActualizarLocation(lec);
            }
            catch
            {
                
            }
        }

        
    }
}
