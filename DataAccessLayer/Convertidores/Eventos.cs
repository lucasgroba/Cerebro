using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Eventos
    {
        IDALE_Tipo_Evento DAL_T_E = new DALE_Tipo_Evento();
        IDALE_Vehiculo DAL_V = new DALE_Vehiculo();
        public void setModel(Evento e)
        {
            this.Id = e.Id;
            this.Fecha = e.Fecha;
            this.Tipo_EventoRef = e.TipoEventoRef.Id;
            this.VehiculoRef = e.VehiculoRef;
            this.Latitud = e.Latitud;
            this.Longitud = e.Longitud;

        }
        public Evento getEntity()
        {
            Evento nuevo = new Evento();
            nuevo.Id = this.Id;
            nuevo.Fecha = (DateTime)this.Fecha;
            nuevo.TipoEventoRef = DAL_T_E.GetTipo_Evento(this.Tipo_EventoRef);
            nuevo.VehiculoRef = this.VehiculoRef;
            nuevo.Latitud = (float)this.Latitud;
            nuevo.Longitud = (float)this.Longitud;
            return nuevo;
        }
    }
}
