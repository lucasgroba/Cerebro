using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Convertidores
{
    class ConvertType
    {



        public List<Tipo_Eventos> Tipo_EventoToTipo_EventoDB(List<Tipo_Evento> lista)
        {
            List<Tipo_Eventos> retorno = new List<Tipo_Eventos>();
            if (lista != null)
            {
                foreach (Tipo_Evento eve in lista)
                {
                    Tipo_Eventos nuevo = new Tipo_Eventos();
                    nuevo.setModel(eve);
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }


        public List<Tipo_Evento> Tipo_EventoDBToTipo_Evento(List<Tipo_Eventos> lista)
        {
            List<Tipo_Evento> retorno = new List<Tipo_Evento>();
            if (lista != null)
            {
                foreach (Tipo_Eventos eve in lista)
                {
                    Tipo_Evento nuevo = eve.getEntity();
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }


        public List<Vehiculos> VehiculoToVehiculoDB(List<Vehiculo> lista_vehiculo, int rut)
        {
            List<Vehiculos> retorno = new List<Vehiculos>();
            if(lista_vehiculo != null)
            {
                foreach (Vehiculo vehi in lista_vehiculo)
                {
                    Vehiculos nuevo = new Vehiculos();
                    nuevo.setModel(vehi);
                    retorno.Add(nuevo);
                }

            }
            return retorno;
        }

        public List<Eventos> EventoToEventoDB(List<Evento> ListaEvento)
        {
            List<Eventos> retorno = new List<Eventos>();
            if (ListaEvento != null)
            {
                foreach (Evento e in ListaEvento)
                {
                    Eventos nuevo = new Eventos();
                    nuevo.setModel(e);
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }
        public List<Evento> EventoDBToEvento(List<Eventos> ListaEventos)
        {
            List<Evento> retorno = new List<Evento>();
            if (ListaEventos != null)
            {
                foreach (Eventos e in ListaEventos)
                {
                    retorno.Add(e.getEntity());
                }
                return retorno;
            }
            else return retorno;
        }


        public List<Vehiculo> VehiculoDBToVehiculo(List<Vehiculos> lista_vehiculo)
        {
            List<Vehiculo> retorno = new List<Vehiculo>();
            if (lista_vehiculo != null)
            {
                foreach (Vehiculos vehi in lista_vehiculo)
                {
                    Vehiculo nuevo = vehi.getEntity();
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }

        public List<Empleados> EmpleadoToEmpleadoDB(List<Empleado> lista, int rut)
        {
            List<Empleados> retorno = new List<Empleados>();
            if(lista != null)
            {
                foreach (Empleado vehi in lista)
                {
                    Empleados nuevo = new Empleados();
                    nuevo.setModel(vehi);
                    retorno.Add(nuevo);
                }

            }
            return retorno;
        }

        public List<LecturaSensores> LecturaToLecturaDB(List<LecturaSensor> lecturas)
        {
            List<LecturaSensores> ret = new List<LecturaSensores>();
            if (lecturas != null)
            {
                foreach (LecturaSensor cursor in lecturas)
                {
                    LecturaSensores nuevo = new LecturaSensores();
                    nuevo.setModel(cursor);
                    ret.Add(nuevo);
                }
            }
            return ret;
        }

        public List<LecturaSensor> LecturaDBToLectura(List<LecturaSensores> lecturas) 
        {
            List<LecturaSensor> ret = new List<LecturaSensor>();
            if (lecturas != null)
            {
                foreach (LecturaSensores cursor in lecturas)
                {
                    LecturaSensor nuevo = cursor.getEntity();
                    ret.Add(nuevo);
                }
            }
            return ret;
        }

        public List<Empleado> EmpleadoDBToEmpleado(List<Empleados> lista)
        {
            List<Empleado> retorno = new List<Empleado>();
            if (lista != null)
            {
                foreach (Empleados vehi in lista)
                {
                    Empleado nuevo = vehi.getEntity();
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }


        public List<Usuarios> UsuarioToUsuarioDB(List<Usuario> lista, int Rut)
        {
            List<Usuarios> retorno = new List<Usuarios>();
            foreach (Usuario vehi in lista)
            {
                Usuarios nuevo = new Usuarios();
                nuevo.setModel(vehi);
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Usuario> UsuarioDBToUsuario(List<Usuarios> lista)
        {
            List<Usuario> retorno = new List<Usuario>();
            if (lista != null)
            {
                foreach (Usuarios vehi in lista)
                {
                    Usuario nuevo = new Usuario();
                    nuevo = vehi.getEntity();
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }

        public List<Empresas> EmpresaToEmpresaDB(List<Empresa> lista, String mail) {
            List<Empresas> retorno = new List<Empresas>();
            if (lista != null)
            {
                foreach (Empresa emp in lista)
                {
                    Empresas nuevo = new Empresas();
                    nuevo.setModel(emp);
                    retorno.Add(nuevo);

                }
            }
            return retorno;
        }


        public List<Empresa> EmpresaDBToEmpresa(List<Empresas> lista)
        {
            List<Empresa> retorno = new List<Empresa>();
            if (lista != null)
            {
                foreach (Empresas emp in lista)
                {
                    Empresa nuevo = emp.getEntity();
                    retorno.Add(nuevo);

                }
            }
            return retorno;
        }

        public List<Sensores> SensorToSensorDB(List<Sensor> lista)
        {
            List<Sensores> retorno = new List<Sensores>();
            if (lista != null)
            {
                foreach (Sensor v in lista)
                {
                    Sensores nuevo = new Sensores();
                    nuevo.setModel(v);
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }


        public List<Sensor> SensorDBToSensor(List<Sensores> lista)
        {
            List<Sensor> retorno = new List<Sensor>();
            if (lista != null)
            {
                foreach (Sensores v in lista)
                {
                    Sensor nuevo = v.getEntity();
                    retorno.Add(nuevo);
                }
            }
            return retorno;
        }
    }
}
