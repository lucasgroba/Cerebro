using DataAccessLayer.Controladores;
using DataAccessLayer.Intefaces;
using SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    partial class Usuarios
    {
        IDALE_Empresa emp = new DALE_Empresa();
        IDALE_Role rol = new DALRole();
        public void setModel(Usuario usu)
        {
            
            this.Email = usu.mail;
            this.Id = usu.Id;
            this.PasswordHash = usu.Pass;
            this.AspNetRoles = new List<AspNetRoles>();
            this.AspNetRoles.Add(rol.GetRole(usu.Tipo_User));
            Empresas e = new Empresas();
            e.setModel(emp.GetEmpresa(usu.EmpresaRef));
            this.Empresas = new List<Empresas>();
            this.Empresas.Add(e);
        }

        public Usuario getEntity()
        {
            Usuario nuevo = new Usuario ();
            if(this.Empresas.Count() != 0)
            {
                nuevo.EmpresaRef = this.Empresas.First().RUT;
            }
            nuevo.Id = this.Id;
            nuevo.mail = this.Email;
            nuevo.Pass = this.PasswordHash;
            if(this.AspNetRoles.Count() != 0)
            {
                nuevo.Tipo_User = this.AspNetRoles.First().Id;
            }
            return nuevo;
        }

    }
}
