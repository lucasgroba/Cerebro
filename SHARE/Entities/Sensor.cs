using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{   
    public class Sensor
    {
        public int Id { get; set; }
        public String API { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public bool Envio_Siempre { get; set; }
        public int Frecuencia { get; set; }
        public bool Activo { get; set; }
        public String Tipo_Sensor { get; set;}
        public int VehiculoRef { get; set; }
        public List<LecturaSensor> Lecturas { get; set; }
        public LecturaSensor GetUltimaLectura() { 
           int idMax = this.Lecturas.Max(x=>x.Id);
           return this.Lecturas.Find(x=>x.Id == idMax); 
        }
    }
}
