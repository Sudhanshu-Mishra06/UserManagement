using Microsoft.EntityFrameworkCore;
using UserCrudApp.Models;

namespace UserCrudApp.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserLogin> Users { get; set; }

        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<UsersAudit> UserAudits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>()
                .ToTable(tb => tb.HasTrigger("trg_UserDetails_Audit"));
        }
    }
}