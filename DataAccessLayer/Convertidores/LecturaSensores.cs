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
    partial class LecturaSensores
    {
        IDALE_Sensor IDL = new DALE_Sensores();

        public LecturaSensor getEntity() {
            LecturaSensor sen = new LecturaSensor();
            sen.Id = this.Id;
            sen.Longitud = (float)this.Longitud;
            sen.Aceleracion = (float)this.Aceleracion;
            sen.Alarma_Activa = (bool)this.Alarma_Activa;
            sen.FechaLectura = (DateTime)this.Fecha_Lectura;
            sen.Latitud = (float)this.Latitud;
            sen.Nivel_Combustible = (int)this.Nivel_Combustible;
            sen.Presion = (float)this.Presion;
            sen.SensorRef = (int)this.Id_Sensor;
            sen.Temperatura = (float)this.Temperatura;
            sen.Velocidad = (int) this.Velocidad;
            return sen;
        }

        public void setModel(LecturaSensor lec) {
            this.Id = lec.Id;
            this.Aceleracion = lec.Aceleracion;
            this.Alarma_Activa = lec.Alarma_Activa;
            this.Fecha_Lectura = lec.FechaLectura;
            this.Latitud = lec.Latitud;
            this.Nivel_Combustible = lec.Nivel_Combustible;
            this.Presion = lec.Presion;
            this.Id_Sensor = lec.SensorRef;
            this.Temperatura = lec.Temperatura;
            this.Velocidad = lec.Velocidad;
            this.Longitud = lec.Longitud;
        }

    }
}
