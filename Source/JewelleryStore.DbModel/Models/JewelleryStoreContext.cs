using Microsoft.EntityFrameworkCore;

namespace JewelleryStore.DbModel
{
    public partial class JewelleryStoreContext : DbContext
    {
        public JewelleryStoreContext(DbContextOptions<JewelleryStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
