using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SHARE.DTOs;
using SHARE.Entities;

namespace WebPresentation.Hubs
{
    public class ActualizacionLocation : Hub
    {
        public List<Evento> le { get; set; }
        public DTOLecturaHub lectura { get; set; }
        public void ActualizarLocation()
        {
            Clients.All.ActualizarLocation(lectura);
        }
        
        public void LanzarEvento()
        {
            Clients.All.MostrarNuevosEventosCoord(le);
        }
    }
}


    
