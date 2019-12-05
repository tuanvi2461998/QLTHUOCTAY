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
    public partial class formLoaiThuoc : DevExpress.XtraEditors.XtraForm
    {
        public formLoaiThuoc()
        {
            InitializeComponent();
        }
        //Câu lệnh kết nối cơ sở dữ liệu

        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtlthuoc = new DataTable();

        public void LoadLT()
        {
            dtlthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maLoai as 'Mã Loại', moTa as N'Tên Loại' from LOAITHUOC ORDER BY maLoai DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewLoaiThuoc.DataSource = dtlthuoc;
           
        }
        private void hienthichon(int index)
        {
            try
            {

                //
                textEditMaLT.Text = dataGridViewLoaiThuoc.Rows[index].Cells[0].Value.ToString().Trim();
                textEditMoTa.Text = dataGridViewLoaiThuoc.Rows[index].Cells[1].Value.ToString().Trim();
                

            }
            catch (Exception)
            {
            };
        }
        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
           
            try
            {
                string ma = textEditMaLT.Text;
                string ten = textEditMoTa.Text;
               
                if (ma == "" || ten=="")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO LOAITHUOC(maLoai, moTa) values(" + ma + ",N'" + ten + "')";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadLT();
                    MessageBox.Show("Thêm Loại Thành Công!!");
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

        private void simpleButtonSua_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditMaLT.Text;
                string ten = textEditMoTa.Text;

                if (ma == "" || ten == "")
                    MessageBox.Show("Bạn chưa chọn loại thuốc để Sửa!");
                else
                {
                    string sql = "UPDATE LOAITHUOC set  moTa=N'" + ten + "' where maLoai  =" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadLT();
                  
                    MessageBox.Show("Cập Nhật Loại Thuốc Thành Công!!");
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

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditMaLT.Text;
                

                if (ma == "")
                    MessageBox.Show("Bạn chưa chọn loại thuốc để  XÓA!");
                else
                {
                    if (MessageBox.Show("Bạn muốn xóa loại thuốc này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string sql = "DELETE FROM LOAITHUOC WHERE maLoai =" + ma + "";
                        
                        cnn.Open();
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        LoadLT();
                        cnn.Close();
                        textEditMaLT.Text = "";
                        textEditMoTa.Text = "";
                        MessageBox.Show("Xóa loại thuốc Thành Công!!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }

        private void simpleButtonLammoi_Click(object sender, EventArgs e)
        {
                textEditMaLT.Text="";
              textEditMoTa.Text="";
        }

        private void formLoaiThuoc_Load(object sender, EventArgs e)
        {
            LoadLT();
        }

        private void dataGridViewLoaiThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewLoaiThuoc.CurrentCell.RowIndex;
              
                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }

    }
}