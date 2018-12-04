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
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                if(vehi != null)
                {
                    Vehiculos nuevo = new Vehiculos();
                    nuevo.setModel(vehi);
                    db.Vehiculos.Add(nuevo);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteVehiculo(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.Vehiculos.Remove(db.Vehiculos.Find(id));
                db.SaveChanges();
            }
        }

        public List<Vehiculo> GetAllVehiculos()
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Vehiculos select e).ToList();
                return new ConvertType().VehiculoDBToVehiculo(ListEmp);
            }
        }

        public Vehiculo GetVehiculo(int id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.Vehiculos where e.Id == id select e).ToList();
                return new ConvertType().VehiculoDBToVehiculo(ListEmp).First();
            }
        }


        public void UpdateVehiculo(Vehiculo vehi)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Vehiculos e = db.Vehiculos.Find(vehi.Id);
                e.setModel(vehi);
                db.Vehiculos.Attach(e);
                db.SaveChanges();

            }
        }
    }
}
