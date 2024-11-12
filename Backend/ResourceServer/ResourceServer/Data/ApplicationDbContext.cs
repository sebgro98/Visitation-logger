using ResourceServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ResourceServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        //tom konsturkor så kommer att använda base options vilket betyder att DbContext kommer sätta dem åt mig
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorAccount> VisitorAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitorAccount>()
                .HasIndex(v => v.UserName)
                .IsUnique();

            modelBuilder.Entity<Admin>()
                .HasIndex(a => a.FullName)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
            DatabaseSeeder.Seed(modelBuilder);
        }


    }
}
