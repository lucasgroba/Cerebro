using BusinessLayer.Controladores;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPresentation.ManejoPermisos
{
    public class UserRole
    {
        BLUsuario BLU = new BLUsuario();
        BLEmpresa BLE = new BLEmpresa();
        public Empresa GetEmpresaUser(String id)
        {
            return BLE.GetEmpresaxUser(id);
        }

        public String GetRoleUser(String id)
        {
            return BLU.GetRoleUsuario(id);
        }

        public static bool IsLoguedUserinRole(string role, String mail)
        {
            BLUsuario BLU = new BLUsuario();
            String roleUser = BLU.GetRoleUsuario(mail);
            if(roleUser == null)
            {
                return false;
            }
            else
            {
                return roleUser.Equals(role);
            }
            
        }
    }
}