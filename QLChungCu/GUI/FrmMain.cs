using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using QLChungCu.BUS;

namespace QLChungCu
{
    public partial class FrmMain : Form
    {
        private Service bus = new Service();
        private int currentTang = 1;

        public FrmMain()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadDanhSachTang();
            LoadPhongTheoTang(1); // Mặc định load tầng 1
        }

        // --- LOAD DANH SÁCH TẦNG (CỘT TRÁI) ---
        public void LoadDanhSachTang()
        {
            flpTang.Controls.Clear();
            var listTang = bus.GetTang(); // 1 -> 9
            foreach (var tang in listTang)
            {
                Button btn = new Button();
                btn.Text = "Tầng " + tang;
                btn.Width = 170;
                btn.Height = 50;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(52, 152, 219);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.Margin = new Padding(0, 0, 0, 10);

                btn.Click += (s, ev) => {
                    currentTang = tang;
                    txtTimKiem.Clear();
                    LoadPhongTheoTang(tang);
                };

                flpTang.Controls.Add(btn);
            }
        }

        // --- LOAD PHÒNG THEO TẦNG ---
        public void LoadPhongTheoTang(int tang)
        {
            var list = bus.GetPhong(tang);
            RenderPhong(list);
        }

     
        private void btnTim_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim();

            // Nếu ô tìm trống thì load lại tầng hiện tại
            if (string.IsNullOrEmpty(kw))
            {
                LoadPhongTheoTang(currentTang);
                return;
            }

            // Gọi hàm Search mới (Tìm Mã + Trạng Thái + Tên Khách)
            var list = bus.Search(kw);

            if (list.Count == 0) MessageBox.Show("Không tìm thấy phòng hoặc tên khách hàng nào!");
            RenderPhong(list);
        }

        // --- HÀM VẼ NÚT PHÒNG ---
        private void RenderPhong(List<CanHo> list)
        {
            flpCanHo.Controls.Clear();

            foreach (var p in list)
            {
                Button btn = new Button();
                btn.Text = $"{p.MaCanHo}\n({p.TrangThai})";
                btn.Size = new Size(160, 120);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Margin = new Padding(15);

                // Tô màu
                if (p.TrangThai == "Đã thuê") btn.BackColor = Color.FromArgb(231, 76, 60); // Đỏ
                else if (p.TrangThai == "Sửa chữa") btn.BackColor = Color.FromArgb(241, 194, 50); // Vàng
                else btn.BackColor = Color.FromArgb(46, 204, 113); // Xanh

                // Sự kiện Click mở Info
                btn.Click += (s, ev) => {
                    FrmInfo f = new FrmInfo(p.MaCanHo);
                    f.StartPosition = FormStartPosition.CenterScreen;

                    f.ShowDialog();

                  
                    bus = new Service();

                    // Nếu đang tìm kiếm dở thì tìm lại để cập nhật trạng thái
                    if (txtTimKiem.Text.Length > 0)
                        btnTim_Click(null, null);
                    else
                        LoadPhongTheoTang(currentTang);
                };

                flpCanHo.Controls.Add(btn);
            }
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e) { }
    }
}