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
    
    public partial class Sensores
    {
        public int Id { get; set; }
        public string Api { get; set; }
        public Nullable<int> Maximo { get; set; }
        public Nullable<int> Minimo { get; set; }
        public Nullable<bool> Envio_Siempre { get; set; }
        public Nullable<int> Frecuencia { get; set; }
        public System.DateTime Fecha_Lectura { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> Id_Vehiculo { get; set; }
    
        public virtual Vehiculos Vehiculos { get; set; }
    }
}
