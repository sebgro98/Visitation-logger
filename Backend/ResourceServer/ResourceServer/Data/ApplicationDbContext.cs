using ResourceData.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ResourceData.Data
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
            base.OnModelCreating(modelBuilder);
            DatabaseSeeder.Seed(modelBuilder);
        }


    }
}
