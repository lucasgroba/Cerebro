using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Controladores
{
    public class BLTipo_Evento
    {

        IDALE_Tipo_Evento DALEmp = new DALE_Tipo_Evento();

        public void AltaVehiculo(Tipo_Evento eve)
        {
            DALEmp.AddTipo_Evento(eve);
        }

        public void UpdateTipo_Evento(Tipo_Evento eve)
        {
            DALEmp.UpdateTipo_Evento(eve);
        }

        public void DeleteTipo_Evento(int id)
        {
            DALEmp.DeleteTipo_Evento(id);
        }

        public Tipo_Evento GetTipo_Evento (int id)
        {
           return DALEmp.GetTipo_Evento(id);
        }

        public List<Tipo_Evento> GetAllTipo_Eventos()
        {
            return DALEmp.GetAllTipo_Evento();
        }
    }
}
