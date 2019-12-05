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
    public partial class formDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public formDoiMatKhau()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();
        
        
        private void Luu_Click(object sender, EventArgs e)
        {
            string mnv = formDangNhap.maNV;
            string mkcu = mkc.Text;
            string mkmoi = mkm.Text;
            string xnmk = nhaplai.Text;
            string sql = "select matKhau from NHANVIEN where maNhanVien='"+mnv+"'";
            string mk = GetFieldValues(sql);
            MessageBox.Show(" "+mnv);
            if (mkcu == "" || xnmk == "" || mkmoi == "")
                MessageBox.Show("Vui lòng nhập đủ thông tin để đổi mật khẩu !");
            else if (!mk.Equals(mkcu))
            {
                MessageBox.Show("Vui lòng nhập đúng mật cũ ");
            }
            else if (!xnmk.Equals(mkmoi))
            {
                MessageBox.Show("Mật khẩu không khớp nhau, vui lòng kiểm tra lại");
            }
            else
            { 
                try{
                string sqldoimk = "UPDATE NHANVIEN SET matKhau ='"+xnmk+"' where maNhanVien ='"+mnv+"'";
                cnn.Open();
                cmd = new SqlCommand(sqldoimk,cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại!");
                mkc.Text = "";
                mkm.Text = "";
                nhaplai.Text = "";
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
                 finally
            {
                cnn.Close();
            }
            }
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

        private void LamMoi_Click(object sender, EventArgs e)
        {
            mkc.Text="";
             mkm.Text="";
            nhaplai.Text="";
        }
    }
}