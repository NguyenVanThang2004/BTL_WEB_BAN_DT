﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_WEB_BAN_DT.Models;

public partial class BtlLtwQlbdtContext : DbContext
{
    public BtlLtwQlbdtContext()
    {
    }

    public BtlLtwQlbdtContext(DbContextOptions<BtlLtwQlbdtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnhSanPham> AnhSanPhams { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }

    public virtual DbSet<DanhGium> DanhGia { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LichSuHoatDong> LichSuHoatDongs { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Rom> Roms { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-L8MQCH21;Initial Catalog=BTL_LTW_QLBDT;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnhSanPham>(entity =>
        {
            entity.HasKey(e => e.TenFile).HasName("PK__AnhSanPh__4E25C6E32D5FAD42");

            entity.ToTable("AnhSanPham");

            entity.Property(e => e.TenFile).HasMaxLength(255);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.ViTri).HasMaxLength(255);
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietGioHang", tb => tb.HasTrigger("theoDoiCustomerGioHang"));

            entity.Property(e => e.MaGioHang).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);

            entity.HasOne(d => d.MaGioHangNavigation).WithMany()
                .HasForeignKey(d => d.MaGioHang)
                .HasConstraintName("FK_ChiTietGioHang_GioHang");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany()
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK_ChiTietGioHang_SanPham");
        });

        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChiTietHoaDonBan", tb => tb.HasTrigger("TinhTienHDB"));

            entity.Property(e => e.DonGiaCuoi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany()
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK_ChiTietHoaDonBan_HoaDon");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany()
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK_ChiTietHoaDonBan_SanPham");
        });

        modelBuilder.Entity<DanhGium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("theoDoiCustomerDanhGia"));

            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.NoiDung).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany()
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK_DanhGia_HoaDon");

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany()
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK_DanhGia_TaiKhoan");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang).HasName("PK__GioHang__F5001DA336A737E1");

            entity.ToTable("GioHang");

            entity.Property(e => e.MaGioHang).HasMaxLength(50);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK_GioHang_TaiKhoan");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13BD41B7EFA");

            entity.ToTable("HoaDonBan", tb => tb.HasTrigger("theoDoiCustomerMuaSanPham"));

            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.KhuyenMai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(100);
            entity.Property(e => e.ThoiGianLap).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_HoaDonBan_KhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_HoaDonBan_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5281F9701");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK_KhachHang_TaiKhoan");
        });

        modelBuilder.Entity<LichSuHoatDong>(entity =>
        {
            entity.HasKey(e => e.MaHoatDong).HasName("PK__LichSuHo__BD808BE7F4D17BB1");

            entity.ToTable("LichSuHoatDong");

            entity.Property(e => e.MaHoatDong).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.LoaiHoatDong).HasMaxLength(100);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.ThoiGianThucHien).HasColumnType("datetime");

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.LichSuHoatDongs)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK_LichSuHoatDong_TaiKhoan");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.MaMau).HasName("PK__MauSac__3A5BBB7DC2494EF1");

            entity.ToTable("MauSac");

            entity.Property(e => e.MaMau).HasMaxLength(50);
            entity.Property(e => e.TenMau).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA4778F249B9");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);

            entity.HasOne(d => d.TenDangNhapNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.TenDangNhap)
                .HasConstraintName("FK_NhanVien_TaiKhoan");
        });

        modelBuilder.Entity<Rom>(entity =>
        {
            entity.HasKey(e => e.MaRom).HasName("PK__ROM__396399A2A324F685");

            entity.ToTable("ROM");

            entity.Property(e => e.MaRom)
                .HasMaxLength(50)
                .HasColumnName("MaROM");
            entity.Property(e => e.ThongSo).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442D8DEFF8E2");

            entity.ToTable("SanPham", tb => tb.HasTrigger("theoDoiAdminSanPham"));

            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.Camera).HasMaxLength(50);
            entity.Property(e => e.Chip).HasMaxLength(50);
            entity.Property(e => e.DonGiaBanGoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonGiaBanRa).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Hang).HasMaxLength(100);
            entity.Property(e => e.KhuyenMai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.KichThuoc).HasMaxLength(100);
            entity.Property(e => e.MaMau).HasMaxLength(50);
            entity.Property(e => e.MaRom)
                .HasMaxLength(50)
                .HasColumnName("MaROM");
            entity.Property(e => e.ManHinh).HasMaxLength(100);
            entity.Property(e => e.Pin).HasMaxLength(50);
            entity.Property(e => e.Ram)
                .HasMaxLength(50)
                .HasColumnName("RAM");
            entity.Property(e => e.TenSanPham).HasMaxLength(100);

            entity.HasOne(d => d.MaMauNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaMau)
                .HasConstraintName("FK_SanPham_MauSac");

            entity.HasOne(d => d.MaRomNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaRom)
                .HasConstraintName("FK_SanPham_ROM");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenDangNhap).HasName("PK__TaiKhoan__55F68FC1886212F1");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
