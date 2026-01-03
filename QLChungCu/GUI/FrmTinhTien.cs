using System;
using System.Drawing;
using System.Windows.Forms;
using QLChungCu.BUS;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace QLChungCu
{
    public partial class FrmTinhTien : Form
    {
        Service bus = new Service();
        decimal _giaPhong = 0; decimal _phiDV = 0; int _dienCu = 0; int _nuocCu = 0;

        public FrmTinhTien() { InitializeComponent(); }

        private void FrmTinhTien_Load(object sender, EventArgs e)
        {
            try
            {
                cboMaPhong.DataSource = bus.GetAllPhong();
                cboMaPhong.DisplayMember = "MaCanHo";
                cboMaPhong.ValueMember = "MaCanHo";
            }
            catch { }
        }

        private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPhong.SelectedValue == null) return;
            string maPhong = cboMaPhong.SelectedValue.ToString();
            txtDienMoi.Text = ""; txtNuocMoi.Text = ""; _dienCu = 0; _nuocCu = 0;

            var p = bus.GetInfo(maPhong);
            if (p != null && p.LoaiCanHo != null) _giaPhong = (decimal)p.LoaiCanHo.GiaThang; else _giaPhong = 0;
            _phiDV = bus.GetTongTienDichVu(maPhong);

            string tenKhach = bus.GetTenKhach(maPhong);
            lblTitle.Text = "HÓA ĐƠN: " + tenKhach.ToUpper();
            lblChiSoCu.Text = $"(Số cũ: Điện {_dienCu} - Nước {_nuocCu})";
            TinhToan();
        }

        private void txtInput_TextChanged(object sender, EventArgs e) => TinhToan();

        void TinhToan()
        {
            try
            {
                int dMoi = 0; int.TryParse(txtDienMoi.Text, out dMoi);
                int nMoi = 0; int.TryParse(txtNuocMoi.Text, out nMoi);
                int tieuThuDien = dMoi - _dienCu; if (tieuThuDien < 0) tieuThuDien = 0;
                int tieuThuNuoc = nMoi - _nuocCu; if (tieuThuNuoc < 0) tieuThuNuoc = 0;
                decimal tienDien = tieuThuDien * 3000;
                decimal tienNuoc = tieuThuNuoc * 15000;
                decimal tong = _giaPhong + tienDien + tienNuoc + _phiDV;

                lblTienPhong.Text = string.Format("{0:N0} đ", _giaPhong);
                lblTienDien.Text = string.Format("{0:N0} đ ({1} số)", tienDien, tieuThuDien);
                lblTienNuoc.Text = string.Format("{0:N0} đ ({1} m3)", tienNuoc, tieuThuNuoc);
                lblPhiDV.Text = string.Format("{0:N0} đ", _phiDV);
                lblTongCong.Text = string.Format("TỔNG: {0:N0} VNĐ", tong);
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaPhong.SelectedValue == null) return;

            // Hỏi trước khi thực hiện
            if (MessageBox.Show("Bạn có muốn Lưu hóa đơn và Xuất file Excel không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maPhong = cboMaPhong.SelectedValue.ToString();
                int dMoi = 0; int.TryParse(txtDienMoi.Text, out dMoi);
                int nMoi = 0; int.TryParse(txtNuocMoi.Text, out nMoi);
                int soDien = dMoi - _dienCu; if (soDien < 0) soDien = 0;
                int soNuoc = nMoi - _nuocCu; if (soNuoc < 0) soNuoc = 0;
                decimal tDien = soDien * 3000;
                decimal tNuoc = soNuoc * 15000;
                decimal tong = _giaPhong + tDien + tNuoc + _phiDV;

                // 1. Lưu vào Database trước
                if (bus.LuuHoaDon(maPhong, soDien, soNuoc, _giaPhong, tDien + tNuoc, _phiDV, tong))
                {
                    MessageBox.Show("Đã lưu vào Database thành công! Tiếp theo hãy chọn nơi lưu file Excel.", "Thông báo");

                    // 2. Gọi hàm xuất Excel (Hàm này giờ sẽ hiện bảng chọn folder)
                    XuatExcel(maPhong, bus.GetTenKhach(maPhong), soDien, soNuoc, _giaPhong, tDien, tNuoc, _phiDV, tong);
                }
                else MessageBox.Show("Lỗi: Không tìm thấy Hợp đồng để lưu!");
            }
        }

        // --- HÀM XUẤT EXCEL MỚI (CHỌN FOLDER -> TỰ TẠO FOLDER CON) ---
        private void XuatExcel(string phong, string tenKhach, int soDien, int soNuoc, decimal tPhong, decimal tDien, decimal tNuoc, decimal tDV, decimal tong)
        {
            try
            {
                // [MỚI] Dùng Dialog chọn thư mục thay vì lấy đường dẫn cứng
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Chọn thư mục gốc để lưu Hóa Đơn";
                    folderDialog.ShowNewFolderButton = true;

                    // Nếu người dùng chọn OK
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedPath = folderDialog.SelectedPath;

                        // Tự động tạo folder con theo tháng năm: VD: Hoadon-12-2025
                        string subFolderName = $"Hoadon-{DateTime.Now.Month}-{DateTime.Now.Year}";
                        string finalFolderPath = Path.Combine(selectedPath, subFolderName);

                        // Kiểm tra và tạo folder con nếu chưa có
                        if (!Directory.Exists(finalFolderPath))
                        {
                            Directory.CreateDirectory(finalFolderPath);
                        }

                        // Đặt tên file
                        string fileName = $"HD_{phong}_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.xlsx";
                        string fullPath = Path.Combine(finalFolderPath, fileName);

                        // --- Bắt đầu xử lý Excel ---
                        Excel.Application xlApp = new Excel.Application();
                        if (xlApp == null) { MessageBox.Show("Máy chưa cài Excel!"); return; }

    
                        xlApp.DisplayAlerts = false;

                        Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
                        Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                        // Ghi dữ liệu
                        xlWorkSheet.Cells[1, 1] = "HÓA ĐƠN TIỀN NHÀ - " + DateTime.Now.ToString("MM/yyyy");
                        xlWorkSheet.Cells[2, 1] = "Phòng: " + phong;
                        xlWorkSheet.Cells[3, 1] = "Khách hàng: " + tenKhach;

                        xlWorkSheet.Cells[5, 1] = "Khoản mục"; xlWorkSheet.Cells[5, 2] = "Số lượng"; xlWorkSheet.Cells[5, 3] = "Thành tiền";

                        int r = 6;
                        xlWorkSheet.Cells[r, 1] = "Tiền Phòng"; xlWorkSheet.Cells[r, 3] = tPhong; r++;
                        xlWorkSheet.Cells[r, 1] = "Tiền Điện"; xlWorkSheet.Cells[r, 2] = soDien; xlWorkSheet.Cells[r, 3] = tDien; r++;
                        xlWorkSheet.Cells[r, 1] = "Tiền Nước"; xlWorkSheet.Cells[r, 2] = soNuoc; xlWorkSheet.Cells[r, 3] = tNuoc; r++;
                        xlWorkSheet.Cells[r, 1] = "Dịch Vụ"; xlWorkSheet.Cells[r, 3] = tDV; r++;

                        xlWorkSheet.Cells[r + 1, 1] = "TỔNG CỘNG"; xlWorkSheet.Cells[r + 1, 3] = tong;
                        xlWorkSheet.Columns.AutoFit();

                        // Lưu file
                        xlWorkBook.SaveAs(fullPath);

                        // Mở file lên cho xem
                        xlApp.Visible = true;
                        if (MessageBox.Show("Xuất file thành công!\nĐường dẫn: " + fullPath + "\n\nBạn có muốn mở thư mục lưu trữ không?",
                            "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("explorer.exe", finalFolderPath);
                        }

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Excel: " + ex.Message);
            }
        }

        // Hàm dọn dẹp bộ nhớ Excel
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}