using System;
using System.Collections.Generic;
using System.Linq;

namespace QLChungCu.BUS
{
    // Tạo 1 class nhỏ để hứng dữ liệu CCCD (giúp tránh lỗi HopDong thiếu cột)
    public class ThongTinKhach
    {
        public string HoTen { get; set; }
        public string SDT { get; set; }
    }

    public class Service
    {
        private ChungCuModel db = new ChungCuModel();

        public Service() { }

        // --- CÁC HÀM CŨ GIỮ NGUYÊN ---
        public TaiKhoan CheckLogin(string u, string p) => db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == u && x.MatKhau == p);
        public List<int> GetTang() => Enumerable.Range(1, 9).ToList();
        public List<CanHo> GetPhong(int tang) => db.CanHoes.Where(p => p.Tang == tang).ToList();
        public List<CanHo> GetAllPhong() => db.CanHoes.ToList();
        public CanHo GetInfo(string ma) => db.CanHoes.FirstOrDefault(p => p.MaCanHo == ma);
        public HopDong GetHopDong(string ma) => db.HopDongs.Where(h => h.MaCanHo == ma).OrderByDescending(h => h.NgayBatDau).FirstOrDefault();

        // --- HÀM TÌM KIẾM ---
        public List<CanHo> Search(string kw)
        {
            string k = kw.ToLower();
            var list1 = db.CanHoes.Where(p => p.MaCanHo.ToLower().Contains(k) || p.TrangThai.ToLower().Contains(k)).ToList();
            try
            {
                string sql = $"SELECT MaCanHo FROM HopDong WHERE HoTen LIKE N'%{kw}%'";
                List<string> listMaPhong = db.Database.SqlQuery<string>(sql).ToList();
                var list2 = db.CanHoes.Where(p => listMaPhong.Contains(p.MaCanHo)).ToList();
                return list1.Union(list2).Distinct().ToList();
            }
            catch { return list1; }
        }

        // --- HÀM THUÊ PHÒNG ---
        public bool ThuePhong(string ma, string ten, string cmnd, string sdt, DateTime nt, DateTime nTra, decimal tc)
        {
            try
            {
                var p = db.CanHoes.FirstOrDefault(x => x.MaCanHo == ma);
                if (p != null)
                {
                    p.TrangThai = "Đã thuê";
                    HopDong hd = new HopDong();
                    hd.MaCanHo = ma; hd.NgayBatDau = nt; hd.NgayKetThuc = nTra; hd.TienCoc = tc;
                    db.HopDongs.Add(hd);
                    db.SaveChanges();
                    // Update cột mới bằng SQL
                    string sql = $"UPDATE HopDong SET HoTen = N'{ten}', CCCD = '{cmnd}', SDT = '{sdt}' WHERE MaHopDong = {hd.MaHopDong}";
                    db.Database.ExecuteSqlCommand(sql);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        public string GetTenKhach(string maPhong)
        {
            try
            {
                string sql = "SELECT TOP 1 HoTen FROM HopDong WHERE MaCanHo = '" + maPhong + "' ORDER BY MaHopDong DESC";
                string ten = db.Database.SqlQuery<string>(sql).FirstOrDefault();
                if (!string.IsNullOrEmpty(ten)) return ten;
                var hd = GetHopDong(maPhong);
                if (hd != null) return "HĐ Số " + hd.MaHopDong;
                return "Chưa có khách";
            }
            catch { return "Lỗi đọc tên"; }
        }

        // --- [FIX LỖI] TÌM KHÁCH QUEN BẰNG SQL TRỰC TIẾP ---
        public ThongTinKhach FindKhachByCCCD(string cccd)
        {
            try
            {
                // Thay vì trả về HopDong (gây lỗi), ta trả về class ThongTinKhach
                string sql = $"SELECT TOP 1 HoTen, SDT FROM HopDong WHERE CCCD = '{cccd}' ORDER BY MaHopDong DESC";
                return db.Database.SqlQuery<ThongTinKhach>(sql).FirstOrDefault();
            }
            catch { return null; }
        }

        // --- BIỂU ĐỒ ---
        public Dictionary<string, decimal> GetDoanhThuTheoNam(int nam)
        {
            var data = new Dictionary<string, decimal>();
            var listHD = db.HoaDons.Where(x => x.Nam == nam).ToList();
            for (int i = 1; i <= 12; i++)
            {
                decimal tong = listHD.Where(h => h.Thang == i).Sum(h => (decimal?)h.TongTien) ?? 0;
                data.Add("T" + i, tong);
            }
            return data;
        }

        // --- CÁC HÀM PHỤ KHÁC ---
        public string GetCCCD(string maPhong) { try { return db.Database.SqlQuery<string>($"SELECT TOP 1 CCCD FROM HopDong WHERE MaCanHo = '{maPhong}' ORDER BY MaHopDong DESC").FirstOrDefault() ?? ""; } catch { return ""; } }
        public string GetSDT(string maPhong) { try { return db.Database.SqlQuery<string>($"SELECT TOP 1 SDT FROM HopDong WHERE MaCanHo = '{maPhong}' ORDER BY MaHopDong DESC").FirstOrDefault() ?? ""; } catch { return ""; } }
        public bool TraPhong(string ma) { var p = db.CanHoes.FirstOrDefault(x => x.MaCanHo == ma); if (p != null) { p.TrangThai = "Trống"; db.SaveChanges(); return true; } return false; }
        public bool SetTrangThaiBaoTri(string ma, bool isBaoTri) { var p = db.CanHoes.FirstOrDefault(x => x.MaCanHo == ma); if (p != null) { p.TrangThai = isBaoTri ? "Sửa chữa" : "Trống"; db.SaveChanges(); return true; } return false; }
        public List<DichVu> GetListDichVu() => db.DichVus.ToList();
        public object GetDichVuDaDung(string maPhong) { var hd = GetHopDong(maPhong); if (hd == null) return new List<object>(); var list = from sd in db.SuDungDichVus join dv in db.DichVus on sd.MaDV equals dv.MaDV where sd.MaHopDong == hd.MaHopDong select new { sd.ID, dv.TenDV, sd.GiaTien }; return list.ToList(); }
        public bool ThemDichVu(string maPhong, int maDV, decimal gia) { var hd = GetHopDong(maPhong); if (hd == null) return false; SuDungDichVu sd = new SuDungDichVu(); sd.MaHopDong = hd.MaHopDong; sd.MaDV = maDV; sd.GiaTien = gia; db.SuDungDichVus.Add(sd); db.SaveChanges(); return true; }
        public bool XoaDichVu(int id) { var dv = db.SuDungDichVus.Find(id); if (dv != null) { db.SuDungDichVus.Remove(dv); db.SaveChanges(); return true; } return false; }
        public decimal GetTongTienDichVu(string maPhong) { var hd = GetHopDong(maPhong); if (hd == null) return 0; return db.SuDungDichVus.Where(sd => sd.MaHopDong == hd.MaHopDong).Sum(sd => (decimal?)sd.GiaTien) ?? 0; }
        public bool LuuHoaDon(string maPhong, int soDien, int soNuoc, decimal tPhong, decimal tDienNuoc, decimal tDichVu, decimal tongCong) { try { var hdong = GetHopDong(maPhong); if (hdong == null) return false; HoaDon hd = new HoaDon(); hd.MaHopDong = hdong.MaHopDong; hd.NgayLap = DateTime.Now; hd.Thang = DateTime.Now.Month; hd.Nam = DateTime.Now.Year; hd.TienPhong = tPhong; hd.TienDienNuoc = tDienNuoc; hd.TongTien = tongCong; hd.SoDien = soDien; hd.SoNuoc = soNuoc; hd.TrangThai = 1; db.HoaDons.Add(hd); db.SaveChanges(); return true; } catch { return false; } }
        public bool XoaHoaDon(int maHD) { try { var hd = db.HoaDons.Find(maHD); if (hd != null) { db.HoaDons.Remove(hd); db.SaveChanges(); return true; } return false; } catch { return false; } }
        public object GetDoanhThu(int thang, int nam) => db.HoaDons.Where(x => x.Thang == thang && x.Nam == nam).ToList();
        public decimal TinhTongDoanhThu(int thang, int nam) => db.HoaDons.Where(x => x.Thang == thang && x.Nam == nam).Sum(x => (decimal?)x.TongTien) ?? 0;
        // Mở file BUS/Service.cs và thêm các hàm này vào cuối class Service
        public int CountTongPhong() => db.CanHoes.Count();
        public int CountPhongTrong() => db.CanHoes.Count(x => x.TrangThai == "Trống");
        public int CountPhongDaThue() => db.CanHoes.Count(x => x.TrangThai == "Đã thuê");
        public int CountKhachHang() => db.HopDongs.Count(); // Hoặc đếm số hợp đồng đang active
        public decimal GetDoanhThuThangNay()
        {
            int t = DateTime.Now.Month;
            int n = DateTime.Now.Year;
            return db.HoaDons.Where(x => x.Thang == t && x.Nam == n).Sum(x => (decimal?)x.TongTien) ?? 0;
        }
    }
}