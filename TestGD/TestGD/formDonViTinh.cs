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
    public partial class formDonViTinh : DevExpress.XtraEditors.XtraForm
    {
        public formDonViTinh()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtlthuoc = new DataTable();
        public void LoadDVT()
        {
            dtlthuoc.Clear();

            SqlCommand mySqlCommand = new SqlCommand("select maDonVi as N'Mã Đơn Vị Tính', tenDonVi as N'Tên Đơn Vị Tính' from DONVI ORDER BY maDonVi DESC", cnn);
            myDataAdapter.SelectCommand = mySqlCommand;
            myDataAdapter.Fill(dtlthuoc);
            dataGridViewDVT.DataSource = dtlthuoc;

        }
        private void hienthichon(int index)
        {
            try
            {

                //
                textEditmaDVT.Text = dataGridViewDVT.Rows[index].Cells[0].Value.ToString().Trim();
                textEdittenDVT.Text = dataGridViewDVT.Rows[index].Cells[1].Value.ToString().Trim();


            }
            catch (Exception)
            {
            };
        }
        private void formDonViTinh_Load(object sender, EventArgs e)
        {
            LoadDVT();
           
        }

        private void simpleButtonLMoi_Click(object sender, EventArgs e)
        {
            textEditmaDVT.Text = "";
            textEdittenDVT.Text = "";
        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = textEditmaDVT.Text;
                string ten = textEdittenDVT.Text;

                if (ma == "" || ten == "")
                    MessageBox.Show("Bạn chưa điền đủ thông tin!");
                else
                {
                    string sql = "INSERT INTO DONVI(maDonVi, tenDonVi) values(" + ma + ",N'" + ten + "')";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadDVT();
                    
                    MessageBox.Show("Thêm Đơn Vị Thành Công!!");
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
                string ma = textEditmaDVT.Text;
                string ten = textEdittenDVT.Text;

                if (ma == "" || ten == "")
                    MessageBox.Show("Bạn chưa chọn đơn vị tính để Sửa!");
                else
                {
                    string sql = "UPDATE DONVI set  tenDonVi=N'" + ten + "' where maDonVi  =" + ma + "";
                    cnn.Open();
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    LoadDVT();
                  
                    MessageBox.Show("Cập Nhật Đơn Vị Thành Công!!");
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
                    string ma = textEditmaDVT.Text;


                    if (ma == "")
                        MessageBox.Show("Bạn chưa chọn đơn vị để  XÓA!");
                    else
                    {
                        if (MessageBox.Show("Bạn muốn xóa đơn vị tính này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string sql = "DELETE FROM DONVI WHERE maDonVi = " + ma + "";

                            cnn.Open();
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            LoadDVT();
                           
                            textEditmaDVT.Text = "";
                            textEdittenDVT.Text = "";
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

        private void dataGridViewDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridViewDVT.CurrentCell.RowIndex;

                hienthichon(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
        }

       
    }
}