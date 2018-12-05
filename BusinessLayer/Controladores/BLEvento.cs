using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Controladores
{
    public class BLEvento
    {
        IDALE_Evento DAL_E = new DALE_Evento();
        BLVehiculo DAL_V = new BLVehiculo();

        public void AltaEvento(Evento e)
        {
            DAL_E.AddEvento(e);
        }

        public void UpdateEvento(Evento e)
        {
            DAL_E.UpdateEvento(e);
        }

        public void DeleteEvento(int id)
        {
            DAL_E.DeleteEvento(id);
        }
        public Evento GetEvento(int id)
        {
            return DAL_E.GetEvento(id);
        }
        public List<Evento> GetAllEvento()
        {
            return DAL_E.GetAllEvento();
        }

        public List<Evento> GetAllEventoxEmp(int id)
        {
            List<Vehiculo> listav = DAL_V.GetAllVehiculosxEmp(id);
            return null;
        }

        public DateTime GetDateUltimoEvento(int idV, Tipo_Evento TE)
        {
            List<Evento> lista;
            lista = this.GetAllEvento().FindAll(x => x.TipoEventoRef == TE && x.VehiculoRef == idV);
            if(lista.Count != 0)
            {
                int idMax = lista.Max(x => x.Id);
                return lista.Find(x => x.Id == idMax).Fecha;
            }
            else
            {
                return DateTime.Now;
            }
            
        }
    }
}
