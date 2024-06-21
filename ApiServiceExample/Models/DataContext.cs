using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiServiceExample.Models;

public partial class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<Customer> Customers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__UserInfo__C5B19602A2A396BA");

            entity.ToTable("Customer");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.FormattedUid)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasComputedColumnSql("(right('00000000'+CONVERT([varchar](8),[UID]),(8)))", true)
                .HasColumnName("Formatted_UID");
            entity.Property(e => e.Name).HasMaxLength(12);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
