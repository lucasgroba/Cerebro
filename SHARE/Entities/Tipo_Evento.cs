using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Tipo_Evento
    {
        public  int Id { get; set; }
        public int Periodo { get; set; }
        public int Maximo { get; set; }
        public int Minimo { get; set; }
        public String Accion { get; set; }
        public bool Activo { get; set; }
    }
}
