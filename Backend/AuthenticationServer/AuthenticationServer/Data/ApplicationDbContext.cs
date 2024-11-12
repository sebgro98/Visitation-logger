using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace AuthenticationServer.Data
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
    }
}
