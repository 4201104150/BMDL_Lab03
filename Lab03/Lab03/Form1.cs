using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            
        }
        public static string name="";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (frmDangNhap.flag == true)
            {
                txtLoiChao.Text = "Xin chào:" +frmDangNhap.hotenngdn +" !";
            }
            else
            {
                txtLoiChao.Text = "";
            }
        }

        private void btn_QLLH_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.Show();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_QLSV_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f = new Form3();
            f.Show();
        }

        private void btn_ND_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            this.Hide();
            form.Show();
        }
    }
}
