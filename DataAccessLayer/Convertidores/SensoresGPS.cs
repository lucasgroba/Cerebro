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
    partial class SensoresGPS
    {
        IDALE_Vehiculo DAL = new DALE_Vehiculo();
        public void setModel(SensorGPS sen)
        {
            if (sen != null && sen is SensorGPS)
            {
                Id = sen.Id;
                Api = sen.API;
                Activo = sen.Activo;
                Activo = sen.Activo;
                Frecuencia = sen.Frecuencia;
                Fecha_Lectura = sen.Fecha_Lectura;
                Envio_Siempre = sen.Envio_Siempre;
                Maximo = sen.Maximo;
                Minimo = sen.Minimo;
                Aceleracion = sen.Aceleracion;
                Velocidad = sen.Velocidad;
                Latitud = sen.Latitud;
                Longitud = sen.Longitud;
                Id_Vehiculo = sen.VehiculoRef.Id;
            }
        }

        public SensorGPS getEntity()
        {

            SensorGPS nuevo = new SensorGPS();
            nuevo.Id = Id;
            nuevo.API = Api;
            nuevo.Activo = (bool)Activo;
            nuevo.Frecuencia = (int)Frecuencia;
            nuevo.Fecha_Lectura = Fecha_Lectura;
            nuevo.Envio_Siempre = (bool)Envio_Siempre;
            nuevo.Maximo = (int)Maximo;
            nuevo.Minimo = (int)Minimo;
            nuevo.Aceleracion = (Double)Aceleracion;
            nuevo.Velocidad = (int)Velocidad;
            nuevo.Latitud = (Double)Latitud;
            nuevo.Longitud = (Double)Longitud;
            nuevo.VehiculoRef = DAL.GetVehiculo((int)this.Id_Vehiculo);
            return nuevo;

        }
    }
}
