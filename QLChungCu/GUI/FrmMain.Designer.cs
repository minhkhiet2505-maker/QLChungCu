namespace QLChungCu
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnTim = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flpTang = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCanHo = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.btnTim);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1218, 65);
            this.pnlTop.TabIndex = 2;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // btnTim
            // 
            this.btnTim.BorderRadius = 15;
            this.btnTim.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(672, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 45);
            this.btnTim.TabIndex = 0;
            this.btnTim.Text = "TÌM KIẾM";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderRadius = 15;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.Location = new System.Drawing.Point(354, 12);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập mã phòng...";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 45);
            this.txtTimKiem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÝ CHO THUÊ";
            // 
            // flpTang
            // 
            this.flpTang.AutoScroll = true;
            this.flpTang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.flpTang.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpTang.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTang.Location = new System.Drawing.Point(0, 65);
            this.flpTang.Name = "flpTang";
            this.flpTang.Padding = new System.Windows.Forms.Padding(10);
            this.flpTang.Size = new System.Drawing.Size(231, 604);
            this.flpTang.TabIndex = 1;
            this.flpTang.WrapContents = false;
            // 
            // flpCanHo
            // 
            this.flpCanHo.AutoScroll = true;
            this.flpCanHo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpCanHo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCanHo.Location = new System.Drawing.Point(231, 65);
            this.flpCanHo.Name = "flpCanHo";
            this.flpCanHo.Padding = new System.Windows.Forms.Padding(20);
            this.flpCanHo.Size = new System.Drawing.Size(987, 604);
            this.flpCanHo.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1218, 669);
            this.Controls.Add(this.flpCanHo);
            this.Controls.Add(this.flpTang);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnTim;
        private System.Windows.Forms.FlowLayoutPanel flpTang; // Panel chứa tầng
        private System.Windows.Forms.FlowLayoutPanel flpCanHo; // Panel chứa phòng
    }
}