using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Empleados
    {
        
        public void setModel(Empleado emp)
        {
            Ci = emp.Ci;
            Activo = emp.Activo;
            Direccion = emp.Direccion;
            Nombre = emp.Nombre;
            Tel = emp.Tel;
        }

        public Empleado getEntity()
        {
            Empleado nuevo = new Empleado();
            nuevo.Ci = Ci;
            nuevo.Activo = (bool)Activo;
            nuevo.Direccion = Direccion;
            nuevo.Nombre = Nombre;
            nuevo.Tel = (int)Tel;
            nuevo.RUT_Empresa = (int)this.RUT_Empresa;
            return nuevo;

        }
    }
}
