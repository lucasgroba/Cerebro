using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SHARE.Entities;

namespace WebPresentation.Hubs
{
    public class EventoHub : Hub
    {
        public void LanzarEvento(List<Evento> le, float lat, float lng)
        {
            Clients.All.MostrarNuevosEventosCoord(le,lat,lng);
        }

        public void LanzarEvento(List<Evento> le)
        {
            Clients.All.MostrarNuevosEventos(le);
        }
    }
}