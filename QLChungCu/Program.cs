using System;
using System.Windows.Forms;

namespace QLChungCu
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Luôn bắt đầu từ màn hình Đăng nhập
            Application.Run(new FrmLogin());
        }
    }
}