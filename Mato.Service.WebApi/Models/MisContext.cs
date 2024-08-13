using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mato.Service.WebApi.Models;

public partial class MisContext : DbContext
{
    public MisContext()
    {
    }

    public MisContext(DbContextOptions<MisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coupon> Coupons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=Root;Database=MIS");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Couponid).HasName("coupons_pkey");

            entity.ToTable("coupons");

            entity.Property(e => e.Couponid)
                .ValueGeneratedNever()
                .HasColumnName("couponid");
            entity.Property(e => e.Couponcode)
                .HasMaxLength(50)
                .HasColumnName("couponcode");
            entity.Property(e => e.Discountamount).HasColumnName("discountamount");
            entity.Property(e => e.Minamount).HasColumnName("minamount");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
