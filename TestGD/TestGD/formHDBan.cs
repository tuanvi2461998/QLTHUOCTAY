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
    public partial class formHDBan : DevExpress.XtraEditors.XtraForm
    {
        public formHDBan()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();
    
        public void LoadCT(string ma) { 
         
            DataTable dt = new DataTable();
            SqlCommand mySqlCommand = new SqlCommand("select ct.maHD as N'Mã Hóa Đơn',t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', ct.soLuong as N'Số Lượng', ct.donGiaBan as N'Đơn Giá' from CTHD ct, THUOC t, DONVI dv  where ct.maThuoc = t.maThuoc and dv.maDonVi = ct.maDonVi and ct.maHD ='" + ma + "'", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dt);
            dataGridViewCTHD.DataSource = dt;
          
                                        }
        public void LoadThuoc()
        {

            dtthuoc.Clear();
			SqlCommand mySqlCommand = new SqlCommand("select t.maThuoc as N'Mã Thuốc', t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', gdv.giaTriQuyDoi as N'Giá Trị Quy Đổi',dvcb.tenDVCoBan as N'ĐV Cơ Bản',t.giaDVCB as N'Giá Đơn Vị Cơ Bản',(gdv.giaTriQuyDoi*t.giaDVCB)as N'Giá Theo Đơn Vị Tính', t.soLuong N'Số Lượng Theo DVCB',t.thanhPhanChinh as N'TP Chính', t.moTa as N'Mô Tả', t.quyCachDongGoi as N'QC Đóng Gói', t.hanSuDung as N'HSD',lt.moTa as N'Loại Thuốc',nsx.tenNSX as N'NSX', dv.maDonVi as N'Mã Đơn Vị'"
			+ "from THUOC t, DONVICOBAN dvcb, LOAITHUOC lt, NSX nsx , GIADONVI gdv, DONVI dv where t.maDVCB = dvcb.maDVCoBan and t.maLoaiThuoc =lt.maLoai and t.maNSX = nsx.maNSX and t.maThuoc=gdv.maThuoc and gdv.maDonVi = dv.maDonVi ORDER BY t.maThuoc DESC", cnn);
			myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
			dataGridViewThuoc.DataSource = dtthuoc;

		}

		private void formHDBan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet7.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.qLTHUOCTAYDataSet7.KHACHHANG);
            simpleButtonThem.Enabled = false;
            simpleButtonhuy.Enabled = false;
            simpleButtonXoa.Enabled = false;
            simpleButtoninhd.Enabled = false;
            simpleButtonlmoi.Enabled = false;
            simpleButtonxong.Enabled = false;
            LoadThuoc();
          
          
        }

        private void simpleButtontim_Click(object sender, EventArgs e)
        {
            string ttim = textEdittimthuoc.Text;
            string dk = comboBoxEditdieukien.Text;
            if (ttim == "" || dk == "")
            {
                dtthuoc.Clear();
				SqlCommand mySqlCommand = new SqlCommand("select t.maThuoc as N'Mã Thuốc', t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', gdv.giaTriQuyDoi as N'Giá Trị Quy Đổi',dvcb.tenDVCoBan as N'ĐV Cơ Bản',t.giaDVCB as N'Giá Đơn Vị Cơ Bản',(gdv.giaTriQuyDoi*t.giaDVCB)as N'Giá Theo Đơn Vị Tính', t.soLuong N'Số Lượng Theo DVCB',t.thanhPhanChinh as N'TP Chính', t.moTa as N'Mô Tả', t.quyCachDongGoi as N'QC Đóng Gói', t.hanSuDung as N'HSD',lt.moTa as N'Loại Thuốc',nsx.tenNSX as N'NSX', dv.maDonVi as N'Mã Đơn Vị'"
			+ "from THUOC t, DONVICOBAN dvcb, LOAITHUOC lt, NSX nsx , GIADONVI gdv, DONVI dv where t.maDVCB = dvcb.maDVCoBan and t.maLoaiThuoc =lt.maLoai and t.maNSX = nsx.maNSX and t.maThuoc=gdv.maThuoc and gdv.maDonVi = dv.maDonVi ORDER BY t.maThuoc DESC", cnn);
				myDataAdapter.SelectCommand = mySqlCommand;
                myDataAdapter.Fill(dtthuoc);
                dataGridViewThuoc.DataSource = dtthuoc;
            }
            else {
                string dkcsld = "";
                if (dk == "Mã Thuốc")
                {
                    dkcsld = "t.maThuoc";
                }
                else if (dk == "Tên Thuốc")
                {
                    dkcsld = "t.tenThuoc";
                }
                dtthuoc.Clear();
				SqlCommand mySqlCommand = new SqlCommand("select t.maThuoc as N'Mã Thuốc', t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', gdv.giaTriQuyDoi as N'Giá Trị Quy Đổi',dvcb.tenDVCoBan as N'ĐV Cơ Bản',t.giaDVCB as N'Giá Đơn Vị Cơ Bản',(gdv.giaTriQuyDoi*t.giaDVCB)as N'Giá Theo Đơn Vị Tính', t.soLuong N'Số Lượng Theo DVCB',t.thanhPhanChinh as N'TP Chính', t.moTa as N'Mô Tả', t.quyCachDongGoi as N'QC Đóng Gói', t.hanSuDung as N'HSD',lt.moTa as N'Loại Thuốc',nsx.tenNSX as N'NSX', dv.maDonVi as N'Mã Đơn Vị'"
			+ "from THUOC t, DONVICOBAN dvcb, LOAITHUOC lt, NSX nsx , GIADONVI gdv, DONVI dv where t.maDVCB = dvcb.maDVCoBan and t.maLoaiThuoc =lt.maLoai and t.maNSX = nsx.maNSX and t.maThuoc=gdv.maThuoc and gdv.maDonVi = dv.maDonVi ORDER BY t.maThuoc DESC", cnn);
				myDataAdapter.SelectCommand = mySqlCommand;
                myDataAdapter.Fill(dtthuoc);
                dataGridViewThuoc.DataSource = dtthuoc;
            
            }
        }
        /////////////////////
        
        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            try
            { 
                int index = dataGridViewThuoc.CurrentCell.RowIndex;
                string slmua = numericUpDownSL.Value.ToString();
                string mhd = textEditmaHD.Text;
                string mathuoc = dataGridViewThuoc.Rows[index].Cells[0].Value.ToString().Trim();
                string maDV = dataGridViewThuoc.Rows[index].Cells[14].Value.ToString().Trim();
                string dongia = dataGridViewThuoc.Rows[index].Cells[6].Value.ToString().Trim();
                string sqlslcon = "select soLuong from THUOC where maThuoc='" + mathuoc + "'";
                string slcon = GetFieldValues(sqlslcon);
                int slm = Int32.Parse(slmua);
                int slc= Int32.Parse(slcon);
               
                string sqlkt = "select maThuoc from CTHD where maThuoc='"+mathuoc+"' and maHD = '"+mhd+"'";
                if (CheckKey(sqlkt))
                {
					string sqlupdatesl = "UPDATE CTHD set soLuong=soLuong+"+numericUpDownSL.Value.ToString()+" where maHD ='"+mhd+"' and maThuoc='"+mathuoc+"'";
					string sqlsl = "UPDATE THUOC SET soLuong=soLuong-" + numericUpDownSL.Value.ToString() + " WHERE maThuoc = '" + mathuoc + "' ";
					cnn.Open();
					cmd = new SqlCommand(sqlupdatesl,cnn);
					cmd.ExecuteNonQuery();
					SqlCommand cmd2 = new SqlCommand(sqlsl,cnn);
					cmd2.ExecuteNonQuery();
					LoadCT(mhd);
					cnn.Close();
					
                }
                else if (slm > slc)
                {
                   MessageBox.Show("Số lượng thuốc trong kho không đủ để bán!");                
                }
                else
                {
                    try
                    {
                        string sqlsl = "UPDATE THUOC SET soLuong=soLuong-" + slmua + " WHERE maThuoc = '" + mathuoc + "' ";
                        string sqlcthd = "INSERT INTO CTHD(maHD,maDonVi,maThuoc,soLuong,donGiaBan) VALUES ('" + mhd + "'," + maDV + "," + mathuoc + "," + slmua + "," + dongia + ")";
                        cnn.Open();
                        cmd = new SqlCommand(sqlcthd, cnn);
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd2 = new SqlCommand(sqlsl, cnn);
                        cmd2.ExecuteNonQuery();
                        LoadCT(mhd);
                        LoadThuoc();
                        
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);     
                    }
					finally
					{
						cnn.Close();
					}

				}
                 //Cập nhật tổng tiền 
                string sqlttien = "select SUM(soLuong*donGiaBan) as ThanhTien from CTHD where maHD='"+mhd+"'";
                 textEdittongtien.Text=GetFieldValues(sqlttien);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
			
		}
        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            SqlConnection Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
            SqlDataAdapter MyData = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            MyData.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ControlBox = false;
            simpleButtonThem.Enabled = true;
            simpleButtonhuy.Enabled = true;
            simpleButtonXoa.Enabled = true;
            simpleButtoninhd.Enabled = true;
            simpleButtonlmoi.Enabled = true;
            simpleButtonTaoHD.Enabled = false;
            simpleButtonxong.Enabled = true;
            dateEditNgTao.Text = DateTime.Now.ToShortDateString();
            textEditmaHD.Text = CreateKey("HDB");
            //string manv = textEditnv.Text;
            string manv = formDangNhap.maNV;
            string ngLap = dateEditNgTao.Text;
            string mhd = textEditmaHD.Text;
            string makh = comboBoxKH.SelectedValue.ToString();
            string sqlhd = "INSERT INTO HOADON (maHD, ngayLap, maNhanVien, maKhachHang) values ('" + mhd + "','"+ngLap+"','"+manv+"','"+makh+"')";
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sqlhd, cnn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }
        private void simpleButtonhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy hóa đơn này, nếu hủy hóa đơn sẽ không được lưu lại ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int sl, slcon, slxoa;
                string mhd = textEditmaHD.Text;


                string sqlslt = "select maThuoc,soLuong from CTHD where maHD='"+mhd+"'";
                DataTable CTTHUOC = GetDataToTable(sqlslt);
                for (int t = 0; t <= CTTHUOC.Rows.Count - 1; t++) {
                    slcon = Convert.ToInt32(GetFieldValues("select soLuong from THUOC where maThuoc ='"+CTTHUOC.Rows[t][0].ToString()+"'"));
                    slxoa = Convert.ToInt32(CTTHUOC.Rows[t][1].ToString());
                    sl = slcon + slxoa;
                    string sqlslcn = "UPDATE THUOC SET soLuong =" + sl + " where maThuoc='" + CTTHUOC.Rows[t][0].ToString() + "'";
                    try
                    {
                        cnn.Open();
                        SqlCommand cmd3 = new SqlCommand(sqlslcn, cnn);
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    finally
                    {
                        cnn.Close();
                    }   
            {
                cnn.Close();
            }
                }
                string sqlxoahd = "DELETE FROM HOADON WHERE maHD='"+mhd+"'";
                string sqlxoact = "DELETE FROM CTHD WHERE maHD='" + mhd + "' ";
                try
                {
                    cnn.Open();
                    cmd = new SqlCommand(sqlxoact, cnn);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(sqlxoahd, cnn);
                    cmd2.ExecuteNonQuery();
                   
                    simpleButtonThem.Enabled = false;
                    simpleButtonhuy.Enabled = false;
                    simpleButtonXoa.Enabled = false;
                    simpleButtoninhd.Enabled = false;
                    simpleButtonlmoi.Enabled = false;
                    simpleButtonxong.Enabled = false;
                    simpleButtonTaoHD.Enabled = true;
                    textEditmaHD.Text = "";
                    dateEditNgTao.Text = "";
                    MessageBox.Show("Đã hủy hóa đơn");
                    LoadCT(mhd);
                    LoadThuoc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally {
                    cnn.Close();
                }
            }
        }
        //Lấy dữ liệu vào bảng
        public  DataTable GetDataToTable(string sql)
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
        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewCTHD.CurrentCell.RowIndex;
                string tent = dataGridViewCTHD.Rows[index].Cells[1].Value.ToString().Trim();
                string sql = "select  maThuoc from THUOC where tenThuoc =N'" + tent + "'";
                string mathuoc = GetFieldValues(sql);
                string sluong = dataGridViewCTHD.Rows[index].Cells[3].Value.ToString().Trim();
                string mahd = dataGridViewCTHD.Rows[index].Cells[0].Value.ToString().Trim();
                string sqlsl = "UPDATE THUOC SET soLuong=soLuong+" + sluong + " WHERE maThuoc = '" + mathuoc + "' ";
                string sqlxoat = " DELETE FROM CTHD WHERE maHD ='" + mahd + "' and maThuoc='" + mathuoc + "'";
                cnn.Open();
                cmd = new SqlCommand(sqlxoat, cnn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(sqlsl, cnn);
                cmd2.ExecuteNonQuery();
                LoadCT(mahd);
                LoadThuoc();
                string sqlttien = "select SUM(soLuong*donGiaBan) as ThanhTien from CTHD where maHD='" + mahd + "'";
                textEdittongtien.Text = GetFieldValues(sqlttien);
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
                cnn.Close();
            }
        }

        private void simpleButtonlmoi_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

            try
            {
                string mahd = textEditmaHD.Text;
                string sqlttien = "select SUM(soLuong*donGiaBan) as ThanhTien from CTHD where maHD='" + mahd + "'";
                textEdittongtien.Text = GetFieldValues(sqlttien);
                string sqlgthd = "UPDATE HOADON SET TriGia = " + textEdittongtien.Text + " where maHD ='" + mahd + "'";
                cnn.Open();
                cmd = new SqlCommand(sqlgthd, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                string mhd = "";
                MessageBox.Show("Hóa Đơn Đã Được Lưu");
                simpleButtonThem.Enabled = true;
                simpleButtonhuy.Enabled = false;
                simpleButtonXoa.Enabled = false;
                simpleButtoninhd.Enabled = false;
                simpleButtonlmoi.Enabled = false;
                simpleButtonTaoHD.Enabled = true;
                simpleButtonxong.Enabled = false;
                textEditmaHD.Text = "";
                dateEditNgTao.Text = "";
                LoadCT(mhd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally { 
                cnn.Close();
            }
            
           
        }

        private void formHDBan_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                simpleButtonxong.Enabled = false;
                string mhd = textEditmaHD.Text;
                string sqlxoahd = "DELETE FROM HOADON WHERE maHD='" + mhd + "'";
                string sqlxoact = "DELETE FROM CTHD WHERE maHD='" + mhd + "' ";
                cnn.Open();
                cmd = new SqlCommand(sqlxoact, cnn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(sqlxoahd, cnn);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally { 
                cnn.Close(); 
            }
            
        }

        private void simpleButtoninhd_Click(object sender, EventArgs e)
        {
            string mahd = textEditmaHD.Text;
            string sqlttien = "select SUM(soLuong*donGiaBan) as ThanhTien from CTHD where maHD='" + mahd + "'";
            textEdittongtien.Text = GetFieldValues(sqlttien);
            string sqlgthd = "UPDATE HOADON SET TriGia = " + textEdittongtien.Text + " where maHD ='" + mahd + "'";
            cnn.Open();
            cmd = new SqlCommand(sqlgthd, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
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
            sql = "select hd.maHD, hd.ngayLap,hd.TriGia, kh.HoTen,kh.diaChi, kh.soDienThoai ,nv.HoTen from HOADON hd, NHANVIEN nv, KHACHHANG kh where hd.maHD='"+textEditmaHD.Text+"' and nv.maNhanVien=hd.maNhanVien and hd.maKhachHang =kh.maKhachHang";
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
            sql = "select t.tenThuoc, ct.soLuong, ct.donGiaBan, (ct.soLuong*ct.donGiaBan) as thanhTien  from CTHD ct , THUOC t where ct.maHD='"+textEditmaHD.Text+"' and ct.maThuoc=t.maThuoc";
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
            exRange.Value2 = textEditkhachdua.Text;
            

            //
            exRange = exSheet.Cells[cot][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tiền dư:";
            exRange = exSheet.Cells[cot + 1][hang + 16];
            exRange.Font.Bold = true;
            exRange.Value2 = textEdittientl.Text;
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
            //Lưu
            string mhd = "";
            simpleButtonThem.Enabled = false;
            simpleButtonhuy.Enabled = false;
            simpleButtonXoa.Enabled = false;
            simpleButtoninhd.Enabled = false;
            simpleButtonlmoi.Enabled = false;
            simpleButtonTaoHD.Enabled = true;
            simpleButtonxong.Enabled = false;
            textEditmaHD.Text = "";
            dateEditNgTao.Text = "";
            LoadCT(mhd);
        }

        private void textEditkhachdua_TextChanged(object sender, EventArgs e)
        {
            string ttien = textEdittongtien.Text;
            string kdua = textEditkhachdua.Text;
           
                textEditkhachdua.ReadOnly = false;
                double tt = Convert.ToDouble(ttien);
                double kd = Convert.ToDouble(kdua) ;
                double tthoi = kd - tt;
                textEdittientl.Text = Convert.ToString(tthoi);
               
        }
	}
}