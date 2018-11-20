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
    public class DALE_LecturaSensores: IDALELecturaSensores
    {
        public void AddLectura(LecturaSensor lec)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                if (lec != null)
                {
                    LecturaSensores nuevo = new LecturaSensores();
                    nuevo.setModel(lec);
                    db.LecturaSensores.Add(nuevo);
                    db.SaveChanges();
                }
            }
        }

        public List<LecturaSensor> GetLast10Lecturas(int id_sens)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.LecturaSensores where e.Id_Sensor == id_sens select e).OrderByDescending(e=>e.Id).Take(10).ToList();
                return new ConvertType().LecturaDBToLectura(ListEmp);
            }
        }

        public List<LecturaSensor> GetAllLecturas(int id_sens)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.LecturaSensores where e.Id_Sensor ==id_sens select e).ToList();
                return new ConvertType().LecturaDBToLectura(ListEmp);
            }
        }
    }
}
