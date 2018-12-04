using DataAccessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controladores
{
    public class DALRole : IDALE_Role
    {
        public AspNetRoles GetRole(String id)
        {
            using (CEREBROEntities1 db = new CEREBROEntities1())
            {
                var ListEmp = (from e in db.AspNetRoles where e.Id.Equals(id) select e).ToList();
                return ListEmp.First();
            }
        }
    }
}
