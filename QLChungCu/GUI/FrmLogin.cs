using System;
using System.Windows.Forms;
using QLChungCu.BUS;

namespace QLChungCu
{
    public partial class FrmLogin : Form
    {
        private Service bus = new Service();

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim(); 
            string pass = txtPass.Text.Trim(); 

            var result = bus.CheckLogin(user, pass);

            if (result != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                this.Hide();
                FrmMainDashboard ds = new FrmMainDashboard();
                ds.ShowDialog();
                this.Close();
            }
            else
            {
                // Đây chính là lỗi bạn đang gặp ở ảnh image_b4097d.jpg
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Để trống để tránh lỗi Designer
        }

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}