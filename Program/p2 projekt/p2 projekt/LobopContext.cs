using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;

namespace p2_projekt
{
    class LobopContext : DbContext
    {
        public LobopContext()
        {
            Console.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Members");
            });

            modelBuilder.Entity<Guest>().Map(g =>
            {
                g.MapInheritedProperties();
                g.ToTable("Guests");
            });
        }
    }
}
