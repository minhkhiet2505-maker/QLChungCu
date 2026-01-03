namespace QLChungCu
{
    partial class FrmTinhTien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMaPhong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDienMoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNuocMoi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTienDien = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTienNuoc = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPhiDV = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.btnLuuIn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblChiSoCu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Location = new System.Drawing.Point(180, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TỔNG TIỀN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(50, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Khu vực Nhập liệu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(80, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn Phòng:";
            // 
            // cboMaPhong
            // 
            this.cboMaPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaPhong.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboMaPhong.FormattingEnabled = true;
            this.cboMaPhong.Location = new System.Drawing.Point(250, 127);
            this.cboMaPhong.Name = "cboMaPhong";
            this.cboMaPhong.Size = new System.Drawing.Size(250, 36);
            this.cboMaPhong.TabIndex = 3;
            this.cboMaPhong.SelectedIndexChanged += new System.EventHandler(this.cboMaPhong_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(80, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện mới (số):";
            // 
            // txtDienMoi
            // 
            this.txtDienMoi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDienMoi.Location = new System.Drawing.Point(250, 177);
            this.txtDienMoi.Name = "txtDienMoi";
            this.txtDienMoi.Size = new System.Drawing.Size(250, 34);
            this.txtDienMoi.TabIndex = 5;
            this.txtDienMoi.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(80, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số nước mới (m3):";
            // 
            // txtNuocMoi
            // 
            this.txtNuocMoi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNuocMoi.Location = new System.Drawing.Point(250, 227);
            this.txtNuocMoi.Name = "txtNuocMoi";
            this.txtNuocMoi.Size = new System.Drawing.Size(250, 34);
            this.txtNuocMoi.TabIndex = 7;
            this.txtNuocMoi.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(50, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "2. Khu vực Hiển thị tiền:";
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTienPhong.Location = new System.Drawing.Point(250, 330);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(24, 28);
            this.lblTienPhong.TabIndex = 12;
            this.lblTienPhong.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.Location = new System.Drawing.Point(80, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 28);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tiền Điện:";
            // 
            // lblTienDien
            // 
            this.lblTienDien.AutoSize = true;
            this.lblTienDien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTienDien.Location = new System.Drawing.Point(250, 370);
            this.lblTienDien.Name = "lblTienDien";
            this.lblTienDien.Size = new System.Drawing.Size(23, 28);
            this.lblTienDien.TabIndex = 14;
            this.lblTienDien.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.Location = new System.Drawing.Point(80, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 28);
            this.label11.TabIndex = 15;
            this.label11.Text = "Tiền Nước:";
            // 
            // lblTienNuoc
            // 
            this.lblTienNuoc.AutoSize = true;
            this.lblTienNuoc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTienNuoc.Location = new System.Drawing.Point(250, 410);
            this.lblTienNuoc.Name = "lblTienNuoc";
            this.lblTienNuoc.Size = new System.Drawing.Size(23, 28);
            this.lblTienNuoc.TabIndex = 16;
            this.lblTienNuoc.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label13.Location = new System.Drawing.Point(80, 450);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 28);
            this.label13.TabIndex = 17;
            this.label13.Text = "Phí Dịch vụ:";
            // 
            // lblPhiDV
            // 
            this.lblPhiDV.AutoSize = true;
            this.lblPhiDV.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPhiDV.Location = new System.Drawing.Point(250, 450);
            this.lblPhiDV.Name = "lblPhiDV";
            this.lblPhiDV.Size = new System.Drawing.Size(23, 28);
            this.lblPhiDV.TabIndex = 18;
            this.lblPhiDV.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(50, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 23);
            this.label15.TabIndex = 19;
            this.label15.Text = "3. Tổng cộng:";
            // 
            // lblTongCong
            // 
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongCong.Location = new System.Drawing.Point(180, 540);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(248, 46);
            this.lblTongCong.TabIndex = 21;
            this.lblTongCong.Text = "TỔNG: 0 VNĐ";
            // 
            // btnLuuIn
            // 
            this.btnLuuIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLuuIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuIn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLuuIn.Location = new System.Drawing.Point(520, 540);
            this.btnLuuIn.Name = "btnLuuIn";
            this.btnLuuIn.Size = new System.Drawing.Size(180, 50);
            this.btnLuuIn.TabIndex = 22;
            this.btnLuuIn.Text = "Lưu và In Hóa Đơn";
            this.btnLuuIn.UseVisualStyleBackColor = false;
            this.btnLuuIn.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(80, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tiền Phòng:";
            // 
            // lblChiSoCu
            // 
            this.lblChiSoCu.AutoSize = true;
            this.lblChiSoCu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblChiSoCu.ForeColor = System.Drawing.Color.Gray;
            this.lblChiSoCu.Location = new System.Drawing.Point(520, 185);
            this.lblChiSoCu.Name = "lblChiSoCu";
            this.lblChiSoCu.Size = new System.Drawing.Size(126, 20);
            this.lblChiSoCu.TabIndex = 23;
            this.lblChiSoCu.Text = "(Tự động trừ số cũ)";
            // 
            // FrmTinhTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 650);
            this.Controls.Add(this.lblChiSoCu);
            this.Controls.Add(this.btnLuuIn);
            this.Controls.Add(this.lblTongCong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblPhiDV);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTienNuoc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTienDien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTienPhong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNuocMoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDienMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMaPhong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmTinhTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính Tiền";
            this.Load += new System.EventHandler(this.FrmTinhTien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle, label1, label2, label3, label4;
        private System.Windows.Forms.ComboBox cboMaPhong;
        private System.Windows.Forms.TextBox txtDienMoi, txtNuocMoi;
        private System.Windows.Forms.Label label7, label5, lblTienPhong, label9, lblTienDien;
        private System.Windows.Forms.Label label11, lblTienNuoc, label13, lblPhiDV;
        private System.Windows.Forms.Label label15, lblTongCong, lblChiSoCu;
        private System.Windows.Forms.Button btnLuuIn;
    }
}