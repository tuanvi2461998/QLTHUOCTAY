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

namespace TestGD
{
    public partial class formThongTinThuoc : DevExpress.XtraEditors.XtraForm
    {
        public formThongTinThuoc()
        {
            InitializeComponent();
        }
        //Câu lệnh kết nối cơ sở dữ liệu
        
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();

		public static string MaThuoc = "";
        private void hienthichon(int index)
        {
            try
            {

                //
               textEditMaThuoc.Text = dataGridViewTTThuoc.Rows[index].Cells[0].Value.ToString().Trim();
               textBoxTenThuoc.Text = dataGridViewTTThuoc.Rows[index].Cells[1].Value.ToString().Trim();
               comboBoxDVT.Text= dataGridViewTTThuoc.Rows[index].Cells[2].Value.ToString().Trim();
               textEditGTQuyDoi.Text= dataGridViewTTThuoc.Rows[index].Cells[3].Value.ToString().Trim();
               comboBoxDVCB.Text  = dataGridViewTTThuoc.Rows[index].Cells[4].Value.ToString().Trim();
                textEditGia.Text  = dataGridViewTTThuoc.Rows[index].Cells[5].Value.ToString().Trim();
                textEditgiadv.Text = dataGridViewTTThuoc.Rows[index].Cells[6].Value.ToString().Trim();
               textEditSLuong.Text = dataGridViewTTThuoc.Rows[index].Cells[7].Value.ToString().Trim();
               textEditTPChinh.Text = dataGridViewTTThuoc.Rows[index].Cells[8].Value.ToString().Trim();
               mt.Text  = dataGridViewTTThuoc.Rows[index].Cells[9].Value.ToString().Trim();
               textEditQCDongGoi.Text= dataGridViewTTThuoc.Rows[index].Cells[10].Value.ToString().Trim();
               dateEditHSD.Text = dataGridViewTTThuoc.Rows[index].Cells[11].Value.ToString().Trim();
               comboBoxLoaiThuoc.Text = dataGridViewTTThuoc.Rows[index].Cells[12].Value.ToString().Trim();
               comboBoxNCC.Text = dataGridViewTTThuoc.Rows[index].Cells[13].Value.ToString().Trim();
            }
            catch (Exception)
            {
            };
        }
        public void LoadThuoc()
        {
            
            dtthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select t.maThuoc as N'Mã Thuốc', t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', gdv.giaTriQuyDoi as N'Giá Trị Quy Đổi',dvcb.tenDVCoBan as N'ĐV Cơ Bản',t.giaDVCB as N'Giá Đơn Vị Cơ Bản',(gdv.giaTriQuyDoi*t.giaDVCB)as N'Giá Theo Đơn Vị Tính', t.soLuong N'Số Lượng Theo DVCB',t.thanhPhanChinh as N'TP Chính', t.moTa as N'Mô Tả', t.quyCachDongGoi as N'QC Đóng Gói', t.hanSuDung as N'HSD',lt.moTa as N'Loại Thuốc',nsx.tenNSX as N'NSX'"
            +"from THUOC t, DONVICOBAN dvcb, LOAITHUOC lt, NSX nsx , GIADONVI gdv, DONVI dv where t.maDVCB = dvcb.maDVCoBan and t.maLoaiThuoc =lt.maLoai and t.maNSX = nsx.maNSX and t.maThuoc=gdv.maThuoc and gdv.maDonVi = dv.maDonVi ORDER BY t.maThuoc DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
            dataGridViewTTThuoc.DataSource = dtthuoc;
            //cnn.Close();
        }
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
        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            string Ma        = textEditMaThuoc.Text;
            string Ten       = textBoxTenThuoc.Text;
            string HSD       = dateEditHSD.Text;
            string SL        = textEditSLuong.Text;
            string TPChinh   = textEditTPChinh.Text;
            string NCC       = comboBoxNCC.SelectedValue.ToString();
            string LThuoc    = comboBoxLoaiThuoc.SelectedValue.ToString();
            string DVT       = comboBoxDVT.SelectedValue.ToString();
            string GTQDoi    = textEditGTQuyDoi.Text;
            string DVCB      = comboBoxDVCB.SelectedValue.ToString();
            string QCDongGoi = textEditQCDongGoi.Text;
            string giaDVCB       = textEditGia.Text;
            
            string sqlcheck = "select * from GIADONVI where maThuoc ='"+Ma+"' and maDonVi ='"+DVT+"'";
            if( Ma=="" || Ten==""|| HSD =="" || SL==""|| TPChinh =="" || NCC =="" || LThuoc =="" || DVT =="" || GTQDoi =="" || DVCB =="" || QCDongGoi =="" || giaDVCB ==""){
                MessageBox.Show("Bạn chưa nhập đủ thông tin cho thuốc !!");
            }
            else if (CheckKey(sqlcheck)) {
                MessageBox.Show("Mã thuốc và đơn vị đã tồn tại, vui lòng nhập mã thuốc hoặc mã đơn vị khác !");
            }
            else
            {
                try
                {
                    string sqlthuoc = "INSERT INTO THUOC(maThuoc,tenThuoc,soLuong, quyCachDongGoi, thanhPhanChinh, hanSuDung,maLoaiThuoc,maNSX,moTa,maDVCB,giaDVCB) VALUES ("+Ma+", N'"+Ten+"',"+SL+",N'"+QCDongGoi+"',N'"+TPChinh+"','"+HSD+"',"+LThuoc+","+NCC+",N'"+mt.Text+"',"+DVCB+","+giaDVCB+")";
                    string sqldvt = "INSERT INTO GIADONVI(maThuoc,maDonVi,giaTriQuyDoi) VALUES ("+Ma+","+DVT+","+GTQDoi+")";
                    cnn.Open();
                   SqlCommand cmd2 = new SqlCommand(sqldvt, cnn);
                   cmd2.ExecuteNonQuery();
                    cmd = new SqlCommand(sqlthuoc, cnn);
                    cmd.ExecuteNonQuery();
                    LoadThuoc();
                    MessageBox.Show("Thêm thuốc thành công!");
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

        }

        private void simpleButtonCapNhat_Click(object sender, EventArgs e)
        {
            string Ma = textEditMaThuoc.Text;
            string Ten = textBoxTenThuoc.Text;
            string HSD = dateEditHSD.Text;
            string SL = textEditSLuong.Text;
            string TPChinh = textEditTPChinh.Text;
            string NCC = comboBoxNCC.SelectedValue.ToString();
            string LThuoc = comboBoxLoaiThuoc.SelectedValue.ToString();
            string DVT = comboBoxDVT.SelectedValue.ToString();
            string GTQDoi = textEditGTQuyDoi.Text;
            string DVCB = comboBoxDVCB.SelectedValue.ToString();
            string QCDongGoi = textEditQCDongGoi.Text;
            string Gia = textEditGia.Text;
            if (Ma == "" || Ten == "" || HSD == "" || SL == "" || TPChinh == "" || NCC == "" || LThuoc == "" || DVT == "" || GTQDoi == "" || DVCB == "" || QCDongGoi == "" || Gia == "")
            {
                MessageBox.Show("Bạn chưa chọn thông tin thuốc để cập nhật !!");
            }
            else
            {
                try
                {
                    string sqlthuocupdate = "UPDATE  THUOC set tenThuoc=N'" + Ten + "',soLuong=" + SL + ",quyCachDongGoi=N'" + QCDongGoi + "',thanhPhanChinh=N'" + TPChinh + "',hanSuDung='" + HSD + "',maLoaiThuoc=" + LThuoc + ",maNSX=" + NCC + ", moTa=N'" + mt.Text + "', maDVCB="+DVCB+", giaDVCB="+Gia+" where maThuoc =" + Ma + "";
                    string sqldvtupdate = "UPDATE  GIADONVI set  giaTriQuyDoi=" + GTQDoi + " where maThuoc= " + Ma + " and  maDonVi=" + DVT +"";
                    cnn.Open();
                    cmd = new SqlCommand(sqlthuocupdate, cnn);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(sqldvtupdate, cnn);
                    cmd2.ExecuteNonQuery();
                    LoadThuoc();
                    MessageBox.Show("Cập nhật thuốc thành công!");
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
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string Ma = textEditMaThuoc.Text;
                string DVT = comboBoxDVT.SelectedValue.ToString();

                if (Ma == "" || DVT == "")
                    MessageBox.Show("Bạn chưa chọn thuốc để  XÓA!");
                else
                {
                if (MessageBox.Show("Bạn muốn xóa thuốc này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                 
                        string sql = "DELETE FROM THUOC WHERE maThuoc =" + Ma + "";
                        string sqldv = "DELETE FROM GIADONVI WHERE maThuoc =" + Ma + "";
                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                       SqlCommand cmd2 = new SqlCommand(sqldv, cnn);
                        cmd2.ExecuteNonQuery();    
                        LoadThuoc();
                       
                        MessageBox.Show("Xóa Thuốc Thành Công!!");
                    }
                }

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

        private void simpleButtonLamMoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn làm mới các Thông Tin ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textEditMaThuoc.Text = "";
                textBoxTenThuoc.Text = "";
                dateEditHSD.Text = "";
                textEditSLuong.Text = "";
                textEditTPChinh.Text = "";
                comboBoxNCC.Text = "";
                comboBoxLoaiThuoc.Text = "";
                comboBoxDVT.Text = "";
                textEditGTQuyDoi.Text = "";
                comboBoxDVCB.Text = "";
                textEditQCDongGoi.Text = "";
                textEditGia.Text = "";
                mt.Text = "";
				LoadThuoc();
            }
        }

        private void formThongTinThuoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet6.NSX' table. You can move, or remove it, as needed.
            this.nSXTableAdapter.Fill(this.qLTHUOCTAYDataSet6.NSX);
            
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet3.DONVICOBAN' table. You can move, or remove it, as needed.
            this.dONVICOBANTableAdapter.Fill(this.qLTHUOCTAYDataSet3.DONVICOBAN);
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet2.DONVI' table. You can move, or remove it, as needed.
            this.dONVITableAdapter.Fill(this.qLTHUOCTAYDataSet2.DONVI);
            // TODO: This line of code loads data into the 'qLTHUOCTAYDataSet1.LOAITHUOC' table. You can move, or remove it, as needed.
            this.lOAITHUOCTableAdapter.Fill(this.qLTHUOCTAYDataSet1.LOAITHUOC);
            LoadThuoc();
            
          
        }

        private void dataGridViewTTThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewTTThuoc.CurrentCell.RowIndex;
                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }
        
        private void textEditTim_TextChanged(object sender, EventArgs e)
        {
            string texttim = textEditTim.Text;
            dtthuoc.Clear();
			SqlCommand mySqlCommand = new SqlCommand("select t.maThuoc as N'Mã Thuốc', t.tenThuoc as N'Tên Thuốc',dv.tenDonVi as N'Đơn Vị Tính', gdv.giaTriQuyDoi as N'Giá Trị Quy Đổi',dvcb.tenDVCoBan as N'ĐV Cơ Bản',t.giaDVCB as N'Giá Đơn Vị Cơ Bản',(gdv.giaTriQuyDoi*t.giaDVCB)as N'Giá Theo Đơn Vị Tính', t.soLuong N'Số Lượng Theo DVCB',t.thanhPhanChinh as N'TP Chính', t.moTa as N'Mô Tả', t.quyCachDongGoi as N'QC Đóng Gói', t.hanSuDung as N'HSD',lt.moTa as N'Loại Thuốc',nsx.tenNSX as N'NSX'"
			 + "from THUOC t, DONVICOBAN dvcb, LOAITHUOC lt, NSX nsx , GIADONVI gdv, DONVI dv where t.maDVCB = dvcb.maDVCoBan and t.maLoaiThuoc =lt.maLoai and t.maNSX = nsx.maNSX and t.maThuoc=gdv.maThuoc and gdv.maDonVi = dv.maDonVi and t.tenThuoc like N'%"+texttim+"%'  ORDER BY t.maThuoc DESC", cnn);
			myDataAdapter.SelectCommand = mySqlCommand;
			myDataAdapter.Fill(dtthuoc);
			dataGridViewTTThuoc.DataSource = dtthuoc;
		}

		private void bt_them_dvt_Click(object sender, EventArgs e)
		{
			if (textEditMaThuoc.Text==""){
				MessageBox.Show("Vui lòng chọn thuốc để thêm đơn vị tính !");
			}
			else {
				MaThuoc = textEditMaThuoc.Text;
				Form DVT = new formThemDVT();
				DVT.Show();
			}
		}
	}
}