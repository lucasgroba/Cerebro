using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALELecturaSensores
    {
        void AddLectura(LecturaSensor sen);


        List<LecturaSensor> GetAllLecturas(int id_sens);

        List<LecturaSensor> GetLast10Lecturas(int id_sens);

    }
}
