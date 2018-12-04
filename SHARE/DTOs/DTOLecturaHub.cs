using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.DTOs
{
    public class DTOLecturaHub
    {
        public LecturaSensor Lectura { get; set; }
        public int vehiculoRef { get; set; }
    }
}
