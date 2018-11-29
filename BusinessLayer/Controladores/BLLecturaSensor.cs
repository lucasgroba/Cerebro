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
    public class BLLecturaSensor
    {

        IDALELecturaSensores DALELectura = new DALE_LecturaSensores();
        IDALE_Sensor DALESensor = new DALE_Sensores();
        IDALE_Vehiculo DALEVehiculo = new DALE_Vehiculo();
        IDALE_Tipo_Evento DALETipo_Evento = new DALE_Tipo_Evento();
        BLEvento blEvento = new BLEvento();
        public List<Evento> AltaLectura(LecturaSensor lec)
        {
            if (lec != null) {

                DALELectura.AddLectura(lec);
                return AnalizoEventos(lec);
            }
            else
            {
               return null;
            }

        }

        public DateTime getDateUltimaLecturaBuena(int id_sensor, int max, int min)
        {
            List<LecturaSensor> listaLecturas = DALELectura.GetLast10Lecturas(id_sensor);
            DateTime ultimaLucturaBuena = new DateTime(2018,01,01);
            foreach(LecturaSensor l in listaLecturas)
            {
                if (AnalizoLecturas(l).Count.Equals(0))
                {
                    if(ultimaLucturaBuena!= null && l.FechaLectura > ultimaLucturaBuena)
                    {
                        ultimaLucturaBuena = l.FechaLectura;
                    }
                        
                }
            }
            return ultimaLucturaBuena;
        }

        public List<LecturaSensor> getLecturaSensor(int id_sensor)
        {
            return DALELectura.GetAllLecturas(id_sensor);
            
        }

        public bool ActualizoLectura(LecturaSensor lec)
        {

            if(lec != null)
            {
                Sensor nuevo = DALESensor.GetSensor(lec.SensorRef);
                if (nuevo.Tipo_Sensor.Equals("G"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public List<Evento> AnalizoLecturas(LecturaSensor lec) {
            Vehiculo veh;
            Sensor sen;
            List<Tipo_Evento> ListaEventos;
            List<Evento> retorno = new List<Evento>();
            if(lec != null)
            {
                sen = DALESensor.GetSensor(lec.SensorRef);
                veh = DALEVehiculo.GetVehiculo(sen.VehiculoRef);
                ListaEventos = veh.Lista_Tipo_Eventos;
                switch (sen.Tipo_Sensor){
                    case "G":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "V":
                                        if ((!(lec.Velocidad <= TE.Maximo) || !(lec.Velocidad >= TE.Minimo))&& lec.Velocidad!=-1)
                                        {
                                            
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            retorno.Add(nuevo);
                                        }
                                    break;
                                case "A":
                                    if ((!(lec.Aceleracion <= TE.Maximo) || !(lec.Aceleracion >= TE.Minimo))&& lec.Aceleracion != -1)
                                    {
                                        Evento nuevo = new Evento();
                                        nuevo.TipoEventoRef = TE;
                                        nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                        nuevo.Fecha = lec.FechaLectura;
                                        nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                        nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                        retorno.Add(nuevo);
                                      
                                    }
                                    break;
                            }
                            
                        }
                        break;
                    case "M":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "P":
                                    if ((!(lec.Presion <= TE.Maximo) || !(lec.Presion >= TE.Minimo))&&lec.Presion !=-1)
                                    {
                                        Evento nuevo = new Evento();
                                        nuevo.TipoEventoRef = TE;
                                        nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                        nuevo.Fecha = lec.FechaLectura;
                                        nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                        nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                        retorno.Add(nuevo);
                                    }
                                    break;
                                case "T":
                                    if ((!(lec.Temperatura <= TE.Maximo) || !(lec.Temperatura >= TE.Minimo))&& lec.Temperatura !=-1)
                                    {
                                        Evento nuevo = new Evento();
                                        nuevo.TipoEventoRef = TE;
                                        nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                        nuevo.Fecha = lec.FechaLectura;
                                        nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                        nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                        retorno.Add(nuevo);
                                    }
                                    break;
                            }
                        }
                        break;
                    case "S":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "S":
                                    if (lec.Alarma_Activa)
                                    {
                                        Evento nuevo = new Evento();
                                        nuevo.TipoEventoRef = TE;
                                        nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                        nuevo.Fecha = lec.FechaLectura;
                                        nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                        nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                        retorno.Add(nuevo);
                                    }
                                    break;
                               
                            }
                        }
                        break;
                    case "C":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "C":
                                    if (lec.Nivel_Combustible < TE.Minimo && lec.Nivel_Combustible != -1)
                                    {
                                        Evento nuevo = new Evento();
                                        nuevo.TipoEventoRef = TE;
                                        nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                        nuevo.Fecha = lec.FechaLectura;
                                        nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                        nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                        retorno.Add(nuevo);
                                    }
                                    break;

                            }
                        }
                        break;
                }
            }
            return retorno;
        }

        public List<Evento> AnalizoEventos(LecturaSensor lec)
        {
            Vehiculo veh;
            Sensor sen;
            List<Tipo_Evento> ListaEventos;
            List<Evento> retorno = new List<Evento>();
            if (lec != null)
            {
                sen = DALESensor.GetSensor(lec.SensorRef);
                veh = DALEVehiculo.GetVehiculo(sen.VehiculoRef);
                ListaEventos = veh.Lista_Tipo_Eventos;
                switch (sen.Tipo_Sensor)
                {
                    case "G":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "V":
                                    if ((!(lec.Velocidad <= TE.Maximo) || !(lec.Velocidad >= TE.Minimo)) && lec.Velocidad != -1)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef,TE.Maximo,TE.Minimo)<lec.FechaLectura.AddSeconds(-TE.Periodo))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }
                                        
                                    }
                                    break;
                                case "A":
                                    if ((!(lec.Aceleracion <= TE.Maximo) || !(lec.Aceleracion >= TE.Minimo)) && lec.Aceleracion != -1)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef, TE.Maximo, TE.Minimo) < lec.FechaLectura.AddSeconds(-TE.Periodo) && lec.FechaLectura > blEvento.GetDateUltimoEvento(veh.Id, TE).AddMinutes(5))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }

                                    }
                                    break;
                            }

                        }
                        break;
                    case "M":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "P":
                                    if ((!(lec.Presion <= TE.Maximo) || !(lec.Presion >= TE.Minimo)) && lec.Presion != -1)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef, TE.Maximo, TE.Minimo) < lec.FechaLectura.AddSeconds(-TE.Periodo) && lec.FechaLectura > blEvento.GetDateUltimoEvento(veh.Id, TE).AddMinutes(5))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }
                                    }
                                    break;
                                case "T":
                                    if ((!(lec.Temperatura <= TE.Maximo) || !(lec.Temperatura >= TE.Minimo)) && lec.Temperatura != -1)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef, TE.Maximo, TE.Minimo) < lec.FechaLectura.AddSeconds(-TE.Periodo) && lec.FechaLectura > blEvento.GetDateUltimoEvento(veh.Id, TE).AddMinutes(5))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "S":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "S":
                                    if (lec.Alarma_Activa)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef, TE.Maximo, TE.Minimo) < lec.FechaLectura.AddSeconds(-TE.Periodo) && lec.FechaLectura > blEvento.GetDateUltimoEvento(veh.Id, TE).AddMinutes(5))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }
                                    }
                                    break;

                            }
                        }
                        break;
                    case "C":
                        foreach (Tipo_Evento TE in ListaEventos)
                        {
                            switch (TE.TipoLectura)
                            {
                                case "C":
                                    if (lec.Nivel_Combustible < TE.Minimo && lec.Nivel_Combustible != -1)
                                    {
                                        if (getDateUltimaLecturaBuena(lec.SensorRef, TE.Maximo, TE.Minimo) < lec.FechaLectura.AddSeconds(-TE.Periodo) && lec.FechaLectura > blEvento.GetDateUltimoEvento(veh.Id, TE).AddMinutes(5))
                                        {
                                            Evento nuevo = new Evento();
                                            nuevo.TipoEventoRef = TE;
                                            nuevo.VehiculoRef = DALESensor.GetSensor(lec.SensorRef).VehiculoRef;
                                            nuevo.Fecha = lec.FechaLectura;
                                            nuevo.Latitud = veh.GetUltimaLecturaGPS().Latitud;
                                            nuevo.Longitud = veh.GetUltimaLecturaGPS().Longitud;
                                            blEvento.AltaEvento(nuevo);
                                            retorno.Add(nuevo);
                                        }
                                    }
                                    break;

                            }
                        }
                        break;
                }
            }
            return retorno;
        }
    }
}
