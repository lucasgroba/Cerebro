using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class Usuario
    {
        public String Id { get; set; }
        public String mail { get; set; }
        public String Pass { get; set; }
        public String Tipo_User { get; set; }
        public int EmpresaRef { get; set; }

    }
}
