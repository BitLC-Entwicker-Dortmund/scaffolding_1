using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace scaffolding_1.Models;

public partial class WeltenretterContext : DbContext
{
    public WeltenretterContext()
    {
    }

    public WeltenretterContext(DbContextOptions<WeltenretterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agressor> Agressors { get; set; }

    public virtual DbSet<Bedrohung> Bedrohungs { get; set; }

    public virtual DbSet<Held> Helds { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Weltenretter;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agressor>(entity =>
        {
            entity.HasKey(e => e.AgressorId).HasName("pk_agressor");

            entity.ToTable("Agressor");

            entity.Property(e => e.AgressorId).HasColumnName("agressor_id");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nachname");
            entity.Property(e => e.Spezialitaet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spezialitaet");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vorname");
        });

        modelBuilder.Entity<Bedrohung>(entity =>
        {
            entity.HasKey(e => e.BedrohungId).HasName("pk_bedrohung");

            entity.ToTable("Bedrohung");

            entity.Property(e => e.BedrohungId).HasColumnName("bedrohung_id");
            entity.Property(e => e.AgressorId).HasColumnName("agressor_id");
            entity.Property(e => e.Existent).HasColumnName("existent");
            entity.Property(e => e.HeldId).HasColumnName("held_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Agressor).WithMany(p => p.Bedrohungs)
                .HasForeignKey(d => d.AgressorId)
                .HasConstraintName("fk_bedrohung_agressor");

            entity.HasOne(d => d.Held).WithMany(p => p.Bedrohungs)
                .HasForeignKey(d => d.HeldId)
                .HasConstraintName("fk_bedrohung_held");
        });

        modelBuilder.Entity<Held>(entity =>
        {
            entity.HasKey(e => e.HeldId).HasName("pk_held");

            entity.ToTable("Held");

            entity.Property(e => e.HeldId).HasColumnName("held_id");
            entity.Property(e => e.Beruf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("beruf");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nachname");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vorname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
