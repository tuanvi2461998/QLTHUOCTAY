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
    public partial class formKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public formKhachHang()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtlthuoc = new DataTable();
        public void LoadKH()
        {
            dtlthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maKhachHang as N'Mã Khách Hàng', HoTen as N'Họ Tên', ngaySinh as N'Ngày Sinh', soDienThoai as N'Số Điện Thoại', diaChi as N'Địa Chỉ', gioiTinh as N'Giới Tính' from KHACHHANG ORDER BY maKhachHang DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewkh.DataSource = dtlthuoc;

        }
        private void hienthichon(int index)
        {
            try
            {

                //
                textEditma.Text = dataGridViewkh.Rows[index].Cells[0].Value.ToString().Trim();
                textEditten.Text = dataGridViewkh.Rows[index].Cells[1].Value.ToString().Trim();
                  dateEditns.Text = dataGridViewkh.Rows[index].Cells[2].Value.ToString().Trim();
                   textEditsdt.Text = dataGridViewkh.Rows[index].Cells[3].Value.ToString().Trim();
                   textEditdiachi.Text = dataGridViewkh.Rows[index].Cells[4].Value.ToString().Trim();
                   comboBoxgt.Text = dataGridViewkh.Rows[index].Cells[5].Value.ToString().Trim();


            }
            catch (Exception)
            {
            };
        }
        private void formKhachHang_Load(object sender, EventArgs e)
        {
            LoadKH();
        }

        private void dataGridViewkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int index = dataGridViewkh.CurrentCell.RowIndex;

                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }

        private void simpleButtonthem_Click(object sender, EventArgs e)
        {


            try
            {
                string ma = textEditma.Text;
                string ten = textEditten.Text;
                string dc = textEditdiachi.Text;
                string ns = dateEditns.Text;
                string sdt = textEditsdt.Text;

                if (ma == "" || ten == "" || dc == "" || ns == "" || sdt == "")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO KHACHHANG(maKhachHang, HoTen, ngaySinh, diaChi, soDienThoai,gioiTinh) values(" + ma + ",N'" + ten + "','" + ns + "',N'" + dc + "','" + sdt + "',N'" + comboBoxgt.Text + "' )";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadKH();

                    MessageBox.Show("Thêm Khách Hàng Thành Công!!");
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

        private void simpleButtonlammoi_Click(object sender, EventArgs e)
        {
                textEditma.Text="";
                textEditten.Text="";
                textEditdiachi.Text="" ;
                dateEditns.Text="";
                textEditsdt.Text = "";
        }

        private void simpleButtonsua_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditma.Text;
                string ten = textEditten.Text;
                string dc = textEditdiachi.Text;
                string ns = dateEditns.Text;
                string sdt = textEditsdt.Text;

                if (ma == "" || ten == "" || dc == "" || ns == "" || sdt == "")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "UPDATE KHACHHANG set  HoTen=N'" + ten + "', ngaySinh='" + ns + "', diaChi=N'" + dc + "', soDienThoai='" + sdt + "', gioiTinh =N'" + comboBoxgt.Text+ "'  where maKhachHang =" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadKH();
                  
                    MessageBox.Show("Cập Nhật Khách Hàng Thành Công!!");
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

        private void simpleButtonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditma.Text;


                if (ma == "")
                    MessageBox.Show("Bạn chưa chọn Khách Hàng để  XÓA!");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa Khách này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = "DELETE FROM KHACHHANG WHERE maKhachHang = " + ma + "";

                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        LoadKH();
                      
                        MessageBox.Show("Xóa Khách Hàng Thành Công!!");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           finally{

               textEditma.Text = "";
               textEditten.Text = "";
               textEditdiachi.Text = "";
               dateEditns.Text = "";
               textEditsdt.Text = "";
               cnn.Close();
           }

        }

        
    }
}
