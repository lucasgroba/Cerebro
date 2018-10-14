using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class SensorGPS : Sensor
    {
        public Double Latitud { get; set; }
        public Double Longitud { get; set; }
        public Double Aceleracion { get; set; }
        public int Velocidad { get; set; }

    }
}
