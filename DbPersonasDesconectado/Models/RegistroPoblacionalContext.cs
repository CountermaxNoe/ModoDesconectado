using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DbPersonasDesconectado.Models;

public partial class RegistroPoblacionalContext : DbContext
{
    public RegistroPoblacionalContext()
    {
    }

    public RegistroPoblacionalContext(DbContextOptions<RegistroPoblacionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personas> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=Tormenta.12;user=root;port=3307;database=RegistroPoblacional", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Personas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personas");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Edad).HasColumnType("int(11)");
            entity.Property(e => e.Genero).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
