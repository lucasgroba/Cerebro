using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public Tipo_Evento TipoEventoRef { get; set; }
        public int VehiculoRef { get; set; }
    }
}
