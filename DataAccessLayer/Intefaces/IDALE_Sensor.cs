using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALE_Sensor
    {
        void AddSensor(Sensor sen);

        void DeleteSensor(int id);

        void UpdateSensor(Sensor sen);

        List<Sensor> GetAllSensor();

        Sensor GetSensor(int id);
    }
}
