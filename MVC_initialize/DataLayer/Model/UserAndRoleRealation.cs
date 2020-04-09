using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
   public class UserAndRoleRealation
    {[Key]
        public int Id { get; set; }

        public Users User { get; set; }
        public Role Roles { get; set; }
    }
}
