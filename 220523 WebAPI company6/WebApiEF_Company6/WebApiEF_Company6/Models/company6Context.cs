using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiEF_Company6.Models
{
    public partial class company6Context : DbContext
    {
        public company6Context()
        {
        }

        public company6Context(DbContextOptions<company6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Coworker> Coworkers { get; set; }
        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=company6;user=root;password=;ssl mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coworker>(entity =>
            {
                entity.ToTable("coworker");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Notebook>(entity =>
            {
                entity.ToTable("notebook");

                entity.HasIndex(e => e.CoworkerId, "notebook_coworkerId_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.CoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("coworkerId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.HasOne(d => d.Coworker)
                    .WithMany(p => p.Notebooks)
                    .HasForeignKey(d => d.CoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("notebook_coworkerId_fk");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.HasIndex(e => e.CoworkerId, "phone_coworkerId_fk");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.CoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("coworkerId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.HasOne(d => d.Coworker)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phone_coworkerId_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
