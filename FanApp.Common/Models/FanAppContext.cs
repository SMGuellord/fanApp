using FanApp.Common.Models.Database.HasDataExtensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FanApp.Common.Models
{
    public class FanAppContext : DbContext
    {
        public FanAppContext([NotNull]DbContextOptions<FanAppContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public void EnsureMigrationIsApplied()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyHasData();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
