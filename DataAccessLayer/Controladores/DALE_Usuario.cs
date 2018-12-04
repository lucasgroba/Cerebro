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
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Usuarios nuevo = new Usuarios();
                nuevo.setModel(usu);
                db.AspNetUsers.Add(nuevo);
                db.SaveChanges();
                
            }
        }

        public void DeleteUsuario(string mail)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                db.AspNetUsers.Remove(db.AspNetUsers.Find(mail));
                db.SaveChanges();
            }
        }

        public List<Usuario> GetAllUsuarios()
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.AspNetUsers select e).ToList();
                return new ConvertType().UsuarioDBToUsuario(ListEmp);
            }
        }

        public Usuario GetUsuario(string id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.AspNetUsers where e.Id.Equals(id) select e).ToList();
                return new ConvertType().UsuarioDBToUsuario(ListEmp).First();
            }
        }

        public Usuario GetUsuarioMail(string id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.AspNetUsers where e.Email.Equals(id) select e).ToList();
                return new ConvertType().UsuarioDBToUsuario(ListEmp).First();
            }
        }

        public void UpdateUsuario(Usuario usu)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                Usuarios u = db.AspNetUsers.FirstOrDefault(x => x.Id == usu.Id);
                AspNetRoles r = db.AspNetRoles.FirstOrDefault(x => x.Id == usu.Tipo_User);
                u.AspNetRoles.Add(r);

                Empresas emp = db.Empresas.FirstOrDefault(x => x.RUT == usu.EmpresaRef);
                u.Empresas.Add(emp);

                db.SaveChanges();
            }
            
        }
    }
}
