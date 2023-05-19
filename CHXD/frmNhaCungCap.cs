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
    public partial class frmNhaCungCap : Form
    {
        DataTable NhaCungCap;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, Email FROM NhaCungCap";
            NhaCungCap = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvNhaCungCap.DataSource = NhaCungCap; //Nguồn dữ liệu            
            dgvNhaCungCap.Columns[0].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên NCC";
            dgvNhaCungCap.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhaCungCap.Columns[3].HeaderText = "Số Điện Thoại";
            dgvNhaCungCap.Columns[4].HeaderText = "Email";
            dgvNhaCungCap.Columns[0].Width = 140;
            dgvNhaCungCap.Columns[1].Width = 140;
            dgvNhaCungCap.Columns[2].Width = 140;
            dgvNhaCungCap.Columns[3].Width = 140;
            dgvNhaCungCap.Columns[4].Width = 140;
            dgvNhaCungCap.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNhaCungCap.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhaCungCap.Focus();
                return;
            }
            if (NhaCungCap.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
            txtTenNhaCungCap.Text = dgvNhaCungCap.CurrentRow.Cells["TenNhaCungCap"].Value.ToString();
            txtDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = dgvNhaCungCap.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = dgvNhaCungCap.CurrentRow.Cells["Email"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaNhaCungCap.Enabled = true; //cho phép nhập mới
            txtMaNhaCungCap.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaNhaCungCap.Text.Trim().Length == 0) //Nếu chưa nhập mã nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhaCungCap.Focus();
                return;
            }
            if (txtTenNhaCungCap.Text.Trim().Length == 0) //Nếu chưa nhập tên nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhaCungCap.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtEmail.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            sql = "Select MaNhaCungCap From NhaCungCap where MaNhaCungCap=N'" + txtMaNhaCungCap.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhaCungCap.Focus();
                return;
            }

            sql = "INSERT INTO NhaCungCap VALUES(N'" +
                txtMaNhaCungCap.Text + "',N'" + txtTenNhaCungCap.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "',N'" + txtEmail.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNhaCungCap.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhaCungCap.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhaCungCap.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (txtEmail.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            sql = "UPDATE NhaCungCap SET TenNhaCungCap=N'" + txtTenNhaCungCap.Text.ToString() +
                "', DiaChi = N'" + txtDiaChi.Text.ToString() +
                "', SoDienThoai = N'" + txtSoDienThoai.Text.ToString() +
                "', Email = N'" + txtEmail.Text.ToString() +
                "' WHERE MaNhaCungCap=N'" + txtMaNhaCungCap.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhaCungCap.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NhaCungCap WHERE MaNhaCungCap=N'" + txtMaNhaCungCap.Text + "'";
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
            txtMaNhaCungCap.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNhaCungCap.Text == "") && (txtTenNhaCungCap.Text == "") && (txtDiaChi.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from NhaCungCap WHERE 1=1";
            if (txtMaNhaCungCap.Text != "")
                sql += " AND MaNhaCungCap LIKE N'%" + txtMaNhaCungCap.Text + "%'";
            if (txtTenNhaCungCap.Text != "")
                sql += " AND TenNhaCungCap LIKE N'%" + txtTenNhaCungCap.Text + "%'";
            if (txtDiaChi.Text != "")
                sql += " AND DiaChi LIKE N'%" + txtDiaChi.Text + "%'";
            NhaCungCap = Functions.GetDataToTable(sql);
            if (NhaCungCap.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + NhaCungCap.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNhaCungCap.DataSource = NhaCungCap;
            ResetValue();
        }
    }
}
