using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mato.Service.WebApi.Models;

public partial class sampleContext : DbContext
{
    public sampleContext()
    {
    }

    public sampleContext(DbContextOptions<sampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Itemdetail> Itemdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sample;Username=postgres;Password=anuhya");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Couponid).HasName("coupon_pkey");

            entity.ToTable("coupon");

            entity.Property(e => e.Couponid)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(1000L, 2L, null, null, null, null)
                .HasColumnName("couponid");
            entity.Property(e => e.Couponcode)
                .HasColumnType("character varying")
                .HasColumnName("couponcode");
            entity.Property(e => e.Discountamount).HasColumnName("discountamount");
            entity.Property(e => e.Minamount).HasColumnName("minamount");
        });

        modelBuilder.Entity<Itemdetail>(entity =>
        {
            entity.HasKey(e => e.Uniqueid).HasName("itemdetails_pkey");

            entity.ToTable("itemdetails");

            entity.Property(e => e.Uniqueid)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(200L, 2L, null, null, null, null)
                .HasColumnName("uniqueid");
            entity.Property(e => e.Itemname)
                .HasColumnType("character varying")
                .HasColumnName("itemname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
