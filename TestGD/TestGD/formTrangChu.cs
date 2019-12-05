using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace TestGD
{
    public partial class formTrangChu : DevExpress.XtraEditors.XtraForm
    {
        public formTrangChu()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();

        public string GetFieldValues(string sql)
        {
            string ma = "";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            cnn.Close();
            return ma;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            
        }
        //Kiểm tra form con có tồn tại trong form mẹ không để mở tron xtraTabbedMdiManager1
        private Form kiemtraform(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        // Sự kiện các button
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/profile.php?id=100005971878353");    
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ số điện thoại: 0328328190, Cảm ơn!");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmKH = kiemtraform(typeof(formKhachHang));
            if (frmKH == null)
            {
                formKhachHang formkh = new formKhachHang();
                formkh.MdiParent = this;
                formkh.Show();
            }
            else
            {
                frmKH.Activate();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmTTthuoc = kiemtraform(typeof(formThongTinThuoc));
            if (frmTTthuoc == null)
            {
                formThongTinThuoc formttt = new formThongTinThuoc();
                formttt.MdiParent = this;
                formttt.Show();
            }
            else
            {
                frmTTthuoc.Activate();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frmnsx = kiemtraform(typeof(formNhaSanXuat));
            if (frmnsx == null)
            {
                formNhaSanXuat formsx = new formNhaSanXuat();
                formsx.MdiParent = this;
                formsx.Show();
            }
            else
            {
                frmnsx.Activate();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmLthuoc = kiemtraform(typeof(formLoaiThuoc));
            if (frmLthuoc == null)
            {
                formLoaiThuoc formlt = new formLoaiThuoc();
                formlt.MdiParent = this;
                formlt.Show();
            }
            else
            {
                frmLthuoc.Activate();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmnv = kiemtraform(typeof(formQLNhanVien));
            if (frmnv == null)
            {
                 formQLNhanVien formqlnv = new formQLNhanVien();
                formqlnv.MdiParent = this;
                formqlnv.Show();
            }
            else
            {
                frmnv.Activate();
            }
        }

        private void barButtonItemdvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmdvt = kiemtraform(typeof(formDonViTinh));
            if (frmdvt == null)
            {
                formDonViTinh formqldv = new formDonViTinh();
                formqldv.MdiParent = this;
                formqldv.Show();
            }
            else
            {
                frmdvt.Activate();
            }
        }

        private void btTTTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmttcn = kiemtraform(typeof(formThongTinCaNhan));
            if (frmttcn == null)
            {
                formThongTinCaNhan formqlttcn = new formThongTinCaNhan();
                formqlttcn.MdiParent = this;
                formqlttcn.Show();
            }
            else
            {
                frmttcn.Activate();
            }
        }

        private void btTDmatkhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Form dmk = new formDoiMatKhau();
            //dmk.Show();
            Form frmdmk = kiemtraform(typeof(formDoiMatKhau));
            if (frmdmk == null)
            {
                formDoiMatKhau formdoimk = new formDoiMatKhau();
                formdoimk.MdiParent = this;
                formdoimk.Show();
            }
            else
            {
                frmdmk.Activate();
            }
        }

      

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmdvcb = kiemtraform(typeof(formDonViCB));
            if (frmdvcb == null)
            {
                formDonViCB formdvcoban = new formDonViCB();
                formdvcoban.MdiParent = this;
                formdvcoban.Show();
            }
            else
            {
                frmdvcb.Activate();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {   

            Form frmhd = kiemtraform(typeof(formHDBan));
            if (frmhd == null)
            {
                formHDBan formhdb = new formHDBan();
                formhdb.MdiParent = this;
                formhdb.Show();
            }
            else
            {
                frmhd.Activate();
            }
        }

        private void btDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            Form dn = new formDangNhap();
            dn.Show();
        }

        private void barButtonItemtimhoadon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frmthd = kiemtraform(typeof(formTimHD));
            if (frmthd == null)
            {
                formTimHD formtimhd = new formTimHD();
                formtimhd.MdiParent = this;
                formtimhd.Show();
            }
            else
            {
                frmthd.Activate();
            }
        }
        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter MyData = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            MyData.SelectCommand = new SqlCommand();
            MyData.SelectCommand.Connection = cnn; //Kết nối cơ sở dữ liệu
            MyData.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            MyData.Fill(table);
            return table;
        }
    
        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable kt;
            string sqlkt = "select * from HOADON where ngayLap ='"+DateTime.Now.ToShortDateString()+"'";
            kt = GetDataToTable(sqlkt);
            if(kt.Rows.Count<=0){
                MessageBox.Show("Hôm nay không có hóa đơn nào để lập báo cáo !");
            }
            else{
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tbTTHDCN, tt, ten;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa Hàng Thuốc ĐHKG";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Châu Thành - Kiên Giang";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (84)328328190";
            exRange.Range["C6:E6"].Font.Size = 16;
            exRange.Range["C6:E6"].Font.Bold = true;
            exRange.Range["C6:E6"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C6:E6"].Value = "BÁO CÁO CUỐI NGÀY";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "select maHD, ngayLap,nv.HoTen, kh.HoTen, hd.TriGia from HOADON hd, NHANVIEN nv , KHACHHANG kh where hd.maNhanVien= nv.maNhanVien and hd.maKhachHang= kh.maKhachHang and ngayLap ='" + DateTime.Now.ToShortDateString()+ "'";
            tbTTHDCN = GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 20;
            exRange.Range["B11:B11"].ColumnWidth = 25;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã Hóa Đơn";
            exRange.Range["C11:C11"].Value = "Ngày Lập";
            exRange.Range["D11:D11"].Value = "Nhân Viên";
            exRange.Range["E11:E11"].Value = "Khách Hàng";
            exRange.Range["F11:F11"].Value = "Trị Giá HD";
            for (hang = 0; hang < tbTTHDCN.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tbTTHDCN.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tbTTHDCN.Rows[hang][cot].ToString();
                }
            }
            string sqltt = "select SUM(TriGia) from HOADON where ngayLap ='" + DateTime.Now.ToShortDateString() + "'";
            tt = GetDataToTable(sqltt);
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tt.Rows[0][0].ToString();
            exRange = exSheet.Cells[5][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tbTTHDCN.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Kiên Giang, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên lập báo cáo";
            string sqltten = "select HoTen from NHANVIEN where maNhanVien ='"+formDangNhap.maNV+"'";
            ten = GetDataToTable(sqltten);
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = ten.Rows[0][0].ToString();     
            exSheet.Name = "Báo cáo ";
            exApp.Visible = true;
            }
        }

    }
}
