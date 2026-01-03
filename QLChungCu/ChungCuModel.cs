using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLChungCu
{
    public partial class ChungCuModel : DbContext
    {
        public ChungCuModel()
            : base("name=ChungCuModel")
        {
        }

        public virtual DbSet<CanHo> CanHoes { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiCanHo> LoaiCanHoes { get; set; }
        public virtual DbSet<SuDungDichVu> SuDungDichVus { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ToaNha> ToaNhas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanHo>()
                .Property(e => e.MaCanHo)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienPhong)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienDienNuoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.MaCanHo)
                .IsUnicode(false);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.GiaThue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HopDong>()
                .Property(e => e.TienCoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiCanHo>()
                .Property(e => e.GiaNgay)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoaiCanHo>()
                .Property(e => e.GiaThang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SuDungDichVu>()
                .Property(e => e.GiaTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
