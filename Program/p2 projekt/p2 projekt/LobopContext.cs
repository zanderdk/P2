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
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Members");
            });
        }
    }
}
