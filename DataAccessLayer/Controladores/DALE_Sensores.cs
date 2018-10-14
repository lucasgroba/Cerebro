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
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                if (sen is SensorGPS)
                {
                    SensorGPS vehi = (SensorGPS)sen;
                    SensoresGPS nuevo = new SensoresGPS();
                    nuevo.Id = vehi.Id;
                    nuevo.Api = vehi.API;
                    nuevo.Activo = vehi.Activo;
                    nuevo.Activo = vehi.Activo;
                    nuevo.Frecuencia = vehi.Frecuencia;
                    nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                    nuevo.Envio_Siempre = vehi.Envio_Siempre;
                    nuevo.Maximo = vehi.Maximo;
                    nuevo.Minimo = vehi.Minimo;
                    nuevo.Aceleracion = vehi.Aceleracion;
                    nuevo.Velocidad = vehi.Velocidad;
                    nuevo.Latitud = vehi.Latitud;
                    nuevo.Longitud = vehi.Longitud;
                    db.Sensores.Add(nuevo);
                }
                else
                {
                    if (sen is SensorCombustible)
                    {
                        SensorCombustible vehi = (SensorCombustible)sen;
                        SensoresCombustible nuevo = new SensoresCombustible();
                        nuevo.Id = vehi.Id;
                        nuevo.Api = vehi.API;
                        nuevo.Activo = vehi.Activo;
                        nuevo.Activo = vehi.Activo;
                        nuevo.Frecuencia = vehi.Frecuencia;
                        nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                        nuevo.Envio_Siempre = vehi.Envio_Siempre;
                        nuevo.Maximo = vehi.Maximo;
                        nuevo.Minimo = vehi.Minimo;
                        nuevo.Nivel_Combustible = vehi.Nivel;
                        db.Sensores.Add(nuevo);
                    }
                    else
                    {
                        if (sen is SensorMotor)
                        {
                            SensorMotor vehi = (SensorMotor)sen;
                            SensoresMotor nuevo = new SensoresMotor();
                            nuevo.Id = vehi.Id;
                            nuevo.Api = vehi.API;
                            nuevo.Activo = vehi.Activo;
                            nuevo.Activo = vehi.Activo;
                            nuevo.Frecuencia = vehi.Frecuencia;
                            nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                            nuevo.Envio_Siempre = vehi.Envio_Siempre;
                            nuevo.Maximo = vehi.Maximo;
                            nuevo.Minimo = vehi.Minimo;
                            nuevo.Presion = vehi.Presion;
                            nuevo.Temperatura = vehi.Temperatura;
                            db.Sensores.Add(nuevo);
                        }
                        else
                        {
                            if (sen is SensorSeguridad)
                            {
                                SensorSeguridad vehi = (SensorSeguridad)sen;
                                SensoresSeguridad nuevo = new SensoresSeguridad();
                                nuevo.Id = vehi.Id;
                                nuevo.Api = vehi.API;
                                nuevo.Activo = vehi.Activo;
                                nuevo.Activo = vehi.Activo;
                                nuevo.Frecuencia = vehi.Frecuencia;
                                nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                                nuevo.Envio_Siempre = vehi.Envio_Siempre;
                                nuevo.Maximo = vehi.Maximo;
                                nuevo.Minimo = vehi.Minimo;
                                nuevo.Alarma_Activa = nuevo.Alarma_Activa;
                                db.Sensores.Add(nuevo);
                            }
                        }
                    }
                }
            }
        }

        public void DeleteSensor(int id)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                db.Sensores.Remove(db.Sensores.Find(id));
                db.SaveChanges();
            }
        }

        public List<Sensor> GetAllSensor()
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Sensores select e).ToList();
                return new ConvertType().SensorDBToSensor(ListEmp);
            }
        }

        public Sensor GetSensor(int id)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
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
