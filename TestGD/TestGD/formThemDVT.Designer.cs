namespace TestGD
{
	partial class formThemDVT
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridViewDVTGIA = new System.Windows.Forms.DataGridView();
			this.textBoxgtqd = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.bt_them = new System.Windows.Forms.Button();
			this.comboBoxdvt = new System.Windows.Forms.ComboBox();
			this.comboBoxdvcb = new System.Windows.Forms.ComboBox();
			this.bt_sua = new System.Windows.Forms.Button();
			this.bt_xoa = new System.Windows.Forms.Button();
			this.qLTHUOCTAYDataSetDVT = new TestGD.QLTHUOCTAYDataSetDVT();
			this.dONVIBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dONVITableAdapter = new TestGD.QLTHUOCTAYDataSetDVTTableAdapters.DONVITableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDVTGIA)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qLTHUOCTAYDataSetDVT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dONVIBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewDVTGIA
			// 
			this.dataGridViewDVTGIA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDVTGIA.Location = new System.Drawing.Point(12, 11);
			this.dataGridViewDVTGIA.Name = "dataGridViewDVTGIA";
			this.dataGridViewDVTGIA.Size = new System.Drawing.Size(340, 127);
			this.dataGridViewDVTGIA.TabIndex = 0;
			this.dataGridViewDVTGIA.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDVTGIA_CellClick);
			// 
			// textBoxgtqd
			// 
			this.textBoxgtqd.Location = new System.Drawing.Point(448, 57);
			this.textBoxgtqd.Name = "textBoxgtqd";
			this.textBoxgtqd.Size = new System.Drawing.Size(103, 20);
			this.textBoxgtqd.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(358, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Giá Trị Quy Đổi";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(358, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Đơn Vị Cơ Bản";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(358, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Đơn Vị Tính";
			// 
			// bt_them
			// 
			this.bt_them.Location = new System.Drawing.Point(600, 11);
			this.bt_them.Name = "bt_them";
			this.bt_them.Size = new System.Drawing.Size(75, 23);
			this.bt_them.TabIndex = 3;
			this.bt_them.Text = "Thêm";
			this.bt_them.UseVisualStyleBackColor = true;
			this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
			// 
			// comboBoxdvt
			// 
			this.comboBoxdvt.DataSource = this.dONVIBindingSource;
			this.comboBoxdvt.DisplayMember = "tenDonVi";
			this.comboBoxdvt.FormattingEnabled = true;
			this.comboBoxdvt.Location = new System.Drawing.Point(448, 11);
			this.comboBoxdvt.Name = "comboBoxdvt";
			this.comboBoxdvt.Size = new System.Drawing.Size(103, 21);
			this.comboBoxdvt.TabIndex = 4;
			this.comboBoxdvt.ValueMember = "maDonVi";
			// 
			// comboBoxdvcb
			// 
			this.comboBoxdvcb.Enabled = false;
			this.comboBoxdvcb.FormattingEnabled = true;
			this.comboBoxdvcb.Location = new System.Drawing.Point(448, 100);
			this.comboBoxdvcb.Name = "comboBoxdvcb";
			this.comboBoxdvcb.Size = new System.Drawing.Size(103, 21);
			this.comboBoxdvcb.TabIndex = 5;
			// 
			// bt_sua
			// 
			this.bt_sua.Location = new System.Drawing.Point(600, 54);
			this.bt_sua.Name = "bt_sua";
			this.bt_sua.Size = new System.Drawing.Size(75, 23);
			this.bt_sua.TabIndex = 6;
			this.bt_sua.Text = "Sửa";
			this.bt_sua.UseVisualStyleBackColor = true;
			this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
			// 
			// bt_xoa
			// 
			this.bt_xoa.Location = new System.Drawing.Point(600, 96);
			this.bt_xoa.Name = "bt_xoa";
			this.bt_xoa.Size = new System.Drawing.Size(75, 23);
			this.bt_xoa.TabIndex = 7;
			this.bt_xoa.Text = "Xóa";
			this.bt_xoa.UseVisualStyleBackColor = true;
			this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
			// 
			// qLTHUOCTAYDataSetDVT
			// 
			this.qLTHUOCTAYDataSetDVT.DataSetName = "QLTHUOCTAYDataSetDVT";
			this.qLTHUOCTAYDataSetDVT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dONVIBindingSource
			// 
			this.dONVIBindingSource.DataMember = "DONVI";
			this.dONVIBindingSource.DataSource = this.qLTHUOCTAYDataSetDVT;
			// 
			// dONVITableAdapter
			// 
			this.dONVITableAdapter.ClearBeforeFill = true;
			// 
			// formThemDVT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 152);
			this.Controls.Add(this.bt_xoa);
			this.Controls.Add(this.bt_sua);
			this.Controls.Add(this.comboBoxdvcb);
			this.Controls.Add(this.comboBoxdvt);
			this.Controls.Add(this.bt_them);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxgtqd);
			this.Controls.Add(this.dataGridViewDVTGIA);
			this.Name = "formThemDVT";
			this.Text = "Đơn Vị Tính";
			this.Load += new System.EventHandler(this.formThemDVT_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDVTGIA)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qLTHUOCTAYDataSetDVT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dONVIBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewDVTGIA;
		private System.Windows.Forms.TextBox textBoxgtqd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bt_them;
		private System.Windows.Forms.ComboBox comboBoxdvt;
		private System.Windows.Forms.ComboBox comboBoxdvcb;
		private System.Windows.Forms.Button bt_sua;
		private System.Windows.Forms.Button bt_xoa;
		private QLTHUOCTAYDataSetDVT qLTHUOCTAYDataSetDVT;
		private System.Windows.Forms.BindingSource dONVIBindingSource;
		private QLTHUOCTAYDataSetDVTTableAdapters.DONVITableAdapter dONVITableAdapter;
	}
}