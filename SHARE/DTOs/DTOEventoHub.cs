using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHARE.DTOs
{
    public class DTOEventoHub
    {
        public List<Evento> ListaEventos { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }

        public DTOEventoHub(List<Evento> le, float lat, float lng)
        {
            this.ListaEventos = le;
            this.Lat = lat;
            this.Lng = lng;
        }

        public DTOEventoHub() { }
    }
}