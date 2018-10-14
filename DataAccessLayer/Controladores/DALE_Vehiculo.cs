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
    public class DALE_Vehiculo : IDALE_Vehiculo
    {
        public void AddVehiculo(Vehiculo vehi)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                Vehiculos nuevo = new Vehiculos();
                nuevo.Id = vehi.Id;
                nuevo.Id_Empleado = vehi.Id_Empleado;
                nuevo.Marca = vehi.Marca;
                nuevo.Modelo = vehi.Modelo;
                nuevo.Activo = vehi.Activo;
                nuevo.Sensores = new ConvertType().SensorToSensorDB(vehi.Lista_Sensores, vehi.Id);
                nuevo.Tipo_Evento = new ConvertType().Tipo_EventoToTipo_EventoDB(vehi.Lista_Tipo_Eventos);
                db.Vehiculos.Add(nuevo);
            }
        }

        public void DeleteVehiculo(int id)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                db.Vehiculos.Remove(db.Vehiculos.Find(id));
                db.SaveChanges();
            }
        }

        public List<Vehiculo> GetAllVehiculos()
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Vehiculos select e).ToList();
                return new ConvertType().VehiculoDBToVehiculo(ListEmp);
            }
        }

        public Vehiculo GetVehiculo(int id)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Vehiculos where e.Id==id select e).ToList();
                return new ConvertType().VehiculoDBToVehiculo(ListEmp).First();
            }
        }

        public void UpdateVehiculo(Vehiculo vehi)
        {
            DeleteVehiculo(vehi.Id);
            AddVehiculo(vehi);
        }
    }
}
