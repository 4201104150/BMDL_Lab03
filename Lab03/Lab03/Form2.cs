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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataDataContext db = new DataDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void txt_tenlop_TextChanged(object sender, EventArgs e)
        {

        }

        private void loaddata()
        {
            var loop = db.LOPs.Where(p => p.NHANVIEN.MANV == frmDangNhap.manv); 
            dtgrLop.DataSource = db.LOPs.Select(p => new { p.MALOP, p.TENLOP, p.NHANVIEN.HOTEN });
            cbbTenNV.DataSource = loop.Select(p => p.NHANVIEN.HOTEN);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            LOP lop = new LOP { MALOP=txt_malop.Text,TENLOP=txt_tenlop.Text,MANV=frmDangNhap.manv };
            db.LOPs.InsertOnSubmit(lop);
            db.SubmitChanges();
            loaddata();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loaddata();
            btn_luu.Enabled = true;
            btn_huy.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            btn_them.Enabled = false;
            btn_luu.Enabled = true;
            btn_huy.Enabled = true;
        }

        private void btn_tailai_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_tenlop.Text = "";
            txt_malop.Text = "";
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_huy.Enabled = false;
            btn_luu.Enabled = false;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            LOP i = db.LOPs.SingleOrDefault(p => p.MALOP == txt_malop.Text);
            if (i != null)
            {
                i.MALOP = txt_malop.Text;
                i.MANV = frmDangNhap.manv;
                i.TENLOP = txt_tenlop.Text;
                db.SubmitChanges();
                loaddata();
            }
        }
        private void LoadDataToControl(int i)
        {
            string ma = dtgrLop.Rows[i].Cells[0].Value.ToString();
            LOP lop = db.LOPs.Where(p => p.MALOP == ma).FirstOrDefault();
            txt_malop.Text = lop.MALOP;
            txt_tenlop.Text = lop.TENLOP;
        }

        private void dtgrLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                LoadDataToControl(i);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            LOP i = db.LOPs.SingleOrDefault(p => p.MALOP == txt_malop.Text);
            if (i != null)
            {
                db.LOPs.DeleteOnSubmit(i);
                db.SubmitChanges();
                loaddata();
            }
        }

        private void dtgrLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
