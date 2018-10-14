using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{   
    public abstract class Sensor
    {
        public int Id { get; set; }
        public String API { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public bool Envio_Siempre { get; set; }
        public int Frecuencia { get; set; }
        public DateTime Fecha_Lectura { get; set; }
        public bool Activo { get; set; }
    }
}
