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
            Activo = (bool)emp.Activo;
            Direccion = emp.Direccion;
            Fecha_Nac = emp.Fecha_Nac;
            Nombre = emp.Nombre;
            Tel = (int)emp.Tel;
            RUT_Empresa = emp.RUT_Empresa;
        }

        public Empleado getEntity()
        {
            Empleado nuevo = new Empleado();
            nuevo.Ci = Ci;
            nuevo.Activo = (bool)Activo;
            nuevo.Direccion = Direccion;
            nuevo.Fecha_Nac = (DateTime)Fecha_Nac;
            nuevo.Nombre = Nombre;
            nuevo.Tel = (int)Tel;
            nuevo.RUT_Empresa = (int)RUT_Empresa;
            return nuevo;

        }
    }
}
