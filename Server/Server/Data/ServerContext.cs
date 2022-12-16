using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options)
            : base(options) { }

        public DbSet<Server.Models.Batch> Batch { get; set; } = default!;
        public DbSet<Server.Models.Data> Data { get; set; }
        public DbSet<Server.Models.Screw> Screw { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Data>().HasIndex(x => x.ScrewId).IsUnique(false);
            modelBuilder.Entity<Screw>().HasIndex(x => x.BatchId).IsUnique(false);
            modelBuilder.Entity<Screw>().Property(x => x.ScrewId).ValueGeneratedNever();
            modelBuilder.Entity<Screw>().Property(x => x.EndTs).HasDefaultValue("1970-01-01 00:00:00");
            modelBuilder.Entity<Batch>().Property(x => x.BatchId).ValueGeneratedNever();
            modelBuilder.Entity<Batch>().Property(x => x.EndTs).HasDefaultValue("1970-01-01 00:00:00");
            base.OnModelCreating(modelBuilder);
        }
    }
}
