using DataAccessLayer.Convertidores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controladores
{
    public class DALE_Tipo_Evento : IDALE_Tipo_Evento
    {
        public void AddTipo_Evento(Tipo_Evento eve)
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                if (eve != null)
                {
                    Tipo_Eventos nuevo = new Tipo_Eventos();
                    nuevo.setModel(eve);
                    db.Tipo_Evento.Add(nuevo);
                }
            }
        }

        public void DeleteTipo_Evento(int id)
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                db.Tipo_Evento.Remove(db.Tipo_Evento.Find(id));
                db.SaveChanges();
            }
        }

        public List<Tipo_Evento> GetAllTipo_Evento()
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                var ListEmp = (from e in db.Tipo_Evento select e).ToList();
                return new ConvertType().Tipo_EventoDBToTipo_Evento(ListEmp);
            }
        }

        public Tipo_Evento GetTipo_Evento(int id)
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                var ListEmp = (from e in db.Tipo_Evento where e.Id==id select e).ToList();
                return new ConvertType().Tipo_EventoDBToTipo_Evento(ListEmp).First();
            }
        }

        public void UpdateTipo_Evento(Tipo_Evento eve)
        {
            DeleteTipo_Evento(eve.Id);
            AddTipo_Evento(eve);
        }
    }
}
