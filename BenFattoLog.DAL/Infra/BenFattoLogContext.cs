using BenFattoLog.DAL.Repositorys.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable
namespace BenFattoLog.DAL.Infra {
    public partial class BenFattoLogContext : DbContext {

        private string connectionString = "Host=127.0.0.1;Database=BenFattoLog;Username=postgres;Password=admin";

        public BenFattoLogContext() {
        }

        public BenFattoLogContext(DbContextOptions<BenFattoLogContext> options)
            : base(options) {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseNpgsql(connectionString);
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
