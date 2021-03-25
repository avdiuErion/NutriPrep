using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NutriPrep.Models
{
    public partial class NutriPrepContext : DbContext
    {
        public NutriPrepContext()
        {
        }

        public NutriPrepContext(DbContextOptions<NutriPrepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Shujtum> Shujta { get; set; }
        public virtual DbSet<Ushqimi> Ushqimis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RGAU3V4;Initial Catalog=NutriPrep;User ID=erion;Password=sql***;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shujtum>(entity =>
            {
                entity.HasKey(e => e.ShujtaId)
                    .HasName("PK__Shujta__B860460D107E51E3");

                entity.Property(e => e.ShujtaId).HasColumnName("ShujtaID");

                entity.Property(e => e.EmriShujtes).HasMaxLength(20);
            });

            modelBuilder.Entity<Ushqimi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ushqimi");

                entity.Property(e => e.EmriUshqimit).HasMaxLength(50);

                entity.Property(e => e.ShujtaId).HasColumnName("ShujtaID");

                entity.Property(e => e.ShujtaUshqimId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ShujtaUshqimID");

                entity.HasOne(d => d.Shujta)
                    .WithMany()
                    .HasForeignKey(d => d.ShujtaId)
                    .HasConstraintName("FK__Ushqimi__ShujtaI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
