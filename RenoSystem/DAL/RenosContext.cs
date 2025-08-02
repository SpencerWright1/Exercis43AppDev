#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RenoSystem.Models;
namespace RenoSystem.DAL;

public partial class RenosContext : DbContext
{
    public RenosContext(DbContextOptions<RenosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DbVersion> DbVersions { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Labour> Labours { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK_Clients_ClientId");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(25);
            entity.Property(e => e.Contact)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(8);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Province)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(25);
            entity.Property(e => e.Unit).HasMaxLength(5);
        });

        modelBuilder.Entity<DbVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DbVersion_Id");

            entity.ToTable("DbVersion");

            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK_Jobs_JobId");

            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.PlanId)
                .IsRequired()
                .HasMaxLength(12);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobsClients_ClientId");
        });

        modelBuilder.Entity<Labour>(entity =>
        {
            entity.HasKey(e => e.LabourId).HasName("PK_Labours_LabourId");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.LabourCost).HasColumnType("money");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");

            entity.HasOne(d => d.Job).WithMany(p => p.Labours)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LaboursJobs_JobId");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("PK_Supplies_SupplyId");

            entity.Property(e => e.Material)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.MaterialCost).HasColumnType("money");

            entity.HasOne(d => d.Job).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SuppliesJobs_JobId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}