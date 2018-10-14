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
    public class DALE_Usuario : IDALE_Usuario
    {
        public void AddUsuario(Usuario usu)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                Usuarios nuevo = new Usuarios();
                nuevo.Mail = usu.Mail;
                nuevo.Pass = usu.Pass;
                nuevo.Tipo_User = usu.Tipo_User;
                db.Usuarios.Add(nuevo);
            }
        }

        public void DeleteUsuario(string mail)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                db.Usuarios.Remove(db.Usuarios.Find(mail));
                db.SaveChanges();
            }
        }

        public List<Usuario> GetAllUsuarios()
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Usuarios select e).ToList();
                return new ConvertType().UsuarioDBToUsuario(ListEmp);
            }
        }

        public Usuario GetUsuario(int mail)
        {
            using (CEREBRO_Entities db = new CEREBRO_Entities())
            {
                var ListEmp = (from e in db.Usuarios where e.Mail.Equals(mail) select e).ToList();
                return new ConvertType().UsuarioDBToUsuario(ListEmp).First();
            }
        }

        public void UpdateUsuario(Usuario usu)
        {
            DeleteUsuario(usu.Mail);
            AddUsuario(usu);
        }
    }
}
