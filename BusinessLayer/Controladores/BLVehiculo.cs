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
    class BLVehiculo
    {
        IDALE_Vehiculo DALEmp = new DALE_Vehiculo();

        public void AltaVehiculo(Vehiculo veh)
        {
            DALEmp.AddVehiculo(veh);
        }

        public void UpdateVehiculo(Vehiculo veh)
        {
            DALEmp.UpdateVehiculo(veh);
        }

        public void DeleteVehiculo(int id)
        {
            DALEmp.DeleteVehiculo(id);
        }

    }
}
