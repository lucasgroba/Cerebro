using DataAccessLayer;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Controladores
{
    class BLEmpresa
    {
        IDALE_Empresa DALEmp = new DALE_Empresa();

        public void AltaEmpresa(Empresa emp)
        {
            DALEmp.AddEmpresa(emp);
        }

        public void UpdateEmpresa(Empresa emp)
        {
            DALEmp.UpdateEmpresa(emp);
        }

        public void DeleteEmpresa(int RUT)
        {
            DALEmp.DeleteEmpresa(RUT);
        }
    }
}
