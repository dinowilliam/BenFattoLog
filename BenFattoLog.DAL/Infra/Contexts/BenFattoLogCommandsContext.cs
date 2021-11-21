using Microsoft.EntityFrameworkCore;

#nullable disable
namespace BenFattoLog.DAL.Infra.Contexts {
    using BenFattoLog.DAL.Repositorys.Models;

    public partial class BenFattoLogCommandsContext : DbContext {
                
        public BenFattoLogCommandsContext(DbContextOptions<MicroservicesSpikeCommandsContext> options)
            : base(options) {
        }

        public virtual DbSet<LogPersistance> Logs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<LogPersistance>(entity => {
                entity.ToTable("Log");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(2048);

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.OccurrenceeDate).HasColumnType("timestamp with time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
