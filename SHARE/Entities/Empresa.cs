using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Empresa
    {
        public int RUT { get; set; }
        public String Nombre { get; set; }
        public Double Zona_Longitud { get; set; }
        public Double Zona_Latitud { get; set; }
        public bool Activo { get; set;}
        public List<Empleado> Lista_Empleados { get; set; }
        public List<Vehiculo> Lista_Vehiculos { get; set; }
        public List<Usuario> Lista_Usuarios { get; set; }

    }
}
