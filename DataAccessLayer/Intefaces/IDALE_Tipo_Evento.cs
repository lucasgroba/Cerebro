using System;
using System.Collections.Generic;
using SHARE.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALE_Tipo_Evento
    {
        void AddTipo_Evento(SHARE.Entities.Tipo_Evento eve);

        void DeleteTipo_Evento(int id);

        void UpdateTipo_Evento(SHARE.Entities.Tipo_Evento eve);

        List<SHARE.Entities.Tipo_Evento> GetAllTipo_Evento();

        SHARE.Entities.Tipo_Evento GetTipo_Evento(int id);
    }
}
