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
        IDALE_Empresa IDL = new DALE_Empresa();
        public void setModel(Empleado emp)
        {
            Ci = emp.Ci;
            Activo = emp.Activo;
            Direccion = emp.Direccion;
            Nombre = emp.Nombre;
            RUT_Empresa = emp.EmpresaRef.RUT;
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
            nuevo.EmpresaRef = IDL.GetEmpresa((int)this.RUT_Empresa);
            return nuevo;

        }
    }
}
