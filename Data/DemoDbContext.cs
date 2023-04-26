using Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options): base(options)
        {
        }
        public DbSet<Receivers> Receivers { get; set; }
        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receivers>().ToTable("Receivers");
            modelBuilder.Entity<Messages>().ToTable("Messages");
        }
    }
}
