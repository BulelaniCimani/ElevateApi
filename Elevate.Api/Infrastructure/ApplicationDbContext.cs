using Elevate.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Elevate.Api.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>().HasKey(k => k.Id);
            modelBuilder.Entity<UserEntity>()
           .Property(f => f.Id)
           .ValueGeneratedOnAdd();


        }

    }
}
