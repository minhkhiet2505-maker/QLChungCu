namespace QLChungCu
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.lblTongThu = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn thời gian:";
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.CustomFormat = "MM/yyyy";
            this.dtpThoiGian.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGian.Location = new System.Drawing.Point(200, 25);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(200, 34);
            this.dtpThoiGian.TabIndex = 1;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(420, 25);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(150, 34);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem Doanh Thu";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXemDoanhThu_Click);
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(35, 80);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1022, 244);
            this.dgvDoanhThu.TabIndex = 3;
            // 
            // lblTongThu
            // 
            this.lblTongThu.AutoSize = true;
            this.lblTongThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongThu.Location = new System.Drawing.Point(30, 550);
            this.lblTongThu.Name = "lblTongThu";
            this.lblTongThu.Size = new System.Drawing.Size(261, 37);
            this.lblTongThu.TabIndex = 4;
            this.lblTongThu.Text = "Tổng thu: 000 VNĐ";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(573, 401);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(502, 237);
            this.chartDoanhThu.TabIndex = 5;
            this.chartDoanhThu.Text = "chartDoanhThu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(594, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 28);
            this.label2.TabIndex = 6;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1179, 650);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.lblTongThu);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dtpThoiGian);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmThongKe";
            this.Text = "Thống Kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label lblTongThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu; // Đã đổi tên
        private System.Windows.Forms.Label label2;
    }
}