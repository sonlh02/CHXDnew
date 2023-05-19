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
    public partial class frmNhanVien : Form
    {
        DataTable NhanVien;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaNhanVien, HoTen, DiaChi, SoDienThoai, Email, NgaySinh, GioiTinh,ChucVu,Luong FROM NhanVien";
            NhanVien = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvnhanvien.DataSource = NhanVien; //Nguồn dữ liệu            
            dgvnhanvien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvnhanvien.Columns[1].HeaderText = "Họ Tên";
            dgvnhanvien.Columns[2].HeaderText = "Địa Chỉ";
            dgvnhanvien.Columns[3].HeaderText = "Số Điện Thoại";
            dgvnhanvien.Columns[4].HeaderText = "Email";
            dgvnhanvien.Columns[5].HeaderText = "Ngày Sinh";
            dgvnhanvien.Columns[6].HeaderText = "Giới Tính";
            dgvnhanvien.Columns[7].HeaderText = "Chức Vụ";
            dgvnhanvien.Columns[8].HeaderText = "Lương";
            dgvnhanvien.Columns[0].Width = 140;
            dgvnhanvien.Columns[1].Width = 140;
            dgvnhanvien.Columns[2].Width = 140;
            dgvnhanvien.Columns[3].Width = 140;
            dgvnhanvien.Columns[4].Width = 140;
            dgvnhanvien.Columns[5].Width = 140;
            dgvnhanvien.Columns[6].Width = 140;
            dgvnhanvien.Columns[7].Width = 140;
            dgvnhanvien.Columns[8].Width = 140;
            dgvnhanvien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtmanhanvien.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng
        }

        private void dgvnhanvien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (NhanVien.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhanvien.Text = dgvnhanvien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txthoten.Text = dgvnhanvien.CurrentRow.Cells["HoTen"].Value.ToString();
            txtdiachi.Text = dgvnhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsodienthoai.Text = dgvnhanvien.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtemail.Text = dgvnhanvien.CurrentRow.Cells["Email"].Value.ToString();
            dtpngaysinh.Text = dgvnhanvien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtGioiTinh.Text = dgvnhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtchucvu.Text = dgvnhanvien.CurrentRow.Cells["ChucVu"].Value.ToString();
            txtluong.Text = dgvnhanvien.CurrentRow.Cells["Luong"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtmanhanvien.Text = "";
            txthoten.Text = "";
            txtdiachi.Text = "";
            txtsodienthoai.Text = "";
            txtemail.Text = "";
            dtpngaysinh.Text = "";
            txtGioiTinh.Text = "";
            txtchucvu.Text = "";
            txtluong.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtmanhanvien.Enabled = true; //cho phép nhập mới
            txtmanhanvien.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmanhanvien.Text.Trim().Length == 0) //Nếu chưa nhập mã khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhanvien.Focus();
                return;
            }
            if (txthoten.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthoten.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (txtsodienthoai.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsodienthoai.Focus();
                return;
            }
            if (txtemail.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtemail.Focus();
                return;
            }
            if (txtGioiTinh.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiTinh.Focus();
                return;
            }
            if (txtchucvu.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsodienthoai.Focus();
                return;
            }
            if (txtluong.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsodienthoai.Focus();
                return;
            }
            sql = "Select MaNhanVien From NhanVien where MaNhanVien=N'" + txtmanhanvien.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhanvien.Focus();
                return;
            }

            sql = "INSERT INTO NhanVien VALUES(N'" +
                txtmanhanvien.Text + "',N'" + txthoten.Text + "',N'" + txtdiachi.Text + "',N'" + txtsodienthoai.Text + "',N'" + txtemail.Text + "',N'" + dtpngaysinh.Text + "',N'" + txtGioiTinh.Text + "',N'" + txtchucvu.Text + "',N'" + txtluong.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txthoten.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (txtchucvu.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (txtluong.Text.Trim().Length == 0) //Nếu chưa
            {
                MessageBox.Show("Bạn phải nhập lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            sql = "UPDATE NhanVien SET HoTen=N'" + txthoten.Text.ToString() +
                "', DiaChi = N'" + txtdiachi.Text.ToString() +
                "', SoDienThoai = N'" + txtsodienthoai.Text.ToString() +
                "', Email = N'" + txtemail.Text.ToString() +
                "', NgaySinh = N'" + dtpngaysinh.Text.ToString() +
                "', GioiTinh = N'" + txtGioiTinh.Text.ToString() +
                "', Chucvu = N'" + txtchucvu.Text.ToString() +
                  "', Luong = N'" + txtluong.Text.ToString() +
                "' WHERE MaNhanVien=N'" + txtmanhanvien.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhanvien.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NhanVien WHERE MaNhanVien=N'" + txtmanhanvien.Text + "'";
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
            txtmanhanvien.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmanhanvien.Text == "") && (txthoten.Text == "") && (txtdiachi.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from NhanVien WHERE 1=1";
            if (txtmanhanvien.Text != "")
                sql += " AND MaNhanVien LIKE N'%" + txtmanhanvien.Text + "%'";
            if (txthoten.Text != "")
                sql += " AND HoTen LIKE N'%" + txthoten.Text + "%'";
            if (txtdiachi.Text != "")
                sql += " AND DiaChi LIKE N'%" + txtdiachi.Text + "%'";
            NhanVien = Class.Functions.GetDataToTable(sql);
            if (NhanVien.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + NhanVien.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvnhanvien.DataSource = NhanVien;
            ResetValue();
        }
    }
}
