using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLChungCu
{
    public partial class FrmMainDashboard : Form
    {
        private Form currentChildForm;

        public FrmMainDashboard()
        {
            InitializeComponent();

            // Cấu hình các nút bấm
            ConfigureBtn(btnTrangChu, new FrmTrangChu());
            ConfigureBtn(btnThuePhong, new FrmMain());
            ConfigureBtn(btnThongKe, new FrmThongKe());
            ConfigureBtn(btnDichVu, new FrmTinhTien());
        }

        private void ConfigureBtn(Guna2Button btn, Form formToOpen)
        {
            // Kiểm tra null để tránh lỗi nếu nút chưa load kịp
            if (btn == null) return;

            btn.Click += (s, e) => {
                // Reset màu nút cũ về xám
                if (btnTrangChu != null) btnTrangChu.ForeColor = Color.Silver;
                if (btnThuePhong != null) btnThuePhong.ForeColor = Color.Silver;
                if (btnThongKe != null) btnThongKe.ForeColor = Color.Silver;
                if (btnDichVu != null) btnDichVu.ForeColor = Color.Silver;

                // Highlight nút đang bấm màu trắng
                btn.ForeColor = Color.White;

                OpenChildForm(formToOpen);
            };
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null) currentChildForm.Close();

            // Tạo bản sao mới của Form con
            currentChildForm = (Form)Activator.CreateInstance(childForm.GetType());

            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;

            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(currentChildForm);
            pnlBody.Tag = currentChildForm;
            currentChildForm.BringToFront();
            currentChildForm.Show();
        }

        private void FrmMainDashboard_Load(object sender, EventArgs e)
        {
            // Mở trang chủ mặc định
            if (btnTrangChu != null) btnTrangChu.PerformClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {
           
        }

       
    }
}