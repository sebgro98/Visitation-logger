using SharedModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ResourceServer.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorAccount> VisitorAccounts { get; set; }
        public DbSet<PurposeType> PurposeTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorAccount>()
                .HasIndex(v => v.Username)
                .IsUnique();

            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.Username)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            DatabaseSeeder.Seed(modelBuilder);
        }
    }
}
