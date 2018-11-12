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
        public void AltaLectura(LecturaSensor lec)
        {
            if (lec != null) {

                DALELectura.AddLectura(lec);

            }

        }

        public List<LecturaSensor> getLecturaSensor(int id_sensor)
        {
            List<LecturaSensor> lista = DALELectura.GetAllLecturas();
            foreach (LecturaSensor sen in lista) {
                if(sen.SensorRef != id_sensor)
                {
                    lista.Remove(sen);
                }
            }
            return lista;
        }

        public List<Tipo_Evento> AnalizoEventos(LecturaSensor lec) {
            Vehiculo veh;
            Sensor sen;
            List<Tipo_Evento> ListaEventos;
            List<Tipo_Evento> retorno = new List<Tipo_Evento>();
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
                                            retorno.Add(TE);
                                        }
                                    break;
                                case "A":
                                    if ((!(lec.Aceleracion <= TE.Maximo) || !(lec.Aceleracion >= TE.Minimo))&& lec.Aceleracion != -1)
                                    {
                                        retorno.Add(TE);
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
                                        retorno.Add(TE);
                                    }
                                    break;
                                case "T":
                                    if ((!(lec.Temperatura <= TE.Maximo) || !(lec.Temperatura >= TE.Minimo))&& lec.Temperatura !=-1)
                                    {
                                        retorno.Add(TE);
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
                                        retorno.Add(TE);
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
                                        retorno.Add(TE);
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
