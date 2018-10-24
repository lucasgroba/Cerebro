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

    }
}
