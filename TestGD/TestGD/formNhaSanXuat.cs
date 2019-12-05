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
    public partial class formNhaSanXuat : DevExpress.XtraEditors.XtraForm
    {
        public formNhaSanXuat()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtlthuoc = new DataTable();

        public void LoadNSX()
        {
            dtlthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maNSX as N'Mã Nhà Sản Xuât', tenNSX as N'Tên Nhà Sản Xuất', soDT as N'Số Điện Thoại', diaChi as N'Địa Chỉ', quocGia as N'Quốc Gia' from NSX ORDER BY maNSX DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewnsx.DataSource = dtlthuoc;

        }
        private void formNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNSX();
        }
        private void hienthichon(int index)
        {
            try
            {
            textEditmansx.Text = dataGridViewnsx.Rows[index].Cells[0].Value.ToString().Trim();
            textEdittennsx.Text = dataGridViewnsx.Rows[index].Cells[1].Value.ToString().Trim();
            textEditsdt.Text= dataGridViewnsx.Rows[index].Cells[2].Value.ToString().Trim();
            textEditdiachi.Text = dataGridViewnsx.Rows[index].Cells[3].Value.ToString().Trim();
            textEditquocgia.Text = dataGridViewnsx.Rows[index].Cells[4].Value.ToString().Trim();
                //
            }
            catch (Exception)
            {
            };
        }
        private void simpleButtonthem_Click(object sender, EventArgs e)
        {
           
            try
            {
                string ma = textEditmansx.Text;
                string ten = textEdittennsx.Text;
                string diachi = textEditdiachi.Text;
                string sdt = textEditsdt.Text;
                string quocgia = textEditquocgia.Text;

                if (ma == "" || ten == "" || diachi=="" || sdt =="" || quocgia =="")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO NSX(maNSX, tenNSX, soDT, diaChi, quocGia) values(" + ma + ",N'" + ten + "', '" + sdt + "', N'" + diachi + "', N'" + quocgia + "')";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadNSX();
                    MessageBox.Show("Thêm Nhà Sản Xuất Thành Công!!");
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

        private void simpleButtonsua_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditmansx.Text;
                string ten = textEdittennsx.Text;
                string diachi = textEditdiachi.Text;
                string sdt = textEditsdt.Text;
                string quocgia = textEditquocgia.Text;

                if (ma == "" || ten == "" || diachi == "" || sdt == "" || quocgia == "")
                    MessageBox.Show("Bạn chưa chọn Nhà Sản Xuất để Sửa!");
                else
                {
                    string sql = "UPDATE NSX set   tenNSX=N'" + ten + "', soDT='" + sdt + "', diaChi=N'" + diachi + "', quocGia=N'" + quocgia + "' where maNSX =" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadNSX();
                    
                    MessageBox.Show("Cập Nhật Nhà Sản Xuất Thành Công!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                cnn.Close();
            }
        }

        private void simpleButtonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditmansx.Text;


                if (ma == "")
                    MessageBox.Show("Bạn chưa chọn NSX để  XÓA!");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa NSX này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = "DELETE FROM NSX WHERE maNSX =" + ma + "";

                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        LoadNSX();
                        cnn.Close();
                        textEditquocgia.Text = "";
                        textEditmansx.Text = "";
                        textEditsdt.Text = "";
                        textEdittennsx.Text = "";
                        textEditdiachi.Text = "";
                        MessageBox.Show("Xóa đơn vị tính Thành Công!!");
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

        private void simpleButtonlmoi_Click(object sender, EventArgs e)
        {
            textEditquocgia.Text = "";
            textEditmansx.Text = "";
            textEditsdt.Text = "";
            textEdittennsx.Text = "";
            textEditdiachi.Text = "";

        }

        private void dataGridViewnsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewnsx.CurrentCell.RowIndex;
                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }

        private void textEdittim_KeyPress(object sender, KeyPressEventArgs e)
        {
            dtlthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maNSX as N'Mã Nhà Sản Xuât', tenNSX as N'Tên Nhà Sản Xuất', soDT as N'Số Điện Thoại', diaChi as N'Địa Chỉ', quocGia as N'Quốc Gia' from NSX where tenNSX like N'%" + textEdittim.Text + "%' ORDER BY maNSX DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewnsx.DataSource = dtlthuoc;
        }

     
    }
}