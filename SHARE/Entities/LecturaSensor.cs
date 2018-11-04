using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARE.Entities
{
    public class LecturaSensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaLectura { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public float Aceleracion { get; set; }
        public float Temperatura { get; set; }
        public float Presion { get; set; }
        public bool Alarma_Activa { get; set; }
        public int Velocidad { get; set; }
        public int Nivel_Combustible { get; set; }
        public int SensorRef { get; set; }



    }
}
