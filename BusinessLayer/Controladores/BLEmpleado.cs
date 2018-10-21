using DataAccessLayer;
using DataAccessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controladores
{
    class BLEmpleado
    {
        IDALE_Empleado DALEmp = new DALE_Empleado();

        public void AltaEmpleado(Empleado emp)
        {
            DALEmp.AddEmpleado(emp);
        }

        public void UpdateEmpleado(Empleado emp)
        {
            DALEmp.UpdateEmpleado(emp);
        }

        public void DeleteEmpleado(int id)
        {
            DALEmp.DeleteEmpleado(id);
        }
    }
}
