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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        DataDataContext db = new DataDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.xlXemDSSV(frmDangNhap.manv);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            cbbLophoc.DataSource = db.LOPs.SingleOrDefault(p=>p.MANV==frmDangNhap.manv);
            cbbLophoc.DisplayMember = "TENLOP";
            cbbLophoc.ValueMember = "MALOP";
        }

        private void loatdatatocontrol(int i)
        {
            string masv = dataGridView1.Rows[i].Cells[0].ToString();
            SINHVIEN s = db.SINHVIENs.Where(p => p.MASV == masv).FirstOrDefault();
            txtDiaChi.Text = s.DIACHI;
            txtHoTen.Text = s.HOTEN;
            txtMaSV.Text = s.MASV;
            txtTenDN.Text = s.TENDN;
            dateTimePicker1.Value = s.NGAYSINH.Value;
            cbbLophoc.Text = s.LOP.TENLOP;
        }

        private void btntailai_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.xlXemDSSV(frmDangNhap.manv);
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtMaSV.Text = "";
            txtMatKhau.Text = "";
            txtTenDN.Text = "";
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            //xử lý lưu
            db.xlUpdateSV(txtMaSV.Text, txtHoTen.Text, dateTimePicker1.Value.Date, txtDiaChi.Text, cbbLophoc.ValueMember.ToString(), txtMatKhau.Text);
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            txtMaSV.Enabled = false;
            txtTenDN.Enabled = false;
        }
    }
}
