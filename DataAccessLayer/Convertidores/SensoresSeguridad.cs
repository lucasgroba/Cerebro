using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer {
    partial class SensoresSeguridad
    {
        IDALE_Vehiculo DAL = new DALE_Vehiculo();

        public void setModel(SensorSeguridad sen)
        {
            if (sen !=null && sen is SensorSeguridad)
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
                Alarma_Activa = sen.Alarma_Activa;
                Id_Vehiculo = sen.VehiculoRef.Id;
            }
        }


        public SensorSeguridad getEntity()
        {
            SensorSeguridad nuevo = new SensorSeguridad();
            nuevo.Id = Id;
            nuevo.API = Api;
            nuevo.Activo = (bool)Activo;
            nuevo.Frecuencia = (int)Frecuencia;
            nuevo.Fecha_Lectura = Fecha_Lectura;
            nuevo.Envio_Siempre = (bool)Envio_Siempre;
            nuevo.Maximo = (int)Maximo;
            nuevo.Minimo = (int)Minimo;
            nuevo.Alarma_Activa =(bool) Alarma_Activa;
            nuevo.VehiculoRef = DAL.GetVehiculo((int)this.Id_Vehiculo);
            return nuevo;
        }
    }
}
