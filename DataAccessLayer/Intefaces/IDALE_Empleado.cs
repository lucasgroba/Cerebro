using System;
using System.Collections.Generic;
using SHARE.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDALE_Empleado
    {
        void AddEmpleado(Empleado emp);

        void DeleteEmpleado(int Id);

        void UpdateEmpleado(Empleado emp);

        List<Empleado> GetAllEmpleados();

        Empleado GetEmpleado(int Id);
    }
}
