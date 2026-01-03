using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QLChungCu 
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem bảng có dữ liệu không
          
            if (dgvHoaDon.Rows.Count > 0)
            {
                string maHD = "";
                string phong = "";

                if (dgvHoaDon.CurrentRow != null && dgvHoaDon.CurrentRow.Cells.Count > 1)
                {
                    maHD = dgvHoaDon.CurrentRow.Cells[0].Value?.ToString();
                    phong = dgvHoaDon.CurrentRow.Cells[1].Value?.ToString();
                }

                string thang = DateTime.Now.Month.ToString();
                string nam = DateTime.Now.Year.ToString();

                XuatHoaDonExcel(maHD, phong, thang, nam, dgvHoaDon);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!");
            }
        }

        public void XuatHoaDonExcel(string maHoaDon, string tenPhong, string thang, string nam, DataGridView dgvChiTiet)
        {
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null) { MessageBox.Show("Lỗi Excel!"); return; }

            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "HÓA ĐƠN";
                xlWorkSheet.Cells[3, 2] = "Mã HĐ: " + maHoaDon;
                xlWorkSheet.Cells[4, 2] = "Phòng: " + tenPhong;

           
                for (int i = 0; i < dgvChiTiet.Columns.Count; i++)
                {
                    xlWorkSheet.Cells[6, i + 1] = dgvChiTiet.Columns[i].HeaderText;
                }

           
                for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvChiTiet.Columns.Count; j++)
                    {
                        if (dgvChiTiet.Rows[i].Cells[j].Value != null)
                            xlWorkSheet.Cells[i + 7, j + 1] = dgvChiTiet.Rows[i].Cells[j].Value.ToString();
                    }
                }

                xlWorkSheet.Columns.AutoFit();
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}