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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        DataDataContext dt = new DataDataContext();

        private void LoadData()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.xlXemDiemThi(frmDangNhap.manv, frmDangNhap.pass);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt.xlNhapDiem(txtMaSV.Text,txtMaHP.Text,txtDiemThi.Text,frmDangNhap.manv);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.xlXemDiemThi(frmDangNhap.manv, frmDangNhap.pass);
            button3.Enabled = false;
            button4.Enabled = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtMaHP.Text = "";
            txtDiemThi.Text = "";
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
