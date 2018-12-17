using DataAccessLayer;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controladores
{
    public class BLEmpresa
    {
        IDALE_Empresa DALEmp = new DALE_Empresa();

        public void AltaEmpresa(Empresa emp)
        {
            DALEmp.AddEmpresa(emp);
        }

        public void UpdateEmpresa(Empresa emp)
        {
            DALEmp.UpdateEmpresa(emp);
        }

        public void DeleteEmpresa(int RUT)
        {
            DALEmp.DeleteEmpresa(RUT);
        }
        public Empresa GetEmpresa(int id)
        {
            return DALEmp.GetEmpresa(id);
        }

        public Empresa GetEmpresaxUser(string id)
        {   List<Usuario> usuarios = new List<Usuario>(); 
            List<Empresa> empresas = DALEmp.GetAllEmpresas();
            Empresa ret = new Empresa();
            foreach(Empresa e in empresas)
            {
                usuarios = e.Lista_Usuarios;
                foreach(Usuario u in usuarios)
                {
                    if(u.Id == id)
                    {
                        ret = e;
                        break;
                    }
                }
                if (ret.RUT == 0)
                {
                    break;
                }
            }
            return ret;
        }

        public List<Empresa> GetAllEmpresas()
        {
            return DALEmp.GetAllEmpresas();
        }

        public List<Evento> GetEventos(string id)
        {
            List<Evento> lista = new List<Evento>();
            List<Vehiculo> listav = GetEmpresaxUser(id).Lista_Vehiculos;
            if(listav != null)
            {
                foreach (Vehiculo v in listav)
                {
                    lista.AddRange(v.Lista_Eventos);
                }
            }

            return lista;

        }
    }
}
