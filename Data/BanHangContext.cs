using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using shoppingweb3.Models;

namespace shoppingweb3.Data;

public partial class BanHangContext : DbContext
{
    public BanHangContext()
    {
    }

    public BanHangContext(DbContextOptions<BanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danhmuc> Danhmucs { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-DC9MJ86E\\SQLEXPRESS;Database=banhang2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Danhmuc>(entity =>
        {
            entity.HasKey(e => e.Madm).HasName("PK__danhmuc__7A21E0202AFCAA65");

            entity.ToTable("danhmuc");

            entity.Property(e => e.Madm).HasColumnName("madm");
            entity.Property(e => e.Tendm)
                .HasMaxLength(100)
                .HasColumnName("tendm");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK__sanpham__7A217672F8D75755");

            entity.ToTable("sanpham");

            entity.Property(e => e.Masp).HasColumnName("masp");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.Madm).HasColumnName("madm");
            entity.Property(e => e.Tensp)
                .HasMaxLength(200)
                .HasColumnName("tensp");

            entity.HasOne(d => d.MadmNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Madm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sanpham_danhmuc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
