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
    class BLSensor
    {

        IDALE_Sensor DALEmp = new DALE_Sensores();

        public void AltaSensor(Sensor sen)
        {
            DALEmp.AddSensor(sen);
        }

        public void UpdateSensor(Sensor sen)
        {
            DALEmp.UpdateSensor(sen);
        }

        public void DeleteSensor(int id)
        {
            DALEmp.DeleteSensor(id);
        }

    }
}
