using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class DbProvider:DbContext
    {
        public DbProvider():base("FirstConnection")
        {
                
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }

    }
}
