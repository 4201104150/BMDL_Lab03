namespace Lab03
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_malop = new System.Windows.Forms.TextBox();
            this.txt_tenlop = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_tailai = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.dtgrLop = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbTenNV = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrLop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Lớp";
            // 
            // txt_malop
            // 
            this.txt_malop.Location = new System.Drawing.Point(105, 43);
            this.txt_malop.Name = "txt_malop";
            this.txt_malop.Size = new System.Drawing.Size(100, 20);
            this.txt_malop.TabIndex = 3;
            // 
            // txt_tenlop
            // 
            this.txt_tenlop.Location = new System.Drawing.Point(286, 45);
            this.txt_tenlop.Name = "txt_tenlop";
            this.txt_tenlop.Size = new System.Drawing.Size(100, 20);
            this.txt_tenlop.TabIndex = 4;
            this.txt_tenlop.TextChanged += new System.EventHandler(this.txt_tenlop_TextChanged);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(27, 89);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(75, 21);
            this.btn_them.TabIndex = 6;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_tailai
            // 
            this.btn_tailai.Location = new System.Drawing.Point(432, 89);
            this.btn_tailai.Name = "btn_tailai";
            this.btn_tailai.Size = new System.Drawing.Size(75, 21);
            this.btn_tailai.TabIndex = 7;
            this.btn_tailai.Text = "Tải Lại";
            this.btn_tailai.UseVisualStyleBackColor = true;
            this.btn_tailai.Click += new System.EventHandler(this.btn_tailai_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(351, 89);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(75, 21);
            this.btn_xoa.TabIndex = 8;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(270, 89);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(75, 21);
            this.btn_huy.TabIndex = 9;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(189, 89);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(75, 21);
            this.btn_luu.TabIndex = 10;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(108, 89);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(75, 21);
            this.btn_sua.TabIndex = 11;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // dtgrLop
            // 
            this.dtgrLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.TenLop,
            this.TenNhanVien});
            this.dtgrLop.Location = new System.Drawing.Point(27, 147);
            this.dtgrLop.Name = "dtgrLop";
            this.dtgrLop.Size = new System.Drawing.Size(561, 139);
            this.dtgrLop.TabIndex = 12;
            this.dtgrLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrLop_CellClick);
            this.dtgrLop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrLop_CellContentClick);
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MALOP";
            this.MaLop.HeaderText = "Mã Lớp";
            this.MaLop.Name = "MaLop";
            // 
            // TenLop
            // 
            this.TenLop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenLop.DataPropertyName = "TENLOP";
            this.TenLop.HeaderText = "Tên Lớp";
            this.TenLop.Name = "TenLop";
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenNhanVien.DataPropertyName = "HOTEN";
            this.TenNhanVien.HeaderText = "Tên Nhân Viên";
            this.TenNhanVien.Name = "TenNhanVien";
            // 
            // cbbTenNV
            // 
            this.cbbTenNV.Enabled = false;
            this.cbbTenNV.FormattingEnabled = true;
            this.cbbTenNV.Location = new System.Drawing.Point(466, 46);
            this.cbbTenNV.Name = "cbbTenNV";
            this.cbbTenNV.Size = new System.Drawing.Size(121, 21);
            this.cbbTenNV.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 295);
            this.Controls.Add(this.cbbTenNV);
            this.Controls.Add(this.dtgrLop);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_tailai);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_tenlop);
            this.Controls.Add(this.txt_malop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_malop;
        private System.Windows.Forms.TextBox txt_tenlop;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_tailai;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.DataGridView dtgrLop;
        private System.Windows.Forms.ComboBox cbbTenNV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
    }
}