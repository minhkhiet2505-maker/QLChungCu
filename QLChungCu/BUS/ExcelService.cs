using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QLChungCu.BUS
{
    public class ExcelService
    {
        public void XuatHoaDonRaExcel(HoaDon hd, string tenPhong, string tieuDe)
        {
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null) { MessageBox.Show("Máy chưa cài Excel!"); return; }

            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = tieuDe.ToUpper();
                xlWorkSheet.Cells[3, 1] = "Phòng: " + tenPhong;
                xlWorkSheet.Cells[4, 1] = "Tổng tiền: " + string.Format("{0:N0} VNĐ", hd.TongTien);

                xlApp.Visible = true;
            }
            catch { }
            finally
            {
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);
            }
        }

        private void ReleaseObject(object obj)
        {
            try { if (obj != null) Marshal.ReleaseComObject(obj); }
            catch { }
            finally { GC.Collect(); }
        }
    }
}