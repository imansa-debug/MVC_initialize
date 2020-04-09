using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Users
    {   [Key]
        public int UserID { get; set; }

        public Role Roles { get; set; }
        public byte RoleId { get; set;}
        [MaxLength(250)]
        public string UserName { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
