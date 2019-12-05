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
    public partial class formQLNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public formQLNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();
        public void LoadNV()
        {
            dtthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maNhanVien as N'Mã NV', HoTen as N'Họ Tên', ngaySinh as N'Ngày Sinh', soDienThoai as N'Số Điện Thoại', diaChi as N'Địa Chỉ' , TaiKhoan as N'Tài Khoản', maQuyen as N'Mã Quyền', gioiTinh as N'Giới Tính' from NHANVIEN order by maNhanVien desc", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
            dataGridViewnv.DataSource = dtthuoc;
            //cnn.Close();
        }
        private void hienthichon(int index)
        {
            try
            {

                textEditma.Text = dataGridViewnv.Rows[index].Cells[0].Value.ToString().Trim();
                textEditten.Text = dataGridViewnv.Rows[index].Cells[1].Value.ToString().Trim();
                dateEditns.Text = dataGridViewnv.Rows[index].Cells[2].Value.ToString().Trim();
                textEditsdt.Text = dataGridViewnv.Rows[index].Cells[3].Value.ToString().Trim();
                textEditdiachi.Text = dataGridViewnv.Rows[index].Cells[4].Value.ToString().Trim();
                textEdittk.Text = dataGridViewnv.Rows[index].Cells[5].Value.ToString().Trim();
                //textEditmk.Text = dataGridViewnv.Rows[index].Cells[6].Value.ToString().Trim();
                comboBoxquyen.Text = dataGridViewnv.Rows[index].Cells[6].Value.ToString().Trim();
                comboBoxEditgt.Text =  dataGridViewnv.Rows[index].Cells[7].Value.ToString().Trim();

            }
            catch (Exception)
            {
            };
        }
        private void simpleButtonthem_Click(object sender, EventArgs e)
        {
            try
            {
               string ma = textEditma.Text;
               string ten= textEditten.Text;
               string ns= dateEditns.Text ;
               string sdt= textEditsdt.Text;
                string dc=textEditdiachi.Text;
                string tk= textEdittk.Text;
                string mk= textEditmk.Text;
                string quyen=comboBoxquyen.Text;
                
                if (ma == "" || ten == "" || ns == ""|| sdt=="" ||dc =="" || tk=="" || mk=="" || quyen=="")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO NHANVIEN(maNhanVien, HoTen, ngaySinh, soDienThoai, diaChi, TaiKhoan,matKhau, maQuyen,gioiTinh) values(" + ma + ",N'" + ten + "','"+ns+"', '"+sdt+"', N'"+ dc +"', '"+tk+"', '"+mk +"', "+quyen+",N'"+comboBoxEditgt.Text+"')";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadNV();
                 
                    MessageBox.Show("Thêm Nhân Viên Thành Công!!");
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

        private void formQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadNV();
        }

        private void simpleButtonlmoi_Click(object sender, EventArgs e)
        {
            textEditma.Text="";
            textEditten.Text="";
            dateEditns.Text="";
            textEditsdt.Text="";
            textEditdiachi.Text="";
            textEdittk.Text="";
            textEditmk.Text="";
            comboBoxquyen.Text="";
            textEdittim.Text = "";
            comboBoxEditgt.Text = "";
            LoadNV();
        }

       

        private void simpleButtonsua_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditma.Text;
                string ten = textEditten.Text;
                string ns = dateEditns.Text;
                string sdt = textEditsdt.Text;
                string dc = textEditdiachi.Text;
                string tk = textEdittk.Text;
                string mk = textEditmk.Text;
                string quyen = comboBoxquyen.Text;

                if (ma == "" || ten == "" || ns == "" || sdt == "" || dc == "" || tk == "" || mk == "" || quyen == "")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "UPDATE NHANVIEN set  HoTen=N'" + ten + "', ngaySinh='" + ns + "', soDienThoai='" + sdt + "', diaChi=N'" + dc + "', TaiKhoan='" + tk + "',matKhau='" + mk + "', maQuyen= " + quyen + " , gioiTinh =N'" + comboBoxEditgt.Text + "' where maNhanVien=" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadNV();
                    MessageBox.Show("Cập Nhật Nhân Viên Thành Công!!");
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
        private void dataGridViewnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewnv.CurrentCell.RowIndex;
                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           
        }

        private void simpleButtonxoa_Click(object sender, EventArgs e)
        {

            try
            {
                string ma = textEditma.Text;


                if (ma == "")
                    MessageBox.Show("Bạn chưa chọn đơn vị để  XÓA!");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa Nhân Viên này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = "DELETE FROM NHANVIEN WHERE maNhanVien = " + ma + "";

                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        LoadNV();
                        MessageBox.Show("Xóa Nhân Viên Thành Công!!");
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

        private void textEdittim_TextChanged(object sender, EventArgs e)
        {  string tim = textEdittim.Text;
            dtthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maNhanVien as N'Mã NV', HoTen as N'Họ Tên', ngaySinh as N'Ngày Sinh', soDienThoai as N'Số Điện Thoại', diaChi as N'Địa Chỉ' , TaiKhoan as N'Tài Khoản', maQuyen as N'Mã Quyền', gioiTinh as N'Giới Tính' from NHANVIEN where HoTen like N'" + tim + "' order by maNhanVien desc", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtthuoc);
            dataGridViewnv.DataSource = dtthuoc;
        }

        private void textEdittk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar)))
            {
                e.Handled = false;
            }
        }

       
    }
}