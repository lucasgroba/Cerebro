using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Convertidores;
using SHARE.Entities;

namespace DataAccessLayer.Controladores
{
    public class DALE_Empleado : IDALE_Empleado
    {
        public void AddEmpleado(Empleado emp)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                if (emp != null)
                {
                    Empleado empDB = emp;
                    Empleados nuevo = new Empleados();
                    nuevo.Activo = empDB.Activo;
                    nuevo.Nombre = empDB.Nombre;
                    nuevo.Ci = empDB.Ci;
                    nuevo.Direccion = empDB.Direccion;
                    nuevo.Fecha_Nac = empDB.Fecha_Nac;
                    nuevo.Tel = empDB.Tel;
                    db.Empleados.Add(nuevo);
                }
            }
        }

        public void DeleteEmpleado(int Id)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                db.Empleados.Remove(db.Empleados.Find(Id));
                db.SaveChanges();

            }
        }

        public List<Empleado> GetAllEmpleados()
        {
            List<Empleado> listaRetorno = new List<Empleado>();
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Empleados select e).ToList();
                return new ConvertType().EmpleadoDBToEmpleado(ListEmp);
            }
        }

        public Empleado GetEmpleado(int Id)
        {
            List<Empleado> listaRetorno = new List<Empleado>();
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Empleados where e.Ci == Id select e).ToList();
                return new ConvertType().EmpleadoDBToEmpleado(ListEmp).First();
            }
        }

        public void UpdateEmpleado(Empleado emp)
        {
            DeleteEmpleado(emp.Ci);
            AddEmpleado(emp);
        }
    }
}
