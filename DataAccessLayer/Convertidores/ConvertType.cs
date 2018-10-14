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
                nuevo.Accion = eve.Accion;
                nuevo.Activo = eve.Activo;
                nuevo.Id = eve.Id;
                nuevo.Maximo = eve.Maximo;
                nuevo.Minimo = eve.Minimo;
                nuevo.Periodo = eve.Periodo;
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Tipo_Evento> Tipo_EventoDBToTipo_Evento(List<Tipo_Eventos> lista)
        {
            List<Tipo_Evento> retorno = new List<Tipo_Evento>();
            foreach (Tipo_Eventos eve in lista)
            {
                Tipo_Evento nuevo = new Tipo_Evento();
                nuevo.Accion = eve.Accion;
                nuevo.Activo = (bool)eve.Activo;
                nuevo.Id = eve.Id;
                nuevo.Maximo = (int)eve.Maximo;
                nuevo.Minimo = (int)eve.Minimo;
                nuevo.Periodo =(int)eve.Periodo;
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Vehiculos> VehiculoToVehiculoDB(List<Vehiculo> lista_vehiculo, int rut)
        {
            List<Vehiculos> retorno = new List<Vehiculos>();
            foreach (Vehiculo vehi in lista_vehiculo)
            {
                Vehiculos nuevo = new Vehiculos();
                nuevo.Id = vehi.Id;
                nuevo.Id_Empleado = vehi.Id_Empleado;
                nuevo.Marca = vehi.Marca;
                nuevo.Modelo = vehi.Modelo;
                nuevo.RUT_Empresa = rut;
                nuevo.Activo = vehi.Activo;
                nuevo.Sensores = SensorToSensorDB(vehi.Lista_Sensores, vehi.Id);
                nuevo.Tipo_Evento = Tipo_EventoToTipo_EventoDB(vehi.Lista_Tipo_Eventos);
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Vehiculo> VehiculoDBToVehiculo(List<Vehiculos> lista_vehiculo)
        {
            List<Vehiculo> retorno = new List<Vehiculo>();
            foreach (Vehiculos vehi in lista_vehiculo)
            {
                Vehiculo nuevo = new Vehiculo();
                nuevo.Id = vehi.Id;
                nuevo.Id_Empleado = (int)vehi.Id_Empleado;
                nuevo.Marca = vehi.Marca;
                nuevo.Modelo = vehi.Modelo;
                nuevo.Activo =(bool) vehi.Activo;
                nuevo.Lista_Sensores = SensorDBToSensor((List<Sensores>)vehi.Sensores);
                nuevo.Lista_Tipo_Eventos = Tipo_EventoDBToTipo_Evento((List<Tipo_Eventos>)vehi.Tipo_Evento);
                retorno.Add(nuevo);
            }
            return retorno;
        }

        public List<Empleados> EmpleadoToEmpleadoDB(List<Empleado> lista, int rut)
        {
            List<Empleados> retorno = new List<Empleados>();
            foreach (Empleado vehi in lista)
            {
                Empleados nuevo = new Empleados();
                nuevo.Ci = vehi.Ci;
                nuevo.Activo = vehi.Activo;
                nuevo.Direccion = vehi.Direccion;
                nuevo.Nombre = vehi.Nombre;
                nuevo.RUT_Empresa = rut;
                nuevo.Tel = vehi.Tel;
                retorno.Add(nuevo);
            }
            return retorno;
        }

        public List<Empleado> EmpleadoDBToEmpleado(List<Empleados> lista)
        {
            List<Empleado> retorno = new List<Empleado>();
            foreach (Empleados vehi in lista)
            {
                Empleado nuevo = new Empleado();
                nuevo.Ci = vehi.Ci;
                nuevo.Activo = (bool)vehi.Activo;
                nuevo.Direccion = vehi.Direccion;
                nuevo.Nombre = vehi.Nombre;
                nuevo.Tel = (int)vehi.Tel;
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Usuarios> UsuarioToUsuarioDB(List<Usuario> lista, int Rut)
        {
            List<Usuarios> retorno = new List<Usuarios>();
            foreach (Usuario vehi in lista)
            {
                Usuarios nuevo = new Usuarios();
                nuevo.Mail = vehi.Mail;
                nuevo.Pass = vehi.Pass;
                nuevo.Tipo_User = vehi.Tipo_User;
                retorno.Add(nuevo);
            }
            return retorno;
        }


        public List<Usuario> UsuarioDBToUsuario(List<Usuarios> lista)
        {
            List<Usuario> retorno = new List<Usuario>();
            foreach (Usuarios vehi in lista)
            {
                Usuario nuevo = new Usuario();
                nuevo.Mail = vehi.Mail;
                nuevo.Pass = vehi.Pass;
                nuevo.Tipo_User = vehi.Tipo_User;
                retorno.Add(nuevo);
            }
            return retorno;
        }

        public List<Empresas> EmpresaToEmpresaDB(List<Empresa> lista, String mail) {
            List<Empresas> retorno = new List<Empresas>();
            foreach (Empresa emp in lista) {
                Empresas nuevo = new Empresas();
                nuevo.Activo = (bool)emp.Activo;
                nuevo.Nombre = emp.Nombre;
                nuevo.RUT = emp.RUT;
                nuevo.Zona_Latitud = (Double)emp.Zona_Latitud;
                nuevo.Zona_Longitud = (Double)emp.Zona_Longitud;
                nuevo.Empleados = EmpleadoToEmpleadoDB( emp.Lista_Empleados, emp.RUT);
                nuevo.Usuarios = UsuarioToUsuarioDB(emp.Lista_Usuarios,emp.RUT);
                nuevo.Vehiculos = VehiculoToVehiculoDB(emp.Lista_Vehiculos, emp.RUT);
                retorno.Add(nuevo);

            }
            return retorno;
        }


        public List<Empresa> EmpresaDBToEmpresa(List<Empresas> lista)
        {
            List<Empresa> retorno = new List<Empresa>();
            foreach (Empresas emp in lista)
            {
                Empresa nuevo = new Empresa();
                nuevo.Activo = (bool)emp.Activo;
                nuevo.Nombre = emp.Nombre;
                nuevo.RUT = emp.RUT;
                nuevo.Zona_Latitud = (Double)emp.Zona_Latitud;
                nuevo.Zona_Longitud = (Double)emp.Zona_Longitud;
                nuevo.Lista_Empleados = EmpleadoDBToEmpleado((List<Empleados>) emp.Empleados);
                nuevo.Lista_Usuarios = UsuarioDBToUsuario((List<Usuarios>)emp.Usuarios);
                nuevo.Lista_Vehiculos = VehiculoDBToVehiculo((List<Vehiculos>)emp.Vehiculos);
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
                    nuevo.Id_Vehiculo = id;
                    retorno.Add(nuevo);
                }
                else
                {
                    if (v is SensorCombustible)
                    {
                        SensorCombustible vehi = (SensorCombustible)v;
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
                        nuevo.Id_Vehiculo = id;
                        retorno.Add(nuevo);
                    }
                    else
                    {
                        if (v is SensorMotor)
                        {
                            SensorMotor vehi = (SensorMotor)v;
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
                            nuevo.Id_Vehiculo = id;
                            retorno.Add(nuevo);
                        }
                        else
                        {
                            if (v is SensorSeguridad)
                            {
                                SensorSeguridad vehi = (SensorSeguridad)v;
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
                                nuevo.Id_Vehiculo = id;
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
                    SensorGPS nuevo = new SensorGPS();
                    nuevo.Id = vehi.Id;
                    nuevo.API = vehi.Api;
                    nuevo.Activo =(bool)vehi.Activo;
                    nuevo.Frecuencia = (int)vehi.Frecuencia;
                    nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                    nuevo.Envio_Siempre = (bool)vehi.Envio_Siempre;
                    nuevo.Maximo = (int)vehi.Maximo;
                    nuevo.Minimo = (int)vehi.Minimo;
                    nuevo.Aceleracion = (Double)vehi.Aceleracion;
                    nuevo.Velocidad = (int)vehi.Velocidad;
                    nuevo.Latitud = (Double)vehi.Latitud;
                    nuevo.Longitud = (Double)vehi.Longitud;
                    retorno.Add(nuevo);
                }
                else
                {
                    if (v is SensoresCombustible)
                    {
                        SensoresCombustible vehi = (SensoresCombustible)v;
                        SensorCombustible nuevo = new SensorCombustible();
                        nuevo.Id = vehi.Id;
                        nuevo.API = vehi.Api;
                        nuevo.Activo = (bool)vehi.Activo;
                        nuevo.Frecuencia = (int)vehi.Frecuencia;
                        nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                        nuevo.Envio_Siempre = (bool)vehi.Envio_Siempre;
                        nuevo.Maximo = (int)vehi.Maximo;
                        nuevo.Minimo = (int)vehi.Minimo;
                        nuevo.Nivel =(int) vehi.Nivel_Combustible;
                        retorno.Add(nuevo);
                    }
                    else
                    {
                        if (v is SensoresMotor)
                        {
                            SensoresMotor vehi = (SensoresMotor)v;
                            SensorMotor nuevo = new SensorMotor();
                            nuevo.Id = vehi.Id;
                            nuevo.API = vehi.Api;
                            nuevo.Activo =(bool) vehi.Activo;
                            nuevo.Frecuencia = (int) vehi.Frecuencia;
                            nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                            nuevo.Envio_Siempre = (bool)vehi.Envio_Siempre;
                            nuevo.Maximo = (int)vehi.Maximo;
                            nuevo.Minimo = (int)vehi.Minimo;
                            nuevo.Presion = (Double)vehi.Presion;
                            nuevo.Temperatura = (Double)vehi.Temperatura;
                            retorno.Add(nuevo);
                        }
                        else
                        {
                            if (v is SensoresSeguridad)
                            {
                                SensoresSeguridad vehi = (SensoresSeguridad)v;
                                SensorSeguridad nuevo = new SensorSeguridad();
                                nuevo.Id = vehi.Id;
                                nuevo.API = vehi.Api;
                                nuevo.Activo = (bool)vehi.Activo;
                                nuevo.Frecuencia =(int) vehi.Frecuencia;
                                nuevo.Fecha_Lectura = vehi.Fecha_Lectura;
                                nuevo.Envio_Siempre = (bool)vehi.Envio_Siempre;
                                nuevo.Maximo = (int)vehi.Maximo;
                                nuevo.Minimo = (int)vehi.Minimo;
                                nuevo.Alarma_Activa = nuevo.Alarma_Activa;
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
