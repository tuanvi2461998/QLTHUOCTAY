namespace TestGD
{
    partial class formLoaiThuoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLoaiThuoc));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dataGridViewLoaiThuoc = new System.Windows.Forms.DataGridView();
            this.simpleButtonThem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonXoa = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSua = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLammoi = new DevExpress.XtraEditors.SimpleButton();
            this.textEditMoTa = new DevExpress.XtraEditors.TextEdit();
            this.textEditMaLT = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lOAITHUOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTHUOCTAYDataSet5 = new TestGD.QLTHUOCTAYDataSet5();
            this.lOAITHUOCTableAdapter = new TestGD.QLTHUOCTAYDataSet5TableAdapters.LOAITHUOCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaLT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHUOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTHUOCTAYDataSet5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.Silver;
            this.layoutControl1.Controls.Add(this.dataGridViewLoaiThuoc);
            this.layoutControl1.Controls.Add(this.simpleButtonThem);
            this.layoutControl1.Controls.Add(this.simpleButtonXoa);
            this.layoutControl1.Controls.Add(this.simpleButtonSua);
            this.layoutControl1.Controls.Add(this.simpleButtonLammoi);
            this.layoutControl1.Controls.Add(this.textEditMoTa);
            this.layoutControl1.Controls.Add(this.textEditMaLT);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1362, 650);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dataGridViewLoaiThuoc
            // 
            this.dataGridViewLoaiThuoc.AllowUserToAddRows = false;
            this.dataGridViewLoaiThuoc.AllowUserToDeleteRows = false;
            this.dataGridViewLoaiThuoc.AllowUserToResizeColumns = false;
            this.dataGridViewLoaiThuoc.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewLoaiThuoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLoaiThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLoaiThuoc.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLoaiThuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLoaiThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLoaiThuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLoaiThuoc.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewLoaiThuoc.Name = "dataGridViewLoaiThuoc";
            this.dataGridViewLoaiThuoc.Size = new System.Drawing.Size(1338, 554);
            this.dataGridViewLoaiThuoc.TabIndex = 10;
            this.dataGridViewLoaiThuoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLoaiThuoc_CellClick);
            // 
            // simpleButtonThem
            // 
            this.simpleButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonThem.Image")));
            this.simpleButtonThem.Location = new System.Drawing.Point(12, 42);
            this.simpleButtonThem.Name = "simpleButtonThem";
            this.simpleButtonThem.Size = new System.Drawing.Size(331, 38);
            this.simpleButtonThem.StyleController = this.layoutControl1;
            this.simpleButtonThem.TabIndex = 9;
            this.simpleButtonThem.Text = "Thêm";
            this.simpleButtonThem.Click += new System.EventHandler(this.simpleButtonThem_Click);
            // 
            // simpleButtonXoa
            // 
            this.simpleButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonXoa.Image")));
            this.simpleButtonXoa.Location = new System.Drawing.Point(682, 42);
            this.simpleButtonXoa.Name = "simpleButtonXoa";
            this.simpleButtonXoa.Size = new System.Drawing.Size(332, 38);
            this.simpleButtonXoa.StyleController = this.layoutControl1;
            this.simpleButtonXoa.TabIndex = 8;
            this.simpleButtonXoa.Text = "Xóa";
            this.simpleButtonXoa.Click += new System.EventHandler(this.simpleButtonXoa_Click);
            // 
            // simpleButtonSua
            // 
            this.simpleButtonSua.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSua.Image")));
            this.simpleButtonSua.Location = new System.Drawing.Point(347, 42);
            this.simpleButtonSua.Name = "simpleButtonSua";
            this.simpleButtonSua.Size = new System.Drawing.Size(331, 38);
            this.simpleButtonSua.StyleController = this.layoutControl1;
            this.simpleButtonSua.TabIndex = 7;
            this.simpleButtonSua.Text = "Cập Nhật";
            this.simpleButtonSua.Click += new System.EventHandler(this.simpleButtonSua_Click);
            // 
            // simpleButtonLammoi
            // 
            this.simpleButtonLammoi.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLammoi.Image")));
            this.simpleButtonLammoi.Location = new System.Drawing.Point(1018, 42);
            this.simpleButtonLammoi.Name = "simpleButtonLammoi";
            this.simpleButtonLammoi.Size = new System.Drawing.Size(332, 38);
            this.simpleButtonLammoi.StyleController = this.layoutControl1;
            this.simpleButtonLammoi.TabIndex = 6;
            this.simpleButtonLammoi.Text = "Làm Mới";
            this.simpleButtonLammoi.Click += new System.EventHandler(this.simpleButtonLammoi_Click);
            // 
            // textEditMoTa
            // 
            this.textEditMoTa.Location = new System.Drawing.Point(339, 12);
            this.textEditMoTa.Name = "textEditMoTa";
            this.textEditMoTa.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textEditMoTa.Properties.Appearance.Options.UseFont = true;
            this.textEditMoTa.Size = new System.Drawing.Size(1011, 26);
            this.textEditMoTa.StyleController = this.layoutControl1;
            this.textEditMoTa.TabIndex = 5;
            // 
            // textEditMaLT
            // 
            this.textEditMaLT.Location = new System.Drawing.Point(83, 12);
            this.textEditMaLT.Name = "textEditMaLT";
            this.textEditMaLT.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textEditMaLT.Properties.Appearance.Options.UseFont = true;
            this.textEditMaLT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditMaLT.Size = new System.Drawing.Size(181, 26);
            this.textEditMaLT.StyleController = this.layoutControl1;
            this.textEditMaLT.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1362, 650);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEditMaLT;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(256, 30);
            this.layoutControlItem1.Text = "Mã Loại Thuốc";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEditMoTa;
            this.layoutControlItem2.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1086, 30);
            this.layoutControlItem2.Text = "Mô Tả";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButtonLammoi;
            this.layoutControlItem3.Location = new System.Drawing.Point(1006, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(336, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.simpleButtonThem;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(335, 42);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButtonSua;
            this.layoutControlItem4.Location = new System.Drawing.Point(335, 30);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(335, 42);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButtonXoa;
            this.layoutControlItem5.Location = new System.Drawing.Point(670, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(336, 42);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dataGridViewLoaiThuoc;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1342, 558);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // lOAITHUOCBindingSource
            // 
            this.lOAITHUOCBindingSource.DataMember = "LOAITHUOC";
            this.lOAITHUOCBindingSource.DataSource = this.qLTHUOCTAYDataSet5;
            // 
            // qLTHUOCTAYDataSet5
            // 
            this.qLTHUOCTAYDataSet5.DataSetName = "QLTHUOCTAYDataSet5";
            this.qLTHUOCTAYDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lOAITHUOCTableAdapter
            // 
            this.lOAITHUOCTableAdapter.ClearBeforeFill = true;
            // 
            // formLoaiThuoc
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 650);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formLoaiThuoc";
            this.Text = "Quản Lý Loại Thuốc";
            this.Load += new System.EventHandler(this.formLoaiThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoaiThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMaLT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOAITHUOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTHUOCTAYDataSet5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit textEditMoTa;
        private DevExpress.XtraEditors.TextEdit textEditMaLT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.DataGridView dataGridViewLoaiThuoc;
        private DevExpress.XtraEditors.SimpleButton simpleButtonThem;
        private DevExpress.XtraEditors.SimpleButton simpleButtonXoa;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSua;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLammoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private QLTHUOCTAYDataSet5 qLTHUOCTAYDataSet5;
        private System.Windows.Forms.BindingSource lOAITHUOCBindingSource;
        private QLTHUOCTAYDataSet5TableAdapters.LOAITHUOCTableAdapter lOAITHUOCTableAdapter;
    }
}