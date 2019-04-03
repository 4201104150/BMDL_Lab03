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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static bool flag = false;
        public static string hotenngdn = "";
        public static string manv = "";
        public static string pass = "";
        DataDataContext db = new DataDataContext();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SP_SEL_PUBLIC_NHANVIENResult s = db.SP_SEL_PUBLIC_NHANVIEN(txtUs.Text, txtPs.Text).SingleOrDefault();
            
            if (s!=null)
            {
                hotenngdn = db.NHANVIENs.Where(p=>p.TENDN==txtUs.Text).Select(p=>p.HOTEN).FirstOrDefault();
                manv = db.NHANVIENs.Where(p=>p.TENDN==txtUs.Text).Select(p=>p.MANV).FirstOrDefault();
                pass = txtPs.Text;
                flag = true;
                Form1 f = new Form1();
                f.Show();
                this.Hide();
                MessageBox.Show("Đăng nhập thành công!");
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
                this.Hide();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
