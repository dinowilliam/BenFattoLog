using Microsoft.EntityFrameworkCore;

#nullable disable
namespace BenFattoLog.DAL.Infra.Contexts {
    
    using BenFattoLog.DAL.Repositorys.Models;

    public partial class BenFattoLogQueriesContext : DbContext {
                
        public BenFattoLogQueriesContext(DbContextOptions<BenFattoLogQueriesContext> options)
            : base(options) {
        }

        public virtual DbSet<LogPersistance> Logs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<LogPersistance>(entity => {
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
