using System;
using System.Drawing;
using System.Windows.Forms;
using QLChungCu.BUS;

namespace QLChungCu
{
    public partial class FrmTrangChu : Form
    {
        Service bus = new Service();

        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy số liệu từ Database
                int tongPhong = bus.CountTongPhong();
                int daThue = bus.CountPhongDaThue();
                int phongTrong = bus.CountPhongTrong();
                decimal doanhThu = bus.GetDoanhThuThangNay();

                // Hiển thị lên các Label
                lblTongPhong.Text = tongPhong.ToString();
                lblDaThue.Text = daThue.ToString();
                lblPhongTrong.Text = phongTrong.ToString();
                lblDoanhThu.Text = doanhThu.ToString("N0") + " VNĐ";

                // Tính phần trăm lấp đầy để vẽ thanh tiến trình 
                if (tongPhong > 0)
                {
                    int percent = (daThue * 100) / tongPhong;
                    lblTyLe.Text = $"Tỷ lệ lấp đầy: {percent}%";
                }
            }
            catch
            {
                lblDoanhThu.Text = "Chưa kết nối DB";
            }
        }
    }
}