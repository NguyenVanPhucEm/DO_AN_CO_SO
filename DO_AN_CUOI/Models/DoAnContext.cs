using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DO_AN_CUOI.Models;

public partial class DoAnContext : IdentityDbContext<ApplicationUser>
{
    public DoAnContext()
    {
    }

    public DoAnContext(DbContextOptions<DoAnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danhgia> Danhgia { get; set; }

    public virtual DbSet<Diemden> Diemdens { get; set; }

    public virtual DbSet<Diemkhoihanh> Diemkhoihanhs { get; set; }

    public virtual DbSet<Hinhanh> Hinhanhs { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Khachsan> Khachsans { get; set; }

    public virtual DbSet<Khuyenmai> Khuyenmais { get; set; }

    public virtual DbSet<Lichtrinh> Lichtrinhs { get; set; }

    public virtual DbSet<Loaitour> Loaitours { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieudattour> Phieudattours { get; set; }

    public virtual DbSet<Phuongtiendc> Phuongtiendcs { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-T0OM1L5\\SQLEXPRESS;Initial Catalog=DO_AN;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });

        modelBuilder.Entity<Danhgia>(entity =>
        {
            entity.HasKey(e => new { e.Makh, e.Matour });

            entity.ToTable("DANHGIA");

            entity.HasIndex(e => e.Makh, "ASSOCIATION_16_FK");

            entity.HasIndex(e => e.Matour, "ASSOCIATION_17_FK");

            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Matour).HasColumnName("MATOUR");
            entity.Property(e => e.Noidungdanhgia)
                .HasMaxLength(4000)
                .HasColumnName("NOIDUNGDANHGIA");
            entity.Property(e => e.Sosao).HasColumnName("SOSAO");
            entity.Property(e => e.Thoigiandanhgia)
                .HasColumnType("datetime")
                .HasColumnName("THOIGIANDANHGIA");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DANHGIA_ASSOCIATI_KHACHHAN");

            entity.HasOne(d => d.MatourNavigation).WithMany(p => p.Danhgia)
                .HasForeignKey(d => d.Matour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DANHGIA_ASSOCIATI_TOUR");
        });

        modelBuilder.Entity<Diemden>(entity =>
        {
            entity.HasKey(e => e.Madd);

            entity.ToTable("DIEMDEN");

            entity.Property(e => e.Madd).HasColumnName("MADD");
            entity.Property(e => e.Dc)
                .HasMaxLength(250)
                .HasColumnName("DC");
            entity.Property(e => e.Tendd)
                .HasMaxLength(250)
                .HasColumnName("TENDD");
            entity.Property(e => e.Thongtindiemden)
                .HasMaxLength(4000)
                .HasColumnName("THONGTINDIEMDEN");
        });

        modelBuilder.Entity<Diemkhoihanh>(entity =>
        {
            entity.HasKey(e => e.Madkh);

            entity.ToTable("DIEMKHOIHANH");

            entity.Property(e => e.Madkh).HasColumnName("MADKH");
            entity.Property(e => e.Dc)
                .HasMaxLength(250)
                .HasColumnName("DC");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tendkh)
                .HasMaxLength(250)
                .HasColumnName("TENDKH");
        });

        modelBuilder.Entity<Hinhanh>(entity =>
        {
            entity.HasKey(e => e.Mah);

            entity.ToTable("HINHANH");

            entity.HasIndex(e => e.Madd, "GHEP_FK");

            entity.Property(e => e.Mah).HasColumnName("MAH");
            entity.Property(e => e.Madd).HasColumnName("MADD");
            entity.Property(e => e.UrlHa)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("URL_HA");

            entity.HasOne(d => d.MaddNavigation).WithMany(p => p.Hinhanhs)
                .HasForeignKey(d => d.Madd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HINHANH_GHEP_DIEMDEN");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makh);

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Dc)
                .HasMaxLength(250)
                .HasColumnName("DC");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Sotourdadat).HasColumnName("SOTOURDADAT");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(250)
                .HasColumnName("TENKH");
        });

        modelBuilder.Entity<Khachsan>(entity =>
        {
            entity.HasKey(e => e.Maks);

            entity.ToTable("KHACHSAN");

            entity.Property(e => e.Maks).HasColumnName("MAKS");
            entity.Property(e => e.Dc)
                .HasMaxLength(250)
                .HasColumnName("DC");
            entity.Property(e => e.Tenks)
                .HasMaxLength(250)
                .HasColumnName("TENKS");
        });

        modelBuilder.Entity<Khuyenmai>(entity =>
        {
            entity.HasKey(e => e.Makm);

            entity.ToTable("KHUYENMAI");

            entity.Property(e => e.Makm).HasColumnName("MAKM");
            entity.Property(e => e.Dk)
                .HasMaxLength(250)
                .HasColumnName("DK");
            entity.Property(e => e.Phantramkm).HasColumnName("PHANTRAMKM");
            entity.Property(e => e.Tenkm)
                .HasMaxLength(250)
                .HasColumnName("TENKM");
        });

        modelBuilder.Entity<Lichtrinh>(entity =>
        {
            entity.HasKey(e => e.Malt);

            entity.ToTable("LICHTRINH");

            entity.HasIndex(e => e.Matour, "ASSOCIATION_13_FK");

            entity.HasIndex(e => e.Madd, "ASSOCIATION_14_FK");

            entity.HasIndex(e => e.Maks, "ASSOCIATION_15_FK");

            entity.Property(e => e.Malt).HasColumnName("MALT");
            entity.Property(e => e.Madd).HasColumnName("MADD");
            entity.Property(e => e.Maks).HasColumnName("MAKS");
            entity.Property(e => e.Matour).HasColumnName("MATOUR");
            entity.Property(e => e.Thongtinchitiet)
                .HasMaxLength(4000)
                .HasColumnName("THONGTINCHITIET");

            entity.HasOne(d => d.MaddNavigation).WithMany(p => p.Lichtrinhs)
                .HasForeignKey(d => d.Madd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LICHTRIN_ASSOCIATI_DIEMDEN");

            entity.HasOne(d => d.MaksNavigation).WithMany(p => p.Lichtrinhs)
                .HasForeignKey(d => d.Maks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LICHTRIN_ASSOCIATI_KHACHSAN");

            entity.HasOne(d => d.MatourNavigation).WithMany(p => p.Lichtrinhs)
                .HasForeignKey(d => d.Matour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LICHTRIN_ASSOCIATI_TOUR");
        });

        modelBuilder.Entity<Loaitour>(entity =>
        {
            entity.HasKey(e => e.Maloai);

            entity.ToTable("LOAITOUR");

            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(250)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv);

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Dc)
                .HasMaxLength(250)
                .HasColumnName("DC");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(50)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tennv)
                .HasMaxLength(50)
                .HasColumnName("TENNV");
        });

        modelBuilder.Entity<Phieudattour>(entity =>
        {
            entity.HasKey(e => e.Mapdt);

            entity.ToTable("PHIEUDATTOUR");

            entity.HasIndex(e => e.Makm, "AP_DUNG_FK");

            entity.HasIndex(e => e.Makh, "DAT_FK");

            entity.HasIndex(e => e.Manv, "KY_DUYET_FK");

            entity.HasIndex(e => e.Matour, "LAP_FK");

            entity.Property(e => e.Mapdt).HasColumnName("MAPDT");
            entity.Property(e => e.Dvt)
                .HasMaxLength(250)
                .HasColumnName("DVT");
            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Makm).HasColumnName("MAKM");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Matour).HasColumnName("MATOUR");
            entity.Property(e => e.Ngaydat)
                .HasColumnType("datetime")
                .HasColumnName("NGAYDAT");
            entity.Property(e => e.Song).HasColumnName("SONG");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Phieudattours)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEUDAT_DAT_KHACHHAN");

            entity.HasOne(d => d.MakmNavigation).WithMany(p => p.Phieudattours)
                .HasForeignKey(d => d.Makm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEUDAT_AP_DUNG_KHUYENMA");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Phieudattours)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEUDAT_KY_DUYET_NHANVIEN");

            entity.HasOne(d => d.MatourNavigation).WithMany(p => p.Phieudattours)
                .HasForeignKey(d => d.Matour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PHIEUDAT_LAP_TOUR");
        });

        modelBuilder.Entity<Phuongtiendc>(entity =>
        {
            entity.HasKey(e => e.Mapt);

            entity.ToTable("PHUONGTIENDC");

            entity.Property(e => e.Mapt).HasColumnName("MAPT");
            entity.Property(e => e.Tenpt)
                .HasMaxLength(250)
                .HasColumnName("TENPT");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Matour);

            entity.ToTable("TOUR");

            entity.HasIndex(e => e.Madkh, "BAT_DAU_FK");

            entity.HasIndex(e => e.Mapt, "DI_CHUYEN_FK");

            entity.HasIndex(e => e.Manv, "HUONG_DAN_FK");

            entity.HasIndex(e => e.Maloai, "THUOC_FK");

            entity.Property(e => e.Matour).HasColumnName("MATOUR");
            entity.Property(e => e.AnhAiien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ANH_AIIEN");
            entity.Property(e => e.Dvt)
                .HasMaxLength(250)
                .HasColumnName("DVT");
            entity.Property(e => e.Gia).HasColumnName("GIA");
            entity.Property(e => e.Madkh).HasColumnName("MADKH");
            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Manv).HasColumnName("MANV");
            entity.Property(e => e.Mapt).HasColumnName("MAPT");
            entity.Property(e => e.Ngaykh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYKH");
            entity.Property(e => e.Ngaykt)
                .HasColumnType("datetime")
                .HasColumnName("NGAYKT");
            entity.Property(e => e.Sochodadat).HasColumnName("SOCHODADAT");
            entity.Property(e => e.Sodem).HasColumnName("SODEM");
            entity.Property(e => e.Soluongtoida).HasColumnName("SOLUONGTOIDA");
            entity.Property(e => e.Songay).HasColumnName("SONGAY");
            entity.Property(e => e.Tentour)
                .HasMaxLength(250)
                .HasColumnName("TENTOUR");

            entity.HasOne(d => d.MadkhNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Madkh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TOUR_BAT_DAU_DIEMKHOI");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Maloai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TOUR_THUOC_LOAITOUR");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Manv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TOUR_HUONG_DAN_NHANVIEN");

            entity.HasOne(d => d.MaptNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Mapt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TOUR_DI_CHUYEN_PHUONGTI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
