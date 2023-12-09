using InformBez.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InformBez
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AttachedFile> AttachedFiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TB6CE81\SQLEXPRESS;Database=InformBez;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
