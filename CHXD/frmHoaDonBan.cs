using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CHXD.Class;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace CHXD
{
    public partial class frmHoaDonBan : Form
    {
        DataTable ChiTietHoaDon;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayLap FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            dtpngaylap.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "SELECT MaNhanVien FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            cbomanhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaKhachHang FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            cbomakhchhang.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM HoaDon WHERE MaHoaDon = N'" + txtmahoadon.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);
            lblTongTien.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(double.Parse(txttongtien.Text));
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaXe, b.TenXe, a.SoLuong, a.DonGia,a.GiamGia,a.ThanhTien FROM ChiTietHoaDon AS a, XeDien AS b WHERE a.MaHoaDon = N'" + txtmahoadon.Text + "' AND a.MaXe=b.MaXe";
            ChiTietHoaDon = Functions.GetDataToTable(sql);
            dgvHoaDonBan.DataSource = ChiTietHoaDon;
            dgvHoaDonBan.Columns[0].HeaderText = "Mã Xe";
            dgvHoaDonBan.Columns[1].HeaderText = "Tên Xe";
            dgvHoaDonBan.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonBan.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonBan.Columns[4].HeaderText = "Giảm giá %";
            dgvHoaDonBan.Columns[5].HeaderText = "Thành tiền";
            dgvHoaDonBan.Columns[0].Width = 80;
            dgvHoaDonBan.Columns[1].Width = 130;
            dgvHoaDonBan.Columns[2].Width = 80;
            dgvHoaDonBan.Columns[3].Width = 90;
            dgvHoaDonBan.Columns[4].Width = 90;
            dgvHoaDonBan.Columns[4].Width = 90;
            dgvHoaDonBan.AllowUserToAddRows = false;
            dgvHoaDonBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            txtmahoadon.ReadOnly = true;
            txttennhanvien.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtTenXe.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txttongtien.Text = "0";
            Functions.FillCombo("SELECT MaKhachHang, HoTen FROM KhachHang", cbomakhchhang, "MaKhachHang", "MaKhachHang");
            cbomakhchhang.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien, HoTen FROM NhanVien", cbomanhanvien, "MaNhanVien", "MaNhanVien");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaXe, TenXe FROM XeDien", cbomaxe, "MaXe", "MaXe");
            cbomaxe.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtmahoadon.Text != "")
            {
                LoadInfoHoaDon();
                btnhuy.Enabled = true;
                btnin.Enabled = true;
            }
            LoadDataGridView();
        }
    }
}
