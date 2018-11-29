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
    public class DALE_Evento : IDALE_Evento
    {
        public void AddEvento(Evento e)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                if (e != null)
                {
                    Eventos nuevo = new Eventos();
                    nuevo.setModel(e);
                    db.Eventos.Add(nuevo);
                    db.SaveChanges();

                }
            }
        }

        public void DeleteEvento(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.Eventos.Remove(db.Eventos.Find(id));
                db.SaveChanges();

            }
        }

        public List<Evento> GetAllEvento()
        {
            
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var List = (from e in db.Eventos select e).ToList();
                return new ConvertType().EventoDBToEvento(List);
            }
        }

        public Evento GetEvento(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var List = (from e in db.Eventos where e.Id == id select e).ToList();
                return new ConvertType().EventoDBToEvento(List).First();
            }
        }

        public void UpdateEvento(Evento e)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Eventos ev = db.Eventos.Find(e.Id);
                ev.setModel(e);
                db.Eventos.Attach(ev);
                db.SaveChanges();
                
            }
        }
    }
}
