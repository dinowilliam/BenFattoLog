using BenFattoLog.DAL.Repositorys.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BenFattoLog.DAL.Infra {
    public partial class BenFattoLogContext : DbContext {
        public BenFattoLogContext() {
        }

        public BenFattoLogContext(DbContextOptions<BenFattoLogContext> options)
            : base(options) {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=BenFattoLog;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Log>(entity => {
                entity.ToTable("Log");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessLog).HasMaxLength(2048);

                entity.Property(e => e.IpAddress).IsRequired();

                entity.Property(e => e.OccurrenceeDate).HasColumnType("timestamp with time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
