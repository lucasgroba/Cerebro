using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public int Id_Empleado { get; set; }
        public bool Activo { get; set; }
        public List<Sensor> Lista_Sensores { get; set; }
        public List<Tipo_Evento> Lista_Tipo_Eventos { get; set; }

    }
}
