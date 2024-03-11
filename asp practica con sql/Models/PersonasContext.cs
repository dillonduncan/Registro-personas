using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace asp_practica_con_sql.Models;

public partial class PersonasContext : DbContext
{
    public PersonasContext()
    {
    }

    public PersonasContext(DbContextOptions<PersonasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TablaGenero> TablaGeneros { get; set; }

    public virtual DbSet<TablaPersona> TablaPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NDND5BN; DataBase=personas; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TablaGenero>(entity =>
        {
            entity.ToTable("tabla_generos");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("nombre_genero");
        });

        modelBuilder.Entity<TablaPersona>(entity =>
        {
            entity.ToTable("tabla_personas");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EdadPersona).HasColumnName("edad_persona");
            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre_persona");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.TablaPersonas)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tabla_personas_tabla_generos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
