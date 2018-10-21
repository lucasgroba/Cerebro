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
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                if (sen is SensorGPS)
                {
                    SensorGPS vehi = (SensorGPS)sen;
                    SensoresGPS nuevo = new SensoresGPS();
                    nuevo.setModel(vehi);
                    db.Sensores.Add(nuevo);
                }
                else
                {
                    if (sen is SensorCombustible)
                    {
                        SensorCombustible vehi = (SensorCombustible)sen;
                        SensoresCombustible nuevo = new SensoresCombustible();
                        nuevo.setModel(vehi);
                        db.Sensores.Add(nuevo);
                    }
                    else
                    {
                        if (sen is SensorMotor)
                        {
                            SensorMotor vehi = (SensorMotor)sen;
                            SensoresMotor nuevo = new SensoresMotor();
                            nuevo.setModel(vehi);
                            db.Sensores.Add(nuevo);
                        }
                        else
                        {
                            if (sen is SensorSeguridad)
                            {
                                SensorSeguridad vehi = (SensorSeguridad)sen;
                                SensoresSeguridad nuevo = new SensoresSeguridad();
                                nuevo.setModel(vehi);
                                db.Sensores.Add(nuevo);
                            }
                        }
                    }
                }
            }
        }

        public void DeleteSensor(int id)
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                db.Sensores.Remove(db.Sensores.Find(id));
                db.SaveChanges();
            }
        }

        public List<Sensor> GetAllSensor()
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
            {
                var ListEmp = (from e in db.Sensores select e).ToList();
                return new ConvertType().SensorDBToSensor(ListEmp);
            }
        }

        public Sensor GetSensor(int id)
        {
            using (CEREBRO_Entities1 db = new CEREBRO_Entities1())
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
