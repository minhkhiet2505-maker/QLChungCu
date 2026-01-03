using System;
using System.Drawing;
using System.Windows.Forms;
using QLChungCu.BUS;
using System.Windows.Forms.DataVisualization.Charting; // Thư viện Chart

namespace QLChungCu
{
    public partial class FrmThongKe : Form
    {
        Service bus = new Service();
        Button btnXoa = new Button();

        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            // Code tạo nút Xóa (Giữ nguyên)
            btnXoa.Text = "XÓA HÓA ĐƠN";
            btnXoa.Size = new Size(150, 34);
            btnXoa.Location = new Point(600, 25);
            btnXoa.BackColor = Color.Red;
            btnXoa.ForeColor = Color.White;
            btnXoa.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Click += BtnXoa_Click;
            this.Controls.Add(btnXoa);

            LoadData(DateTime.Now.Month, DateTime.Now.Year);
            LoadChart(); // Load biểu đồ ngay khi mở
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDoanhThu.SelectedRows.Count > 0)
            {
                int maHD = Convert.ToInt32(dgvDoanhThu.SelectedRows[0].Cells[0].Value);
                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (bus.XoaHoaDon(maHD))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        btnXemDoanhThu_Click(null, null);
                        LoadChart(); // Cập nhật lại biểu đồ sau khi xóa
                    }
                    else MessageBox.Show("Xóa thất bại!");
                }
            }
            else MessageBox.Show("Vui lòng chọn dòng hóa đơn cần xóa!");
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            int thang = dtpThoiGian.Value.Month;
            int nam = dtpThoiGian.Value.Year;
            LoadData(thang, nam);
        }

        void LoadData(int t, int n)
        {
            dgvDoanhThu.DataSource = bus.GetDoanhThu(t, n);
            decimal tong = bus.TinhTongDoanhThu(t, n);
            lblTongThu.Text = "Tổng thu: " + tong.ToString("N0") + " VNĐ";
        }

        // --- [SỬA] DESIGN BIỂU ĐỒ KIỂU CHỨNG KHOÁN ---
        private void LoadChart()
        {
            int namHienTai = DateTime.Now.Year;
            var data = bus.GetDoanhThuTheoNam(namHienTai);

            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            
            // Design nền Chart cho "ngầu"
            chartDoanhThu.BackColor = Color.WhiteSmoke;
            chartDoanhThu.ChartAreas[0].BackColor = Color.White;

            Series series = new Series("Doanh Thu");
            // Đổi sang dạng SplineArea (Vùng cong mượt) hoặc Line (Đường) giống chứng khoán
            series.ChartType = SeriesChartType.SplineArea; 
            
            series.Color = Color.FromArgb(46, 204, 113); // Màu xanh lá tăng trưởng
            series.BorderWidth = 3;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0:N0}"; 
            
            // Hiệu ứng mờ dần xuống dưới (Gradient)
            series.BackGradientStyle = GradientStyle.TopBottom;
            series.BackSecondaryColor = Color.Transparent;

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartDoanhThu.Series.Add(series);
            chartDoanhThu.Titles.Add($"BIỂU ĐỒ TĂNG TRƯỞNG DOANH THU NĂM {namHienTai}");
            chartDoanhThu.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartDoanhThu.Titles[0].ForeColor = Color.DimGray;
        }
    }
}