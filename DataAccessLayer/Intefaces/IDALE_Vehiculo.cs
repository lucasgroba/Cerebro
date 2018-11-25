using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALE_Vehiculo
    {
        void AddVehiculo(Vehiculo vehi);

        void DeleteVehiculo(int id);

        void UpdateVehiculo(Vehiculo vehi);

        List<Vehiculo> GetAllVehiculos();

        Vehiculo GetVehiculo(int id);

       
    }
}
