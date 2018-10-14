using DataAccessLayer.Convertidores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALE_Empresa : IDALE_Empresa
    {

        public void AddEmpresa(Empresa emp)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                if (emp != null)
                {
                    Empresa empDB = emp;
                    Empresas nuevo = new Empresas();
                    nuevo.RUT = empDB.RUT;
                    nuevo.Nombre = empDB.Nombre;
                    nuevo.Zona_Latitud = empDB.Zona_Latitud;
                    nuevo.Zona_Longitud = empDB.Zona_Longitud;
                    nuevo.Activo = empDB.Activo;
                    db.Empresas.Add(nuevo);
                    throw new NotImplementedException();
                }
            }
        }

        public void DeleteEmpresa(int RUT)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                db.Empresas.Remove(db.Empresas.Find(RUT));
                db.SaveChanges();

            }
        }

        public List<Empresa> GetAllEmpresas()
        {
            List<Empresa> listaRetorno = new List<Empresa>();
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Empresas select e).ToList();
                return new ConvertType().EmpresaDBToEmpresa(ListEmp);
            }

        }

        public Empresa GetEmpresa(int RUT)
        {
            List<Empresa> listaRetorno = new List<Empresa>();
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Empresas where e.RUT == RUT select e ).ToList();
                return new ConvertType().EmpresaDBToEmpresa(ListEmp).First();
            }
        }

        public void UpdateEmpresa(Empresa emp)
        {
            DeleteEmpresa(emp.RUT);
            AddEmpresa(emp);
        }



       
    }
}
