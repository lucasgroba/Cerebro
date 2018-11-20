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
    }
}
