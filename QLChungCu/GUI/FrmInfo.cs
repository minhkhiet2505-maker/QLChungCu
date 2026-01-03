using System;
using System.Windows.Forms;
using QLChungCu.BUS;

namespace QLChungCu
{
    public partial class FrmInfo : Form
    {
        string _maCan;
        Service bus = new Service();

        public FrmInfo(string maCan)
        {
            InitializeComponent();
            _maCan = maCan;
            this.Text = "Quản lý phòng: " + _maCan;
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            var p = bus.GetInfo(_maCan);
            if (p == null) return;

            // 1. Điền thông tin cơ bản
            txtMaCan.Text = p.MaCanHo;
            txtTang.Text = p.Tang.ToString();
            txtTrangThai.Text = p.TrangThai;
            txtLoaiPhong.Text = p.LoaiCanHo != null ? p.LoaiCanHo.TenLoai : "";
            txtGiaTien.Text = p.LoaiCanHo != null ? string.Format("{0:N0}", p.LoaiCanHo.GiaThang) : "";

            // 2. Kiểm tra trạng thái để hiển thị thông tin khách
            bool isDaThue = p.TrangThai == "Đã thuê";

            if (isDaThue)
            {
                var hd = bus.GetHopDong(_maCan);
                if (hd != null)
                {
                    
                    txtHoTen.Text = bus.GetTenKhach(_maCan);
                    txtCCCD.Text = bus.GetCCCD(_maCan); 
                    txtSDT.Text = bus.GetSDT(_maCan);   
                 

                    txtNgayVao.Text = hd.NgayBatDau.HasValue ? hd.NgayBatDau.Value.ToString("dd/MM/yyyy") : "";
                }
            }
            else
            {
                // Xóa trắng nếu phòng trống
                txtHoTen.Text = "";
                txtCCCD.Text = "";
                txtSDT.Text = "";
                txtNgayVao.Text = "";
            }

            // 3. Cập nhật trạng thái các nút bấm
            btnThue.Enabled = !isDaThue && p.TrangThai != "Sửa chữa";
            btnTra.Enabled = isDaThue;

            // Nút bảo trì
            if (p.TrangThai == "Sửa chữa") btnBaoTri.Text = "Hoàn tất Bảo trì";
            else btnBaoTri.Text = "Bảo trì";
            btnBaoTri.Enabled = !isDaThue;

            // 4. Load Dịch vụ để chọn
            try
            {
                cboDichVu.DataSource = bus.GetListDichVu();
                cboDichVu.DisplayMember = "TenDV";
                cboDichVu.ValueMember = "MaDV";
            }
            catch { }

            LoadDichVuDaDung();
        }

        void LoadDichVuDaDung()
        {
            // Load lưới và định dạng tiền
            dgvDichVu.DataSource = bus.GetDichVuDaDung(_maCan);
            if (dgvDichVu.Columns["GiaTien"] != null)
                dgvDichVu.Columns["GiaTien"].DefaultCellStyle.Format = "N0";
        }

        // --- CÁC SỰ KIỆN NÚT BẤM ---


        private void btnThemDV_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDichVu.SelectedValue == null) return;
                int maDV = (int)cboDichVu.SelectedValue;

                // Xử lý tiền: Xóa dấu phẩy, chống lỗi nhập chữ
                decimal gia = 0;
                string strGia = txtGiaDichVu.Text.Replace(",", "").Replace(".", "").Trim();

                if (string.IsNullOrEmpty(strGia))
                {
                    MessageBox.Show("Vui lòng nhập giá tiền!"); return;
                }

                if (!decimal.TryParse(strGia, out gia))
                {
                    MessageBox.Show("Giá tiền phải là số!"); return;
                }

                if (bus.ThemDichVu(_maCan, maDV, gia))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!");
                    txtGiaDichVu.Text = ""; // Xóa ô tiền sau khi thêm
                    LoadDichVuDaDung();
                }
                else MessageBox.Show("Lỗi: Phòng này chưa có Hợp đồng để thêm dịch vụ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                // Cảnh báo trước khi xóa
                if (MessageBox.Show("Bạn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvDichVu.SelectedRows[0].Cells[0].Value);
                    if (bus.XoaDichVu(id)) LoadDichVuDaDung();
                }
            }
            else MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
        }

        private void btnBaoTri_Click(object sender, EventArgs e)
        {
            bool isBaoTri = txtTrangThai.Text != "Sửa chữa";
            if (bus.SetTrangThaiBaoTri(_maCan, isBaoTri))
            {
                MessageBox.Show(isBaoTri ? "Đã chuyển sang trạng thái Sửa chữa!" : "Đã hoàn tất bảo trì!");
                this.Close();
            }
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            // Mở form Thuê nhà
            FrmThueNha f = new FrmThueNha(_maCan);
            f.ShowDialog();
            this.Close();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận TRẢ PHÒNG và KẾT THÚC hợp đồng?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bus.TraPhong(_maCan);
                MessageBox.Show("Đã trả phòng thành công!");
                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}