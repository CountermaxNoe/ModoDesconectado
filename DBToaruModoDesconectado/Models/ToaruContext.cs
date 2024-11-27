using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DBToaruModoDesconectado.Models;

public partial class ToaruContext : DbContext
{
    public ToaruContext()
    {
    }

    public ToaruContext(DbContextOptions<ToaruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Espers> Espers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;password=Tormenta.12;user=root;port=3307;database=Toaru", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.3.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Espers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("espers");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Apodo)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Habilidad).HasMaxLength(60);
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(300)
                .HasColumnName("ImagenURL");
            entity.Property(e => e.Nivel).HasColumnType("int(11)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .HasDefaultValueSql("'0'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
