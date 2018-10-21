using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Vehiculos
    {
        IDALE_Sensor DALS = new DALE_Sensores();
        IDALE_Tipo_Evento DALT = new DALE_Tipo_Evento();
        IDALE_Empresa DALE = new DALE_Empresa();

        public void setModel(Vehiculo veh)
        {
            Id = veh.Id;
            Id_Empleado = veh.Id_Empleado;
            Marca = veh.Marca;
            Modelo = veh.Modelo;
            RUT_Empresa = veh.EmpresaRef.RUT;
            Activo = veh.Activo;
            this.setModelSensores(veh.Lista_Sensores);
            this.setModelTipo_Eventos(veh.Lista_Tipo_Eventos);
        }

        public void setModelTipo_Eventos(List<Tipo_Evento> eve)
        {
            List<Tipo_Eventos> lista = new List<Tipo_Eventos>();
            foreach(Tipo_Evento e in eve)
            {
                Tipo_Eventos nuevo = new Tipo_Eventos();
                nuevo.setModel(e);
                lista.Add(nuevo);
            }
            this.Tipo_Evento = lista;
        }

        public void setModelSensores(List<Sensor> listaSensor)
        {
            List<Sensores> lista = new List<Sensores>();
            foreach(Sensor sen in listaSensor)
            {
                if(sen is SensorCombustible)
                {
                    SensoresCombustible nuevo = new SensoresCombustible();
                    nuevo.setModel((SensorCombustible)sen);
                    lista.Add(nuevo);
                }
                if (sen is SensorMotor)
                {
                    SensoresMotor nuevo = new SensoresMotor();
                    nuevo.setModel((SensorMotor)sen);
                    lista.Add(nuevo);
                }
                if (sen is SensorGPS)
                {
                    SensoresGPS nuevo = new SensoresGPS();
                    nuevo.setModel((SensorGPS)sen);
                    lista.Add(nuevo);
                }
                if (sen is SensorSeguridad)
                {
                    SensoresSeguridad nuevo = new SensoresSeguridad();
                    nuevo.setModel((SensorSeguridad)sen);
                    lista.Add(nuevo);
                }
                

            }
            
        }
        public Vehiculo getEntity()
        {
            Vehiculo nuevo = new Vehiculo();
            nuevo.Id = Id;
            nuevo.Id_Empleado = (int)Id_Empleado;
            nuevo.Marca = Marca;
            nuevo.Modelo = Modelo;
            nuevo.Activo = (bool)Activo;
            nuevo.Lista_Sensores = this.getEntitySensores();
            nuevo.Lista_Tipo_Eventos = this.getEntityTipo_Evento();
            return nuevo;
        }


        public List<Tipo_Evento> getEntityTipo_Evento()
        {
            List<Tipo_Evento> lista = new List<Tipo_Evento>();
            foreach (Tipo_Eventos e in this.Tipo_Evento)
            {
                Tipo_Evento nuevo = new Tipo_Evento();
                nuevo = e.getEntity();
                lista.Add(nuevo);
            }
            return lista;
        }

        public List<Sensor> getEntitySensores()
        {
            List<Sensor> lista = new List<Sensor>();
            foreach (Sensores sen in this.Sensores)
            {
                if (sen is SensoresCombustible)
                {
                    SensoresCombustible sens = (SensoresCombustible)sen;
                    SensorCombustible nuevo = new SensorCombustible();
                    nuevo = sens.getEntity();
                    lista.Add(nuevo);
                }
                if (sen is SensoresMotor)
                {
                    SensoresMotor sens = (SensoresMotor)sen;
                    SensorMotor nuevo = new SensorMotor();
                    nuevo= sens.getEntity();
                    lista.Add(nuevo);
                }
                if (sen is SensoresGPS)
                {
                    SensoresGPS sens = (SensoresGPS)sen;
                    SensorGPS nuevo = new SensorGPS();
                    nuevo = sens.getEntity();
                    lista.Add(nuevo);
                }
                if (sen is SensoresSeguridad)
                {
                    SensoresSeguridad sens = (SensoresSeguridad) sen;
                    SensorSeguridad nuevo = new SensorSeguridad();
                    nuevo=sens.getEntity();
                    lista.Add(nuevo);
                }

                
            }
            return lista;
        }
    }
}
