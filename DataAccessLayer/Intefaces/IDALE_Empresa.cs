using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDALE_Empresa
    {
        void AddEmpresa(Empresa emp);

        void DeleteEmpresa(int RUT);

        void UpdateEmpresa(Empresa emp);

        List<Empresa> GetAllEmpresas();

        Empresa GetEmpresa(int RUT);

        Empresas GetEmpresaModel(int RUT);
    }
}
