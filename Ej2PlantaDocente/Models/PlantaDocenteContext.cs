using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Ej2PlantaDocente.Models;

public partial class PlantaDocenteContext : DbContext
{
    public PlantaDocenteContext()
    {
    }

    public PlantaDocenteContext(DbContextOptions<PlantaDocenteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coordinaciones> Coordinaciones { get; set; }

    public virtual DbSet<Docentes> Docentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=root;user=root;database=PlantaDocente", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Coordinaciones>(entity =>
        {
            entity.HasKey(e => e.Clave).HasName("PRIMARY");

            entity
                .ToTable("coordinaciones")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Clave)
                .HasMaxLength(1)
                .HasColumnName("clave")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
        });

        modelBuilder.Entity<Docentes>(entity =>
        {
            entity.HasKey(e => e.Clave).HasName("PRIMARY");

            entity
                .ToTable("docentes")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdCoordinacion, "fkDocenteCoordinacion_idx");

            entity.Property(e => e.Clave)
                .ValueGeneratedNever()
                .HasColumnName("clave");
            entity.Property(e => e.IdCoordinacion)
                .HasMaxLength(1)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            entity.HasOne(d => d.IdCoordinacionNavigation).WithMany(p => p.Docentes)
                .HasForeignKey(d => d.IdCoordinacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkDocenteCoordinacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
