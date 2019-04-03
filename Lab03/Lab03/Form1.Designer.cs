namespace Lab03
{
    partial class Form1
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
            this.btn_QLLH = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_ND = new System.Windows.Forms.Button();
            this.btn_QLSV = new System.Windows.Forms.Button();
            this.txtLoiChao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_QLLH
            // 
            this.btn_QLLH.Location = new System.Drawing.Point(12, 12);
            this.btn_QLLH.Name = "btn_QLLH";
            this.btn_QLLH.Size = new System.Drawing.Size(99, 49);
            this.btn_QLLH.TabIndex = 0;
            this.btn_QLLH.Text = "QL Lớp Học";
            this.btn_QLLH.UseVisualStyleBackColor = true;
            this.btn_QLLH.Click += new System.EventHandler(this.btn_QLLH_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(139, 88);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(89, 49);
            this.btn_thoat.TabIndex = 1;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(12, 88);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(90, 49);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Đăng Nhập";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_ND
            // 
            this.btn_ND.Location = new System.Drawing.Point(260, 12);
            this.btn_ND.Name = "btn_ND";
            this.btn_ND.Size = new System.Drawing.Size(83, 49);
            this.btn_ND.TabIndex = 3;
            this.btn_ND.Text = "Nhập điểm";
            this.btn_ND.UseVisualStyleBackColor = true;
            this.btn_ND.Click += new System.EventHandler(this.btn_ND_Click);
            // 
            // btn_QLSV
            // 
            this.btn_QLSV.Location = new System.Drawing.Point(139, 12);
            this.btn_QLSV.Name = "btn_QLSV";
            this.btn_QLSV.Size = new System.Drawing.Size(89, 49);
            this.btn_QLSV.TabIndex = 4;
            this.btn_QLSV.Text = "QL Sinh Viên ";
            this.btn_QLSV.UseVisualStyleBackColor = true;
            this.btn_QLSV.Click += new System.EventHandler(this.btn_QLSV_Click);
            // 
            // txtLoiChao
            // 
            this.txtLoiChao.AutoSize = true;
            this.txtLoiChao.Location = new System.Drawing.Point(260, 106);
            this.txtLoiChao.Name = "txtLoiChao";
            this.txtLoiChao.Size = new System.Drawing.Size(0, 13);
            this.txtLoiChao.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 159);
            this.Controls.Add(this.txtLoiChao);
            this.Controls.Add(this.btn_QLSV);
            this.Controls.Add(this.btn_ND);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_QLLH);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_QLLH;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_ND;
        private System.Windows.Forms.Button btn_QLSV;
        private System.Windows.Forms.Label txtLoiChao;
    }
}

