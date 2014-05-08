using System.Data.Entity;
using p2_projekt.models;

namespace p2_projekt
{
    public class LobopContext : DbContext
    {
        public LobopContext()
        {
            // Entity Framework lazy loader. Lad være med at gøre dette.
            //this.Configuration.ProxyCreationEnabled = false; 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>().HasOptional(t => t.BoatSpace).WithOptionalDependent(t => t.Boat).WillCascadeOnDelete(false);
            //modelBuilder.Entity<BoatSpace>().HasOptional(t => t.Boat).WithOptionalDependent(t => t.BoatSpace).WillCascadeOnDelete(false);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<BoatSpace> BoatSpaces { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; } // required for making one-way relations 
    }
}
