using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Models;

public partial class DbreporteGastosContext : DbContext
{
    public DbreporteGastosContext()
    {
    }

    public DbreporteGastosContext(DbContextOptions<DbreporteGastosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GastoGeneral> GastoGenerals { get; set; }

    public virtual DbSet<TipoGasto> TipoGastos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GastoGeneral>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PK__gasto_ge__C630244D8CF4A50A");

            entity.ToTable("gasto_general");

            entity.Property(e => e.ConceptoGasto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoGastoNavigation).WithMany(p => p.GastoGenerals)
                .HasForeignKey(d => d.IdTipoGasto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__gasto_gen__IdTip__4BAC3F29");
        });

        modelBuilder.Entity<TipoGasto>(entity =>
        {
            entity.HasKey(e => e.IdTipoGasto).HasName("PK__TipoGast__656E88E43F731A95");

            entity.ToTable("TipoGasto");

            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
