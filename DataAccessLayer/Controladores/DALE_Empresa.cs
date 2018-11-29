using DataAccessLayer.Convertidores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccessLayer
{
    public class DALE_Empresa : IDALE_Empresa
    {

        public void AddEmpresa(Empresa emp)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                if (emp != null)
                {
                    Empresas nuevo = new Empresas();
                    nuevo.setModel(emp);
                    db.Empresas.Add(nuevo);
                    db.SaveChanges();

                }
            }
        }

        public void DeleteEmpresa(int RUT)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.Empresas.Remove(db.Empresas.Find(RUT));
                db.SaveChanges();

            }
        }

        public List<Empresa> GetAllEmpresas()
        {
            List<Empresa> listaRetorno = new List<Empresa>();
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Empresas select e).ToList();
                return new ConvertType().EmpresaDBToEmpresa(ListEmp);
            }

        }

        public Empresa GetEmpresa(int RUT)
        {
            List<Empresa> listaRetorno = new List<Empresa>();
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Empresas where e.RUT == RUT select e ).ToList();
                return new ConvertType().EmpresaDBToEmpresa(ListEmp).First();
            }
        }

        public void UpdateEmpresa(Empresa emp)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Empresas e = db.Empresas.Find(emp.RUT);
                e.setModel(emp);
                db.Empresas.Attach(e);
                db.SaveChanges();

            }
        }



       
    }
}
