using CHXD.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHXD
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from TaiKhoan where Username = '{0}' and Password = '{1}'", txtTaiKhoan.Text, txtMatKhau.Text);
            DataSet ds = Class.Functions.laydulieu(query, "TaiKhoan");
            if (ds.Tables["TaiKhoan"].Rows.Count == 1)
            {
                MessageBox.Show("Dang nhap thanh cong");
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
