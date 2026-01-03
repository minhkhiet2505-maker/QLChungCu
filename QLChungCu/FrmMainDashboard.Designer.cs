namespace QLChungCu
{
    partial class FrmMainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.btnDichVu = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnThuePhong = new Guna.UI2.WinForms.Guna2Button();
            this.btnTrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.pnlSidebar.Controls.Add(this.btnThoat);
            this.pnlSidebar.Controls.Add(this.btnDichVu);
            this.pnlSidebar.Controls.Add(this.btnThongKe);
            this.pnlSidebar.Controls.Add(this.btnThuePhong);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 766);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.BorderRadius = 20;
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(20, 650);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(200, 45);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "ĐĂNG XUẤT";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDichVu.FillColor = System.Drawing.Color.Transparent;
            this.btnDichVu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDichVu.ForeColor = System.Drawing.Color.Silver;
            this.btnDichVu.Location = new System.Drawing.Point(0, 280);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(240, 60);
            this.btnDichVu.TabIndex = 4;
            this.btnDichVu.Text = "Dịch Vụ & HĐ";
            this.btnDichVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDichVu.TextOffset = new System.Drawing.Point(20, 0);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FillColor = System.Drawing.Color.Transparent;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.Silver;
            this.btnThongKe.Location = new System.Drawing.Point(0, 220);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(240, 60);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.TextOffset = new System.Drawing.Point(20, 0);
            // 
            // btnThuePhong
            // 
            this.btnThuePhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThuePhong.FillColor = System.Drawing.Color.Transparent;
            this.btnThuePhong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThuePhong.ForeColor = System.Drawing.Color.Silver;
            this.btnThuePhong.Location = new System.Drawing.Point(0, 160);
            this.btnThuePhong.Name = "btnThuePhong";
            this.btnThuePhong.Size = new System.Drawing.Size(240, 60);
            this.btnThuePhong.TabIndex = 2;
            this.btnThuePhong.Text = "Thuê Phòng";
            this.btnThuePhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThuePhong.TextOffset = new System.Drawing.Point(20, 0);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrangChu.FillColor = System.Drawing.Color.Transparent;
            this.btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTrangChu.ForeColor = System.Drawing.Color.Silver;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 100);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(240, 60);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTrangChu.TextOffset = new System.Drawing.Point(20, 0);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(240, 100);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(240, 100);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "QUẢN LÝ\nCHUNG CƯ";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(240, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1176, 766);
            this.pnlBody.TabIndex = 1;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // FrmMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 766);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainDashboard";
            this.Load += new System.EventHandler(this.FrmMainDashboard_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2Button btnDichVu;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2Button btnThuePhong;
        private Guna.UI2.WinForms.Guna2Button btnTrangChu;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
    }
}