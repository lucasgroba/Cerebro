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
            foreach(Tipo_Evento eve in lista)
            {
                Tipo_Eventos nuevo = new Tipo_Eventos();
                nuevo.setModel(eve);
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Tipo_Evento> Tipo_EventoDBToTipo_Evento(List<Tipo_Eventos> lista)
        {
            List<Tipo_Evento> retorno = new List<Tipo_Evento>();
            foreach (Tipo_Eventos eve in lista)
            {
                Tipo_Evento nuevo = eve.getEntity();
                retorno.Add(nuevo);
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


        public List<Vehiculo> VehiculoDBToVehiculo(List<Vehiculos> lista_vehiculo)
        {
            List<Vehiculo> retorno = new List<Vehiculo>();
            foreach (Vehiculos vehi in lista_vehiculo)
            {
                Vehiculo nuevo = vehi.getEntity();
                retorno.Add(nuevo);
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

        public List<Empleado> EmpleadoDBToEmpleado(List<Empleados> lista)
        {
            List<Empleado> retorno = new List<Empleado>();
            foreach (Empleados vehi in lista)
            {
                Empleado nuevo = vehi.getEntity();
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Usuarios> UsuarioToUsuarioDB(List<Usuario> lista, int Rut)
        {
            List<Usuarios> retorno = new List<Usuarios>();
            foreach (Usuario vehi in lista)
            {
                //Usuarios nuevo = new Usuarios();
                //nuevo.Mail = vehi.Mail;
                //nuevo.Pass = vehi.Pass;
                //nuevo.Tipo_User = vehi.Tipo_User;
                //retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Usuario> UsuarioDBToUsuario(List<Usuarios> lista)
        {
            List<Usuario> retorno = new List<Usuario>();
            foreach (Usuarios vehi in lista)
            {
                //Usuario nuevo = new Usuario();
                //nuevo.Mail = vehi.Mail;
                //nuevo.Pass = vehi.Pass;
                //nuevo.Tipo_User = vehi.Tipo_User;
                //retorno.Add(nuevo);
            }
            return retorno;
        }

        public List<Empresas> EmpresaToEmpresaDB(List<Empresa> lista, String mail) {
            List<Empresas> retorno = new List<Empresas>();
            foreach (Empresa emp in lista) {
                Empresas nuevo = new Empresas();
                nuevo.setModel(emp);
                retorno.Add(nuevo);

            }
            return retorno;
        }


        public List<Empresa> EmpresaDBToEmpresa(List<Empresas> lista)
        {
            List<Empresa> retorno = new List<Empresa>();
            foreach (Empresas emp in lista)
            {
                Empresa nuevo = emp.getEntity();
                retorno.Add(nuevo);

            }
            return retorno;
        }

        public List<Sensores> SensorToSensorDB(List<Sensor> lista, int id)
        {
            List<Sensores> retorno = new List<Sensores>();
            foreach (Sensor v in lista)
            {
                if (v is SensorGPS)
                {
                    SensorGPS vehi = (SensorGPS)v;
                    SensoresGPS nuevo = new SensoresGPS();
                    nuevo.setModel(vehi);
                    retorno.Add(nuevo);
                }
                else
                {
                    if (v is SensorCombustible)
                    {
                        SensorCombustible vehi = (SensorCombustible)v;
                        SensoresCombustible nuevo = new SensoresCombustible();
                        nuevo.setModel(vehi);
                        retorno.Add(nuevo);
                    }
                    else
                    {
                        if (v is SensorMotor)
                        {
                            SensorMotor vehi = (SensorMotor)v;
                            SensoresMotor nuevo = new SensoresMotor();
                            nuevo.setModel(vehi);
                            retorno.Add(nuevo);
                        }
                        else
                        {
                            if (v is SensorSeguridad)
                            {
                                SensorSeguridad vehi = (SensorSeguridad)v;
                                SensoresSeguridad nuevo = new SensoresSeguridad();
                                nuevo.setModel(vehi);
                                retorno.Add(nuevo);
                            }
                        }
                    }
                }

            }
            return retorno;
        }


        public List<Sensor> SensorDBToSensor(List<Sensores> lista)
        {
            List<Sensor> retorno = new List<Sensor>();
            foreach (Sensores v in lista)
            {
                if (v is SensoresGPS)
                {
                    SensoresGPS vehi = (SensoresGPS)v;
                    SensorGPS nuevo = vehi.getEntity();
                    retorno.Add(nuevo);
                }
                else
                {
                    if (v is SensoresCombustible)
                    {
                        SensoresCombustible vehi = (SensoresCombustible)v;
                        SensorCombustible nuevo = vehi.getEntity();
                        retorno.Add(nuevo);
                    }
                    else
                    {
                        if (v is SensoresMotor)
                        {
                            SensoresMotor vehi = (SensoresMotor)v;
                            SensorMotor nuevo = vehi.getEntity();
                            retorno.Add(nuevo);
                        }
                        else
                        {
                            if (v is SensoresSeguridad)
                            {
                                SensoresSeguridad vehi = (SensoresSeguridad)v;
                                SensorSeguridad nuevo = vehi.getEntity();
                                retorno.Add(nuevo);
                            }
                        }
                    }
                }

            }
            return retorno;
        }
    }
}
