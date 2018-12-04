using DataAccessLayer.Intefaces;
using DataAccessLayer.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARE.Entities;

namespace BusinessLayer.Controladores
{
    public class BLUsuario
    {
        IDALE_Usuario DALU = new DALE_Usuario();

        public Usuario  GetUsuario(string id)
        {
            return DALU.GetUsuario(id);
             
        }

        public String  GetRoleUsuario(string mail)
        {
            return DALU.GetUsuarioMail(mail).Tipo_User;

        }

        public List<Usuario> GetAllUsuarios()
        {
            return DALU.GetAllUsuarios();

        }

        public void UpdateUsuario(Usuario usu)
        {
            DALU.UpdateUsuario(usu);

        }
        public void DeleteUsuario(String id)
        {
            DALU.DeleteUsuario(id);

        }

    }
}
