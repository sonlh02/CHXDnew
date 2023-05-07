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
namespace CHXD
{
    public partial class frmKhachHang : Form
    {
        DataTable KhachHang;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaKhachHang, HoTen, DiaChi, SoDienThoai, Email, NgaySinh, GioiTinh FROM KhachHang";
            KhachHang = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvkhachhang.DataSource = KhachHang; //Nguồn dữ liệu            
            dgvkhachhang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvkhachhang.Columns[1].HeaderText = "Họ Tên";
            dgvkhachhang.Columns[2].HeaderText = "Địa Chỉ";
            dgvkhachhang.Columns[3].HeaderText = "Số Điện Thoại";
            dgvkhachhang.Columns[4].HeaderText = "Email";
            dgvkhachhang.Columns[5].HeaderText = "Ngày Sinh";
            dgvkhachhang.Columns[6].HeaderText = "Giới Tính";
            dgvkhachhang.Columns[0].Width = 140;
            dgvkhachhang.Columns[1].Width = 140;
            dgvkhachhang.Columns[2].Width = 140;
            dgvkhachhang.Columns[3].Width = 140;
            dgvkhachhang.Columns[4].Width = 140;
            dgvkhachhang.Columns[5].Width = 140;
            dgvkhachhang.Columns[6].Width = 140;
            dgvkhachhang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            txtmakhachhang.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }

        private void dgvkhachhang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhachhang.Focus();
                return;
            }
            if (KhachHang.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmakhachhang.Text = dgvkhachhang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            txthoten.Text = dgvkhachhang.CurrentRow.Cells["HoTen"].Value.ToString();
            txtdiachi.Text = dgvkhachhang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsodienthoai.Text = dgvkhachhang.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtemail.Text = dgvkhachhang.CurrentRow.Cells["Email"].Value.ToString();
            dtpngaysinh.Text = dgvkhachhang.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtGioiTinh.Text = dgvkhachhang.CurrentRow.Cells["GioiTinh"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtmakhachhang.Text = "";
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtsodienthoai.Text = "";
            txtemail.Text = "";
            dtpngaysinh.Text = "";
            txtGioiTinh.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtmakhachhang.Enabled = true; //cho phép nhập mới
            txtmakhachhang.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmakhachhang.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhachhang.Focus();
                return;
            }
            if (txthoten.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthoten.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (txtsodienthoai.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsodienthoai.Focus();
                return;
            }
            if (txtemail.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Focus();
                return;
            }
            if (txtGioiTinh.Text.Trim().Length == 0) //Nếu chưa
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiTinh.Focus();
                return;
            }
            sql = "Select MaKhachHang From KhachHang where MaKhachHang=N'" + txtmakhachhang.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakhachhang.Focus();
                return;
            }

            sql = "INSERT INTO KhachHang VALUES(N'" +
                txtmakhachhang.Text + "',N'" + txthoten.Text + "',N'" + txtdiachi.Text + "',N'" + txtsodienthoai.Text + "',N'" + txtemail.Text + "',N'" + dtpngaysinh.Text + "',N'" + txtGioiTinh.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmakhachhang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhachhang.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txthoten.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;
            }
            if (txtsodienthoai.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;
            }
            if (txtemail.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            if (txtGioiTinh.Text.Trim().Length == 0) //Nếu chưa
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            sql = "UPDATE KhachHang SET HoTen=N'" + txthoten.Text.ToString() +
                "', DiaChi = N'" + txtdiachi.Text.ToString() +
                "', SoDienThoai = N'" + txtsodienthoai.Text.ToString() +
                "', Email = N'" + txtemail.Text.ToString() +
                "', NgaySinh = N'" + dtpngaysinh.Text.ToString() +
                "', GioiTinh = N'" + txtGioiTinh.Text.ToString() +
                "' WHERE MaKhachHang=N'" + txtmakhachhang.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (KhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakhachhang.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KhachHang WHERE MaKhachHang=N'" + txtmakhachhang.Text + "'";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmakhachhang.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
