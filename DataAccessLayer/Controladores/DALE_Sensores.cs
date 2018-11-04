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
    public class DALE_Sensores : IDALE_Sensor
    {
        public void AddSensor(Sensor sen)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Sensores nuevo = new Sensores();
                nuevo.setModel(sen);
                db.Sensores.Add(nuevo);
                db.SaveChanges();
            }
        }

        public void DeleteSensor(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.Sensores.Remove(db.Sensores.Find(id));
                db.SaveChanges();
            }
        }

        public List<Sensor> GetAllSensor()
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Sensores select e).ToList();
                return new ConvertType().SensorDBToSensor(ListEmp);
            }
        }

        public Sensor GetSensor(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Sensores where e.Id == id select e).ToList();
                return new ConvertType().SensorDBToSensor(ListEmp).First();
            }
        }

        public void UpdateSensor(Sensor sen)
        {
            DeleteSensor(sen.Id);
            AddSensor(sen);
        }
    }
}
