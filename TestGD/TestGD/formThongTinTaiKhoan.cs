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
    public partial class formThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        public formThongTinCaNhan()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter myDataAdapter = new SqlDataAdapter();
        DataTable dtthuoc = new DataTable();
        private void formThongTinCaNhan_Load(object sender, EventArgs e)
        {
           ten.ReadOnly = true;
            ns.ReadOnly = true;
            sdt.ReadOnly = true;
            dc.ReadOnly = true;
            simpleButtonluu.Enabled = false;
            string manv = formDangNhap.maNV;
            string sql = "select HoTen, ngaySinh, soDienThoai,diaChi from NHANVIEN where maNhanVien ='" + manv + "'";
            DataTable ttnv = GetDataToTable(sql);
           ten.Text = ttnv.Rows[0][0].ToString() ;
           ns.Text = ttnv.Rows[0][1].ToString();
           sdt.Text = ttnv.Rows[0][2].ToString();
           dc.Text = ttnv.Rows[0][3].ToString(); 
        }
        public DataTable GetDataToTable(string sql)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ten.ReadOnly = false;
            ns.ReadOnly = false;
            sdt.ReadOnly = false;
            dc.ReadOnly = false;
            simpleButtonluu.Enabled = true;
            simpleButtoncapnha.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string mnv = formDangNhap.maNV;
            string sql = "UPDATE NHANVIEN SET HoTen=N'" + ten.Text + "',ngaySinh='" + ns.Text + "', soDienThoai='" + sdt.Text + "', diaChi=N'" + dc.Text + "' where maNhanVien='" + mnv + "'";
            if(ten.Text == "" || dc.Text=="" || sdt.Text =="" || ns.Text ==""){
                MessageBox.Show("Vui lòng không để trống các thông tin !");
            }
            
            else{
            cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Cập nhật thành công!");
            ten.ReadOnly = true;
            ns.ReadOnly = true;
            sdt.ReadOnly = true;
            dc.ReadOnly = true;
            simpleButtonluu.Enabled = false;
            simpleButtoncapnha.Enabled = true;
            }
        }
    }
}