using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Intefaces
{
    public interface IDALE_Role
    {
        AspNetRoles GetRole(String id);
        
    }
}
