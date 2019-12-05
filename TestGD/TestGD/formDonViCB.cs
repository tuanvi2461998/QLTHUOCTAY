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
    public partial class formDonViCB : DevExpress.XtraEditors.XtraForm
    {
        public formDonViCB()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtlthuoc = new DataTable();
        public void LoadDVCB()
        {
            dtlthuoc.Clear();
            SqlCommand mySqlCommand = new SqlCommand("select maDVCoBan as N'Mã Đơn Vị Cơ Bản', tenDVCoBan as N'Tên Đơn Vị Cơ Bản' from DONVICOBAN order by maDVCoBan desc", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewdvcb.DataSource = dtlthuoc;

        }
        private void hienthichon(int index)
        {
            try
            {

                //
                textEditmadvcb.Text = dataGridViewdvcb.Rows[index].Cells[0].Value.ToString().Trim();
                textEdittendvcb.Text = dataGridViewdvcb.Rows[index].Cells[1].Value.ToString().Trim();


            }
            catch (Exception)
            {
            };
        }
        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void formDonViCB_Load(object sender, EventArgs e)
        {
            LoadDVCB();
   
        }

        private void simpleButtonthem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditmadvcb.Text;
                string ten = textEdittendvcb.Text;

                if (ma == "" || ten == "")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO DONVICOBAN(maDVCoBan, tenDVCoBan) values(" + ma + ",N'" + ten + "')";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadDVCB();
                    
                    MessageBox.Show("Thêm Đơn Vị Cơ Bản Thành Công!!");
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
                string ma = textEditmadvcb.Text;
                string ten = textEdittendvcb.Text;

                if (ma == "" || ten == "")
                    MessageBox.Show("Bạn chưa chọn đơn vị cơ bản để Sửa!");
                else
                {
                    string sql = "UPDATE DONVICOBAN set  tenDVCoBan=N'" + ten + "' where maDVCoBan  =" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadDVCB();
                  
                    MessageBox.Show("Cập Nhật Đơn Vị Cơ Bản Thành Công!!");
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
                string ma = textEditmadvcb.Text;


                if (ma == "")
                    MessageBox.Show("Bạn chưa chọn đơn vị cơ bản để  XÓA!");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa đơn vị cơ bản này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = "DELETE FROM DONVICOBAN WHERE maDVCoBan = " + ma + "";

                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        LoadDVCB();
                        textEditmadvcb.Text = "";
                        textEdittendvcb.Text = "";
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

        private void simpleButtonlammoi_Click(object sender, EventArgs e)
        {
            textEditmadvcb.Text = "";
            textEdittendvcb.Text = "";
        }

        private void dataGridViewdvcb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewdvcb.CurrentCell.RowIndex;

                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }
    }
}