using Microsoft.EntityFrameworkCore;
using PersistenceServer.Models;

namespace PersistenceServer.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ViaEntity> ViaEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=hattie.db.elephantsql.com;Port=5432;Database=ezeateiy;Username=ezeateiy;Password=6uR8rdvQCc5r8Eho5SZbxjEcWhxtIUWE",
                options => options.UseAdminDatabase("ezeateiy"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Campus>().HasKey(c => new
            {
                c.City,
                c.Street,
                c.PostCode
            });
            

            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Facility>().ToTable("Facilities");
        }
    }
}