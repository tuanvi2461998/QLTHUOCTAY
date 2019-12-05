namespace TestGD
{
    partial class formDangNhap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDangNhap));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxuser = new System.Windows.Forms.TextBox();
			this.textBoxPass = new System.Windows.Forms.TextBox();
			this.checkEdithienthi = new DevExpress.XtraEditors.CheckEdit();
			this.btDangNhap = new DevExpress.XtraEditors.SimpleButton();
			this.btHuy = new DevExpress.XtraEditors.SimpleButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.checkEdithienthi.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.ForeColor = System.Drawing.Color.DarkGreen;
			this.label1.Location = new System.Drawing.Point(41, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(402, 38);
			this.label1.TabIndex = 1;
			this.label1.Text = "    CHÀO MỪNG BẠN ĐẾN VỚI ỨNG DỤNG BÁN\r\nTHUỐC TÂY CỦA TRƯỜNG ĐẠI HỌC KIÊN GIANG";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label2.Location = new System.Drawing.Point(9, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "TÊN ĐĂNG NHẬP:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label3.Location = new System.Drawing.Point(53, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "MẬT KHẨU:";
			// 
			// textBoxuser
			// 
			this.textBoxuser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.textBoxuser.Location = new System.Drawing.Point(160, 68);
			this.textBoxuser.Multiline = true;
			this.textBoxuser.Name = "textBoxuser";
			this.textBoxuser.Size = new System.Drawing.Size(266, 29);
			this.textBoxuser.TabIndex = 0;
			this.textBoxuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxuser_KeyPress);
			// 
			// textBoxPass
			// 
			this.textBoxPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.textBoxPass.Location = new System.Drawing.Point(160, 111);
			this.textBoxPass.Multiline = true;
			this.textBoxPass.Name = "textBoxPass";
			this.textBoxPass.PasswordChar = '*';
			this.textBoxPass.Size = new System.Drawing.Size(266, 31);
			this.textBoxPass.TabIndex = 1;
			// 
			// checkEdithienthi
			// 
			this.checkEdithienthi.Location = new System.Drawing.Point(160, 158);
			this.checkEdithienthi.Name = "checkEdithienthi";
			this.checkEdithienthi.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.checkEdithienthi.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
			this.checkEdithienthi.Properties.Appearance.Options.UseFont = true;
			this.checkEdithienthi.Properties.Appearance.Options.UseForeColor = true;
			this.checkEdithienthi.Properties.Caption = "Hiện thị mật khẩu";
			this.checkEdithienthi.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style13;
			this.checkEdithienthi.Size = new System.Drawing.Size(208, 22);
			this.checkEdithienthi.TabIndex = 6;
			this.checkEdithienthi.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
			// 
			// btDangNhap
			// 
			this.btDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("btDangNhap.Image")));
			this.btDangNhap.Location = new System.Drawing.Point(160, 198);
			this.btDangNhap.Name = "btDangNhap";
			this.btDangNhap.Size = new System.Drawing.Size(129, 35);
			this.btDangNhap.TabIndex = 2;
			this.btDangNhap.Text = "Đăng Nhập";
			this.btDangNhap.Click += new System.EventHandler(this.simpleButton1_Click);
			// 
			// btHuy
			// 
			this.btHuy.Image = ((System.Drawing.Image)(resources.GetObject("btHuy.Image")));
			this.btHuy.Location = new System.Drawing.Point(295, 197);
			this.btHuy.Name = "btHuy";
			this.btHuy.Size = new System.Drawing.Size(131, 36);
			this.btHuy.TabIndex = 3;
			this.btHuy.Text = "Hủy";
			this.btHuy.Click += new System.EventHandler(this.simpleButton2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(463, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(235, 224);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// formDangNhap
			// 
			this.AcceptButton = this.btDangNhap;
			this.Appearance.BackColor = System.Drawing.Color.Silver;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(699, 245);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btHuy);
			this.Controls.Add(this.btDangNhap);
			this.Controls.Add(this.checkEdithienthi);
			this.Controls.Add(this.textBoxPass);
			this.Controls.Add(this.textBoxuser);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "formDangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đăng Nhập Hệ Thống";
			this.Load += new System.EventHandler(this.formDangNhap_Load);
			((System.ComponentModel.ISupportInitialize)(this.checkEdithienthi.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxuser;
        private System.Windows.Forms.TextBox textBoxPass;
        private DevExpress.XtraEditors.CheckEdit checkEdithienthi;
        private DevExpress.XtraEditors.SimpleButton btDangNhap;
        private DevExpress.XtraEditors.SimpleButton btHuy;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}