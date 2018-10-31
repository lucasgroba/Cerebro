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
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                if (emp != null)
                {
                    Empleados nuevo = new Empleados();
                    nuevo.setModel(emp);
                    db.Empleados.Add(nuevo);
                }
            }
        }

        public void DeleteEmpleado(int Id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.Empleados.Remove(db.Empleados.Find(Id));
                db.SaveChanges();

            }
        }

        public List<Empleado> GetAllEmpleados()
        {
            List<Empleado> listaRetorno = new List<Empleado>();
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Empleados select e).ToList();
                return new ConvertType().EmpleadoDBToEmpleado(ListEmp);
            }
        }

        public Empleado GetEmpleado(int Id)
        {
            List<Empleado> listaRetorno = new List<Empleado>();
            using (CEREBROEntities1 db = new CEREBROEntities1())
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
