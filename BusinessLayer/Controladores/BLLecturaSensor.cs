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
    public class BLLecturaSensor
    {

        IDALELecturaSensores DALELectura = new DALE_LecturaSensores();
        public void AltaLectura(LecturaSensor lec)
        {
            if (lec != null) {

                DALELectura.AddLectura(lec);

            }

        }

        public List<LecturaSensor> getLecturaSensor(int id_sensor)
        {
            List<LecturaSensor> lista = DALELectura.GetAllLecturas();
            foreach (LecturaSensor sen in lista) {
                if(sen.SensorRef.Id != id_sensor)
                {
                    lista.Remove(sen);
                }
            }
            return lista;
        }
    }
}
