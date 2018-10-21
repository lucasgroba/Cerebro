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
    partial class SensoresCombustible
    {
        IDALE_Vehiculo DAL = new DALE_Vehiculo();

        public void setModel(SensorCombustible sen)
        {
            if (sen != null && sen is SensorCombustible)
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
                Nivel_Combustible = sen.Nivel;
                Id_Vehiculo = sen.VehiculoRef.Id;
            }
        }
        
        public SensorCombustible getEntity()
        {
            SensorCombustible nuevo = new SensorCombustible();
            nuevo.Id = Id;
            nuevo.API = Api;
            nuevo.Activo = (bool)Activo;
            nuevo.Frecuencia = (int)Frecuencia;
            nuevo.Fecha_Lectura = Fecha_Lectura;
            nuevo.Envio_Siempre = (bool)Envio_Siempre;
            nuevo.Maximo = (int)Maximo;
            nuevo.Minimo = (int)Minimo;
            nuevo.Nivel = (int)Nivel_Combustible;
            nuevo.VehiculoRef = DAL.GetVehiculo((int)this.Id_Vehiculo);
            return nuevo;
        }

    }
}
