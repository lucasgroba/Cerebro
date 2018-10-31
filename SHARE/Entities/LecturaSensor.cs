using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class LecturaSensor
    {
        public DateTime FechaLectura { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public float Aceleracion { get; set; }
        public float Temperatura { get; set; }
        public float Presion { get; set; }
        public bool Alarma_Activa { get; set; }
        public int Velocidad { get; set; }
        public int Nivel_Combustible { get; set; }
        public Sensor SensorRef { get; set; }



    }
}
