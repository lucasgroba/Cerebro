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
    partial class Tipo_Eventos
    {
        IDALE_Vehiculo DAL = new DALE_Vehiculo();

        public void setModel(Tipo_Evento eve)
        {
            Accion = eve.Accion;
            Activo = eve.Activo;
            Id = eve.Id;
            Maximo = eve.Maximo;
            Minimo = eve.Minimo;
            Periodo = eve.Periodo;
            Nombre = eve.Nombre;
            Tipo_Sensor = eve.TipoLectura;
            this.setListModelVehiculos(eve.Lista_IDVehiculo);
        }

        public void setListModelVehiculos(List<int> Lista_Vehiculos)
        {   List<Vehiculos> lista = new List<Vehiculos>();
            foreach(int veh in Lista_Vehiculos)
            {
                
                Vehiculos nuevo = new Vehiculos();
                nuevo.setModel(DAL.GetVehiculo(veh));
                lista.Add(nuevo);
            }
            this.Vehiculos= lista;
        }

        public Tipo_Evento getEntity()
        {
            Tipo_Evento nuevo = new Tipo_Evento();
            nuevo.Accion = Accion;
            nuevo.Activo = (bool)Activo;
            nuevo.Id = Id;
            nuevo.Maximo = (int)Maximo;
            nuevo.Minimo = (int)Minimo;
            nuevo.Periodo = (int)Periodo;
            nuevo.Nombre = Nombre;
            nuevo.TipoLectura = Tipo_Sensor;
            nuevo.Lista_IDVehiculo = this.getEntityListaVehiculos();
            return nuevo;
        }

        public List<int> getEntityListaVehiculos()
        {
            List<int> lista = new List<int>();
            foreach (Vehiculos v in this.Vehiculos)
            {
                lista.Add(v.Id);
            }
            return lista;
        }
    }
}
