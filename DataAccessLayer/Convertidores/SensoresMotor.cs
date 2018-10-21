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
    partial class SensoresMotor
    {
        IDALE_Vehiculo DAL = new DALE_Vehiculo();

        public void setModel(SensorMotor sen)
        {
            if (sen != null && sen is SensorMotor)
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
                Presion = sen.Presion;
                Temperatura = sen.Temperatura;
                Id_Vehiculo = sen.VehiculoRef.Id;
            }

        }

        public SensorMotor getEntity()
        {
            SensorMotor nuevo = new SensorMotor();
            nuevo.Id = Id;
            nuevo.API = Api;
            nuevo.Activo = (bool)Activo;
            nuevo.Frecuencia = (int)Frecuencia;
            nuevo.Fecha_Lectura = Fecha_Lectura;
            nuevo.Envio_Siempre = (bool)Envio_Siempre;
            nuevo.Maximo = (int)Maximo;
            nuevo.Minimo = (int)Minimo;
            nuevo.Presion = (Double)Presion;
            nuevo.Temperatura = (Double)Temperatura;
            nuevo.VehiculoRef = DAL.GetVehiculo((int)this.Id_Vehiculo);
            return nuevo;
        }

    }
}
