using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALE_Evento
    {
        void AddEvento(Evento e);

        void DeleteEvento(int id);

        void UpdateEvento(Evento e);

        List<Evento> GetAllEvento();

        Evento GetEvento(int id);
    }
}
