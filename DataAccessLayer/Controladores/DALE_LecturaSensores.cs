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
    class DALE_LecturaSensores: IDALELecturaSensores
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
                }
            }
        }

       

        public List<LecturaSensor> GetAllLecturas()
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.LecturaSensores select e).ToList();
                return new ConvertType().LecturaDBToLectura(ListEmp);
            }
        }
    }
}
