using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;

namespace p2_projekt
{
    public class LobopContext : DbContext
    {
        public LobopContext()
        {
            // Entity Framework lazy loader. Lad være med at gøre dette.
            this.Configuration.ProxyCreationEnabled = false; 
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<BoatSpace> BoatSpaces { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; } // required for making one-way relations 
    }
}
