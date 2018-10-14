using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Empleado
    {
        public int Ci { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public int Tel { get; set; }
        public String Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
