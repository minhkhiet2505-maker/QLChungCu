namespace QLChungCu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CanHo",
                c => new
                    {
                        MaCanHo = c.String(nullable: false, maxLength: 20),
                        MaToa = c.Int(),
                        MaLoai = c.Int(),
                        Tang = c.Int(),
                        SoPhong = c.String(maxLength: 10),
                        TrangThai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCanHo)
                .ForeignKey("dbo.LoaiCanHo", t => t.MaLoai)
                .ForeignKey("dbo.ToaNha", t => t.MaToa)
                .Index(t => t.MaToa)
                .Index(t => t.MaLoai);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        MaCanHo = c.String(maxLength: 20),
                        Thang = c.Int(nullable: false),
                        Nam = c.Int(nullable: false),
                        SoDien = c.Int(nullable: false),
                        SoNuoc = c.Int(nullable: false),
                        GiaDien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaNuoc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiaPhong = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhiDichVu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 0),
                        DaThanhToan = c.Boolean(nullable: false),
                        NgayLap = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.CanHo", t => t.MaCanHo)
                .Index(t => t.MaCanHo);
            
            CreateTable(
                "dbo.HopDong",
                c => new
                    {
                        MaHopDong = c.Int(nullable: false, identity: true),
                        MaCanHo = c.String(maxLength: 20),
                        MaCuDan = c.Int(),
                        NgayLap = c.DateTime(storeType: "date"),
                        NgayBatDau = c.DateTime(nullable: false, storeType: "date"),
                        NgayKetThuc = c.DateTime(nullable: false, storeType: "date"),
                        GiaThue = c.Decimal(precision: 18, scale: 0),
                        TienCoc = c.Decimal(precision: 18, scale: 0),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.MaHopDong)
                .ForeignKey("dbo.CanHo", t => t.MaCanHo)
                .ForeignKey("dbo.CuDan", t => t.MaCuDan)
                .Index(t => t.MaCanHo)
                .Index(t => t.MaCuDan);
            
            CreateTable(
                "dbo.CuDan",
                c => new
                    {
                        MaCuDan = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        NgaySinh = c.DateTime(storeType: "date"),
                        GioiTinh = c.String(maxLength: 10),
                        SDT = c.String(maxLength: 15, unicode: false),
                        CCCD = c.String(nullable: false, maxLength: 20, unicode: false),
                        QueQuan = c.String(maxLength: 200),
                        Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaCuDan);
            
            CreateTable(
                "dbo.LoaiCanHo",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(nullable: false, maxLength: 50),
                        DienTich = c.Double(),
                        GiaDeXuat = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.ToaNha",
                c => new
                    {
                        MaToa = c.Int(nullable: false, identity: true),
                        TenToa = c.String(nullable: false, maxLength: 100),
                        DiaChi = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaToa);
            
            CreateTable(
                "dbo.ChiTietHoaDon",
                c => new
                    {
                        MaCTHD = c.Int(nullable: false, identity: true),
                        MaHoaDon = c.Int(),
                        MaDichVu = c.Int(),
                        SoLuongCu = c.Int(),
                        SoLuongMoi = c.Int(),
                        SoLuongSuDung = c.Int(),
                        ThanhTien = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.DichVu", t => t.MaDichVu)
                .ForeignKey("dbo.HoaDon", t => t.MaHoaDon)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaDichVu);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDichVu = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false, maxLength: 100),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 0),
                        DonViTinh = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaDichVu);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 100, unicode: false),
                        HoTenHienThi = c.String(maxLength: 100),
                        Quyen = c.Int(),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDon", "MaHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietHoaDon", "MaDichVu", "dbo.DichVu");
            DropForeignKey("dbo.CanHo", "MaToa", "dbo.ToaNha");
            DropForeignKey("dbo.CanHo", "MaLoai", "dbo.LoaiCanHo");
            DropForeignKey("dbo.HopDong", "MaCuDan", "dbo.CuDan");
            DropForeignKey("dbo.HopDong", "MaCanHo", "dbo.CanHo");
            DropForeignKey("dbo.HoaDon", "MaCanHo", "dbo.CanHo");
            DropIndex("dbo.ChiTietHoaDon", new[] { "MaDichVu" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "MaHoaDon" });
            DropIndex("dbo.HopDong", new[] { "MaCuDan" });
            DropIndex("dbo.HopDong", new[] { "MaCanHo" });
            DropIndex("dbo.HoaDon", new[] { "MaCanHo" });
            DropIndex("dbo.CanHo", new[] { "MaLoai" });
            DropIndex("dbo.CanHo", new[] { "MaToa" });
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DichVu");
            DropTable("dbo.ChiTietHoaDon");
            DropTable("dbo.ToaNha");
            DropTable("dbo.LoaiCanHo");
            DropTable("dbo.CuDan");
            DropTable("dbo.HopDong");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CanHo");
        }
    }
}
