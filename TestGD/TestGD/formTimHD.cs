using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace TestGD
{
    public partial class formTimHD : DevExpress.XtraEditors.XtraForm
    {
        public formTimHD()
        {
            InitializeComponent();
        }
        string mhd = "";
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();
        private void simpleButtontim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((textEditmahd.Text== "") && (textEditngay.Text=="") && (textEditthang.Text=="") && (textEditnam.Text=="") && (comboBoxnhanvien.SelectedValue.ToString() =="") && (comboBoxkh.SelectedValue.ToString() =="") && (textEdittt.Text =="")) {
                MessageBox.Show("Hãy nhập điều kiện để tìm kiếm Hóa Đơn", "Yêu Cầu ....", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            sql = "select hd.maHD as N'Mã Hóa Đơn',hd.ngayLap as N'Ngày Lập',nv.HoTen as N'Nhân Viên',kh.HoTen as N'Khách Hàng', hd.TriGia as N'Trị Giá'  from HOADON hd, NHANVIEN nv, KHACHHANG kh where hd.maNhanVien=nv.maNhanVien and hd.maKhachHang= kh.maKhachHang";
            
            if (textEditmahd.Text != "")
                sql = sql + " AND maHD like '%" + textEditmahd.Text + "%' ";
            if(textEditngay.Text != "")
                sql = sql+" AND DAY(ngayLap) like '%"+textEditngay.Text+"%' ";
            if(textEditthang.Text != "")
                sql = sql+" AND MONTH(ngayLap) like '%"+textEditthang.Text+"%' ";
            if(textEditnam.Text != "")
                sql = sql+" AND YEAR(ngayLap) like '%"+textEditnam.Text+"%' ";
            if(comboBoxnhanvien.Text !="")
                sql = sql + " AND hd.maNhanVien like '%" + comboBoxnhanvien.SelectedValue.ToString() + "%' ";
            if (comboBoxkh.Text != "")
                sql = sql + " AND kh.maKhachHang like '%" + comboBoxkh.SelectedValue.ToString() + "%' ";
            if (textEdittt.Text != "")
                sql = sql+ " AND TriGia <= "+textEdittt.Text+"";
            dtthuoc.Clear();
            SqlCommand mySqlCommand = new SqlCommand(sql, cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
            dataGridViewHD.DataSource = dtthuoc;
            
        }
        public void LoadHD()
        {
            dtthuoc.Clear();
            SqlCommand mySqlCommand = new SqlCommand("select hd.maHD as N'Mã Hóa Đơn',hd.ngayLap as N'Ngày Lập',nv.HoTen as N'Nhân Viên',kh.HoTen as N'Khách Hàng', hd.TriGia as N'Trị Giá'  from HOADON hd, NHANVIEN nv, KHACHHANG kh where hd.maNhanVien=nv.maNhanVien and hd.maKhachHang= kh.maKhachHang ORDER BY hd.maHD DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
            dataGridViewHD.DataSource = dtthuoc;

        }
        private void formTimHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet9.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLTHUOCTAYDataSet9.KHACHHANG);
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet8.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qLTHUOCTAYDataSet8.NHANVIEN);
            LoadHD();
        }

        private void dataGridViewHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewHD.CurrentCell.RowIndex;
            string maHD = dataGridViewHD.Rows[index].Cells[0].Value.ToString().Trim();
            mhd = maHD;
            string sql = "select ct.maHD as 'Mã HD',t.tenThuoc as 'Tên Thuốc',dv.tenDonVi as 'Đơn Vị', ct.soLuong as 'Số Lượng', ct.donGiaBan as 'Giá ' from CTHD ct, THUOC t, DONVI dv  where ct.maThuoc = t.maThuoc and dv.maDonVi = ct.maDonVi and ct.maHD ='" + maHD + "'";
            DataTable dtct = new DataTable();
            dtct.Clear();
            SqlCommand mySqlCommand = new SqlCommand(sql, cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtct);
            dataGridViewCT.DataSource = dtct;


        }
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
        private void simpleButtoninhd_Click(object sender, EventArgs e)
        {
            
            string sqlttien = "select SUM(soLuong*donGiaBan) as ThanhTien from CTHD where maHD='" + mhd + "'";
           string tt = GetFieldValues(sqlttien);
           
          
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tbThongtinHD, tbThongtinHang;
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
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN THUỐC";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "select hd.maHD, hd.ngayLap,hd.TriGia, kh.HoTen,kh.diaChi, kh.soDienThoai ,nv.HoTen from HOADON hd, NHANVIEN nv, KHACHHANG kh where hd.maHD='" + mhd + "' and nv.maNhanVien=hd.maNhanVien and hd.maKhachHang =kh.maKhachHang";
            tbThongtinHD = GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tbThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tbThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tbThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tbThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "select t.tenThuoc, ct.soLuong, ct.donGiaBan, (ct.soLuong*ct.donGiaBan) as thanhTien  from CTHD ct , THUOC t where ct.maHD='" + mhd + "' and ct.maThuoc=t.maThuoc";
            tbThongtinHang = GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            //exRange.Range["F11:F11"].Value = "";
            for (hang = 0; hang < tbThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tbThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tbThongtinHang.Rows[hang][cot].ToString();

                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tbThongtinHD.Rows[0][2].ToString();


            //
            exRange = exSheet.Cells[cot][hang + 15];
            exRange.Font.Bold = true;
            exRange.Value2 = "Khách đưa:";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            //exRange.Value2 = textEditkhachdua.Text;


            //
            exRange = exSheet.Cells[cot][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tiền dư:";
            exRange = exSheet.Cells[cot + 1][hang + 16];
            exRange.Font.Bold = true;
           // exRange.Value2 = textEdittientl.Text;
            exRange = exSheet.Cells[1][hang + 17]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;

            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[3][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tbThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Kiên Giang, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán thuốc";
            exRange.Range["A5:C5"].MergeCells = true;
            exRange.Range["A5:C5"].Font.Italic = true;
            exRange.Range["A5:C5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:C5"].Value = tbThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }

       
    }
}