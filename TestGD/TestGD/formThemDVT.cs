using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGD
{
	public partial class formThemDVT : Form
	{
		public formThemDVT()
		{
			InitializeComponent();
		}
		SqlConnection cnn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUOCTAY;Integrated Security=True");
		SqlCommand cmd = new SqlCommand();
		SqlDataAdapter myDataAdapter = new SqlDataAdapter();
		DataTable dtthuoc = new DataTable();

		public void LoadDVT(string Ma)
		{
			dtthuoc.Clear();
			SqlCommand mySqlCommand = new SqlCommand("select t.tenThuoc, dv.tenDonVi, gdv.giaTriQuyDoi,dvcb.tenDVCoBan from GIADONVI gdv, THUOC t, DONVI dv, DONVICOBAN dvcb where gdv.maDonVi = dv.maDonVi and t.maDVCB = dvcb.maDVCoBan and t.maThuoc = gdv.maThuoc and gdv.maThuoc = '"+Ma+"'", cnn);
			myDataAdapter.SelectCommand = mySqlCommand;
			myDataAdapter.Fill(dtthuoc);
			dataGridViewDVTGIA.DataSource = dtthuoc;
		}
		private void hienthichon(int index)
		{
			try
			{
				comboBoxdvt.Text = dataGridViewDVTGIA.Rows[index].Cells[1].Value.ToString().Trim();
				textBoxgtqd.Text = dataGridViewDVTGIA.Rows[index].Cells[2].Value.ToString().Trim();
				comboBoxdvcb.Text = dataGridViewDVTGIA.Rows[index].Cells[3].Value.ToString().Trim();
			}
			catch (Exception)
			{
			};
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
		private void formThemDVT_Load(object sender, EventArgs e)
		{
			string dvcb = GetFieldValues("select cb.tenDVCoBan from THUOC t, DONVICOBAN cb where maThuoc='"+ formThongTinThuoc.MaThuoc + "' and t.maDVCB=cb.maDVCoBan");
			comboBoxdvcb.Text = dvcb;
			// TODO: This line of code loads data into the 'qLTHUOCTAYDataSetDVT.DONVI' table. You can move, or remove it, as needed.
			this.dONVITableAdapter.Fill(this.qLTHUOCTAYDataSetDVT.DONVI);
			LoadDVT(formThongTinThuoc.MaThuoc);
		}

		private void bt_them_Click(object sender, EventArgs e)
		{

			string mat = formThongTinThuoc.MaThuoc;
			string dvcb = GetFieldValues("select maDVCB from THUOC where maThuoc='" + mat + "'");
			string dvt = comboBoxdvt.SelectedValue.ToString();
			string gtqd = textBoxgtqd.Text;
			if (comboBoxdvt.Text == "" || textBoxgtqd.Text == "")
			{
				MessageBox.Show("Chưa đủ thông tin để thêm");
			}
			else if(CheckKey("select maDonVi from GIADONVI where maThuoc = '"+mat+"' and maDonVi = '"+dvt+"'"))
			{
				MessageBox.Show("Vui lòng không thêm đơn vị tính đã có!");
			}
			else
			{
				try
				{	
					string sql = "INSERT INTO GIADONVI(maThuoc,maDonVi,giaTriQuyDoi) Values ('"+mat+"','"+dvt+"',"+gtqd+")";
					cnn.Open();
					cmd = new SqlCommand(sql, cnn);
					cmd.ExecuteNonQuery();
					LoadDVT(mat);
				}
				catch { }
				finally
				{
					cnn.Close();
				}
			}
		}

		private void bt_sua_Click(object sender, EventArgs e)
		{
			string mat = formThongTinThuoc.MaThuoc;
			string dvt = comboBoxdvt.SelectedValue.ToString();
			string gtqd = textBoxgtqd.Text;
			if (comboBoxdvt.Text == "" || textBoxgtqd.Text == "")
			{
				MessageBox.Show("Chưa đủ thông tin để thêm");
			}
			else
			{
				try
				{
					string sql = "UPDATE GIADONVI set giaTriQuyDoi ="+gtqd+" where maThuoc='"+mat+"' and maDonVi='"+dvt+"'";
					cnn.Open();
					cmd = new SqlCommand(sql, cnn);
					cmd.ExecuteNonQuery();
					LoadDVT(mat);
				}
				catch { }
				finally
				{
					cnn.Close();
				}
			}
		}

		private void bt_xoa_Click(object sender, EventArgs e)
		{
			string mat = formThongTinThuoc.MaThuoc;
			string dvt = comboBoxdvt.SelectedValue.ToString();
			if (comboBoxdvt.Text == "" || textBoxgtqd.Text == "")
			{
				MessageBox.Show("Chưa chọn đơn vị của thuốc để xóa");
			}
			else
			{
				try
				{
					string sql = "DELETE FROM GIADONVI where maThuoc ='"+mat+"' and maDonVi='"+dvt+"'";
					cnn.Open();
					cmd = new SqlCommand(sql, cnn);
					cmd.ExecuteNonQuery();
					LoadDVT(mat);
				}
				catch { }
				finally
				{
					cnn.Close();
				}
			}
		}

		private void dataGridViewDVTGIA_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int index = dataGridViewDVTGIA.CurrentCell.RowIndex;
				hienthichon(index);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			};
		}
	}
}
