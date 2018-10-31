using DataAccessLayer.Controladores;
using DataAccessLayer.Convertidores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Sensores
    {
        IDALE_Vehiculo DALV = new DALE_Vehiculo();

        public Sensor getEntity()
        {
            Sensor nuevo = new Sensor();
            nuevo.Activo = (bool)this.Activo;
            nuevo.API = this.Api;
            nuevo.Envio_Siempre = (bool)this.Envio_Siempre;
            nuevo.Frecuencia = (int)this.Frecuencia;
            nuevo.Id = this.Id;
            nuevo.Maximo = (int)this.Maximo;
            nuevo.Minimo = (int)this.Minimo;
            nuevo.Tipo_Sensor = this.Tipo_Sensor;
            nuevo.VehiculoRef = DALV.GetVehiculo((int)this.Id_Vehiculo);
            nuevo.Lecturas = new ConvertType().LecturaDBToLectura((List<LecturaSensores>) this.LecturaSensores);
            return nuevo;
        }

        public void setModel(Sensor sen)
        {
            this.Id = sen.Id;
            this.Id_Vehiculo = sen.VehiculoRef.Id;
            this.Activo = sen.Activo;
            this.Api = sen.API;
            this.Envio_Siempre = sen.Envio_Siempre;
            this.Frecuencia = sen.Frecuencia;
            this.Maximo = sen.Maximo;
            this.Minimo = sen.Minimo;
            this.Tipo_Sensor = sen.Tipo_Sensor;
            this.LecturaSensores = new ConvertType().LecturaToLecturaDB( sen.Lecturas);
        }


    }
}
