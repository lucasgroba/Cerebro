//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class LecturaSensores
    {
        public System.DateTime Fecha_Lectura { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Velocidad { get; set; }
        public double Aceleracion { get; set; }
        public double Temperatura { get; set; }
        public double Presion { get; set; }
        public int Nivel_Combustible { get; set; }
        public bool Alarma_Activa { get; set; }
        public Nullable<int> Id_Sensor { get; set; }
        public int Id { get; set; }
    }
}
