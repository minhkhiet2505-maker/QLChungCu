using System;
using System.Drawing;
using System.Windows.Forms;
using QLChungCu.BUS;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
using System.Threading.Tasks; // Thêm cái này để chạy luồng tắt cam

namespace QLChungCu
{
    public partial class FrmThueNha : Form
    {
        string _maCan;
        Service bus = new Service();

        // Biến Camera
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        Timer timerScan;

        // Constructor 1: Có tham số mã căn
        public FrmThueNha(string maCan)
        {
            InitializeComponent();
            _maCan = maCan;
            this.Text = "Đăng ký thuê phòng: " + _maCan;
        }

        // Constructor 2: Mặc định
        public FrmThueNha() { InitializeComponent(); }

        private void FrmThueNha_Load(object sender, EventArgs e)
        {
            nmrThoiHan.Value = 12;

            // Khởi động Camera
            try
            {
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo device in filterInfoCollection)
                    cboCamera.Items.Add(device.Name);

                if (cboCamera.Items.Count > 0) cboCamera.SelectedIndex = 0;
                else lblStatus.Text = "Không tìm thấy Camera!";

                // Cấu hình Timer quét
                timerScan = new Timer();
                timerScan.Interval = 200; // Quét nhanh hơn (0.2s/lần)
                timerScan.Tick += TimerScan_Tick;
            }
            catch { lblStatus.Text = "Lỗi khởi động Cam"; }
        }

        // --- NÚT BẬT CAMERA ---
        private void btnScan_Click(object sender, EventArgs e)
        {
            if (cboCamera.Items.Count == 0) return;

            // Tắt cam cũ
            StopCamera();

            // Khởi tạo cam mới
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);

           
            try
            {
                VideoCapabilities bestResolution = captureDevice.VideoCapabilities[0];
                foreach (var cap in captureDevice.VideoCapabilities)
                {
                    if (cap.FrameSize.Width > bestResolution.FrameSize.Width)
                    {
                        bestResolution = cap;
                    }
                }
                captureDevice.VideoResolution = bestResolution;
            }
            catch { } 

            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timerScan.Start();
            lblStatus.Text = "Đang quét... (Chế độ HD)";
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ptbCam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // --- HÀM QUÉT 
        private void TimerScan_Tick(object sender, EventArgs e)
        {
            if (ptbCam.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                reader.Options.TryHarder = true; 

                Result result = reader.Decode((Bitmap)ptbCam.Image);

                if (result != null)
                {
                    // 1. Dừng quét ngay
                    timerScan.Stop();
                    SystemSounds.Beep.Play();

                    // 2. Tắt Camera an toàn 
                    StopCameraSafe();

                    // 3. Hiện thông báo kết quả
                    MessageBox.Show("Đã quét được:\n" + result.ToString(), "Check Camera");

                    // 4. Xử lý dữ liệu
                    XuLyDuLieuCCCD(result.ToString());
                }
            }
        }

        // --- HÀM TẮT CAMERA AN TOÀN ---
        private void StopCamera()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }

        private void StopCameraSafe()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                // Ngắt sự kiện nhận ảnh để màn hình dừng lại ngay
                captureDevice.NewFrame -= CaptureDevice_NewFrame;

                // Tắt thiết bị ở luồng khác
                Task.Run(() => {
                    captureDevice.SignalToStop();
                    captureDevice.WaitForStop();
                    captureDevice = null;
                });
            }
        }

        // --- XỬ LÝ DỮ LIỆU CCCD ---
        private void XuLyDuLieuCCCD(string rawData)
        {
            try
            {
                string[] parts = rawData.Split('|');
                // Format CCCD thường: Số|ID cũ|Tên|NgàySinh|GiớiTinh|ĐịaChỉ|NgàyCấp
                if (parts.Length >= 3)
                {
                    txtCCCD.Text = parts[0];
                    txtHoTen.Text = parts[2];

                    if (parts.Length > 5) txtQueQuan.Text = parts[5];

                    // Tìm khách cũ
                    var khachCu = bus.FindKhachByCCCD(parts[0]);

                    if (khachCu != null)
                    {
                        txtSDT.Text = khachCu.SDT;
                        lblStatus.Text = "✅ Đã tìm thấy khách cũ.";
                    }
                    else
                    {
                        lblStatus.Text = "✅ Khách mới. Nhập SĐT đi.";
                        txtSDT.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã QR không đúng chuẩn CCCD!\nNội dung: " + rawData);
                }
            }
            catch (Exception ex) // Đã dùng biến ex để hiện lỗi -> Hết cảnh báo
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message);
            }
        }

        // --- KHI TẮT FORM ---
        private void FrmThueNha_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            if (timerScan != null) timerScan.Stop();
        }

        // --- NÚT LƯU ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text)) { MessageBox.Show("Thiếu tên!"); return; }
                if (string.IsNullOrWhiteSpace(txtSDT.Text)) { MessageBox.Show("Thiếu SĐT!"); return; }

                decimal tienCoc = 0;
                // Xử lý tiền cọc (xóa dấu phẩy, chữ đ)
                string strCoc = txtTienCoc.Text.Replace(",", "").Replace(".", "").Replace("đ", "").Replace(" ", "").Trim();
                if (!string.IsNullOrEmpty(strCoc)) decimal.TryParse(strCoc, out tienCoc);

                // Tính ngày
                DateTime ngayBatDau = dtpNgayBatDau.Value;
                DateTime ngayKetThuc = ngayBatDau.AddMonths((int)nmrThoiHan.Value);

                if (bus.ThuePhong(_maCan, txtHoTen.Text, txtCCCD.Text, txtSDT.Text, ngayBatDau, ngayKetThuc, tienCoc))
                {
                    MessageBox.Show("Thuê thành công!");
                    this.Close();
                }
                else MessageBox.Show("Lỗi lưu Database!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();
        private void groupBox2_Enter(object sender, EventArgs e) { }
    }
}