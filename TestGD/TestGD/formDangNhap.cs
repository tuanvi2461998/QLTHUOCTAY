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
    public partial class formDangNhap : DevExpress.XtraEditors.XtraForm
    {  
        public static string maNV="";
        public formDangNhap()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdithienthi.Checked == true)
            {
                textBoxPass.PasswordChar = '\0';

            }
            else
            {
                textBoxPass.PasswordChar = '*';
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string tk = textBoxuser.Text;
            string mk = textBoxPass.Text;
            try
            {
                if (tk == "" || mk == "")
                {
                    MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin đăng nhập");
                }
                else
                {
                    cnn.Open();
                    //Truy vấn
                    cmd = new SqlCommand("select matKhau, maNhanVien,HoTen from NHANVIEN where TaiKhoan = '" + tk + "'", cnn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //So sánh
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (reader.GetString(0) == mk)
                        {
                            MessageBox.Show("Chào mừng " + reader.GetString(2) + " đến với hệ thống !");
                            maNV = reader.GetString(1);
                            Form tc = new formTrangChu();
                            tc.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("Mật khẩu sai !");
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản không tồn tại !");
                    }
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

        private void textBoxuser_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar); 
        }

		private void formDangNhap_Load(object sender, EventArgs e)
		{

		}
	}
}