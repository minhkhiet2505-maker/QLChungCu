namespace QLChungCu
{
    partial class FrmTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblTongPhong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblDaThue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblPhongTrong = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTyLe = new System.Windows.Forms.Label();
            this.labelHello = new System.Windows.Forms.Label();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.SuspendLayout();

            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelHello.ForeColor = System.Drawing.Color.DimGray;
            this.labelHello.Location = new System.Drawing.Point(30, 20);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(430, 46);
            this.labelHello.TabIndex = 0;
            this.labelHello.Text = "Tổng Quan Tình Hình Chung Cư";

            // --- CARD 1: TỔNG SỐ PHÒNG (Màu Xanh Dương) ---
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlCard1.Controls.Add(this.lblTongPhong);
            this.pnlCard1.Controls.Add(this.label2);
            this.pnlCard1.Location = new System.Drawing.Point(40, 90);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(250, 150);
            this.pnlCard1.TabIndex = 1;
            // 
            // lblTongPhong
            // 
            this.lblTongPhong.AutoSize = true;
            this.lblTongPhong.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTongPhong.ForeColor = System.Drawing.Color.White;
            this.lblTongPhong.Location = new System.Drawing.Point(20, 50);
            this.lblTongPhong.Name = "lblTongPhong";
            this.lblTongPhong.Size = new System.Drawing.Size(46, 54);
            this.lblTongPhong.TabIndex = 1;
            this.lblTongPhong.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng Số Phòng";

            // --- CARD 2: ĐÃ CHO THUÊ (Màu Đỏ Cam) ---
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlCard2.Controls.Add(this.lblDaThue);
            this.pnlCard2.Controls.Add(this.label4);
            this.pnlCard2.Location = new System.Drawing.Point(320, 90);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(250, 150);
            this.pnlCard2.TabIndex = 2;
            // 
            // lblDaThue
            // 
            this.lblDaThue.AutoSize = true;
            this.lblDaThue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDaThue.ForeColor = System.Drawing.Color.White;
            this.lblDaThue.Location = new System.Drawing.Point(20, 50);
            this.lblDaThue.Name = "lblDaThue";
            this.lblDaThue.Size = new System.Drawing.Size(46, 54);
            this.lblDaThue.TabIndex = 1;
            this.lblDaThue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(20, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đã Cho Thuê";

            // --- CARD 3: PHÒNG TRỐNG (Màu Xanh Lá) ---
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlCard3.Controls.Add(this.lblPhongTrong);
            this.pnlCard3.Controls.Add(this.label6);
            this.pnlCard3.Location = new System.Drawing.Point(600, 90);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(250, 150);
            this.pnlCard3.TabIndex = 3;
            // 
            // lblPhongTrong
            // 
            this.lblPhongTrong.AutoSize = true;
            this.lblPhongTrong.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblPhongTrong.ForeColor = System.Drawing.Color.White;
            this.lblPhongTrong.Location = new System.Drawing.Point(20, 50);
            this.lblPhongTrong.Name = "lblPhongTrong";
            this.lblPhongTrong.Size = new System.Drawing.Size(46, 54);
            this.lblPhongTrong.TabIndex = 1;
            this.lblPhongTrong.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(20, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Còn Trống (Sẵn)";

            // --- CARD 4: DOANH THU (Màu Tím) ---
            this.pnlCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlCard4.Controls.Add(this.lblDoanhThu);
            this.pnlCard4.Controls.Add(this.label8);
            this.pnlCard4.Location = new System.Drawing.Point(40, 270);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(530, 150);
            this.pnlCard4.TabIndex = 4;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThu.Location = new System.Drawing.Point(20, 50);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(137, 54);
            this.lblDoanhThu.TabIndex = 1;
            this.lblDoanhThu.Text = "0 VNĐ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(20, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 28);
            this.label8.TabIndex = 0;
            this.label8.Text = "Doanh Thu Tháng Này";

            // 
            // lblTyLe
            // 
            this.lblTyLe.AutoSize = true;
            this.lblTyLe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.lblTyLe.ForeColor = System.Drawing.Color.Gray;
            this.lblTyLe.Location = new System.Drawing.Point(600, 270);
            this.lblTyLe.Name = "lblTyLe";
            this.lblTyLe.Size = new System.Drawing.Size(126, 28);
            this.lblTyLe.TabIndex = 5;
            this.lblTyLe.Text = "Tỷ lệ lấp đầy:";

            // 
            // FrmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.lblTyLe);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.labelHello);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrangChu";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.FrmTrangChu_Load);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTongPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblDaThue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblPhongTrong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTyLe;
        private System.Windows.Forms.Label labelHello;
    }
}