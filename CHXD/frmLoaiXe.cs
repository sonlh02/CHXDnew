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
    public partial class frmLoaiXe : Form
    {
        DataTable LoaiXe;
        public frmLoaiXe()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaLoaiXe, MaNhaCungCap, TenLoaiXe, MoTa FROM LoaiXe";
            LoaiXe = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvLoaiXe.DataSource = LoaiXe; //Nguồn dữ liệu            
            dgvLoaiXe.Columns[0].HeaderText = "Mã Loại Xe";
            dgvLoaiXe.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
            dgvLoaiXe.Columns[2].HeaderText = "Tên Loại Xe";
            dgvLoaiXe.Columns[3].HeaderText = "Mô Tả";
            dgvLoaiXe.Columns[0].Width = 140;
            dgvLoaiXe.Columns[1].Width = 140;
            dgvLoaiXe.Columns[2].Width = 140;
            dgvLoaiXe.Columns[3].Width = 140;
            dgvLoaiXe.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiXe.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void frmLoaiXe_Load(object sender, EventArgs e)
        {
            txtMaLoaiXe.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng
        }

        private void dgvLoaiXe_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiXe.Focus();
                return;
            }
            if (LoaiXe.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoaiXe.Text = dgvLoaiXe.CurrentRow.Cells["MaLoaiXe"].Value.ToString();
            txtMaNhaCungCap.Text = dgvLoaiXe.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
            txtTenLoaiXe.Text = dgvLoaiXe.CurrentRow.Cells["TenLoaiXe"].Value.ToString();
            txtMoTa.Text = dgvLoaiXe.CurrentRow.Cells["MoTa"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtMaNhaCungCap.Text = "";
            txtMaLoaiXe.Text = "";
            txtTenLoaiXe.Text = "";
            txtMoTa.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaLoaiXe.Enabled = true; //cho phép nhập mới
            txtMaLoaiXe.Focus();
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
            if (txtMaLoaiXe.Text.Trim().Length == 0) //Nếu chưa nhập mã loại xe
            {
                MessageBox.Show("Bạn phải nhập mã loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiXe.Focus();
                return;
            }
            if (txtTenLoaiXe.Text.Trim().Length == 0) //Nếu chưa nhập tên loại xe
            {
                MessageBox.Show("Bạn phải nhập tên loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiXe.Focus();
                return;
            }
            if (txtMoTa.Text.Trim().Length == 0) //Nếu chưa nhập mô tả
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMoTa.Focus();
                return;
            }
            sql = "Select MaLoaiXe From LoaiXe where MaLoaiXe=N'" + txtMaLoaiXe.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại xe này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiXe.Focus();
                return;
            }

            sql = "INSERT INTO LoaiXe VALUES(N'" +
                txtMaLoaiXe.Text + "',N'" + txtMaNhaCungCap.Text + "',N'" + txtTenLoaiXe.Text + "',N'" + txtMoTa.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLoaiXe.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (LoaiXe.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiXe.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhaCungCap.Text.Trim().Length == 0) //Nếu chưa nhập mã nhà cung cấp
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenLoaiXe.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập tên loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (txtMoTa.Text.Trim().Length == 0) //Nếu chưa nhập
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            sql = "UPDATE LoaiXe SET MaNhaCungCap=N'" + txtMaNhaCungCap.Text.ToString() +
                "', TenLoaiXe = N'" + txtTenLoaiXe.Text.ToString() +
                "', MoTa = N'" + txtMoTa.Text.ToString() +
                "' WHERE MaLoaiXe=N'" + txtMaLoaiXe.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (LoaiXe.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiXe.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE LoaiXe WHERE MaLoaiXe=N'" + txtMaLoaiXe.Text + "'";
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
            txtMaLoaiXe.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaNhaCungCap.Text == "") && (txtMaLoaiXe.Text == "") && (txtTenLoaiXe.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from LoaiXe WHERE 1=1";
            if (txtMaNhaCungCap.Text != "")
                sql += " AND MaNhaCungCap LIKE N'%" + txtMaNhaCungCap.Text + "%'";
            if (txtMaLoaiXe.Text != "")
                sql += " AND MaLoaiXe LIKE N'%" + txtMaLoaiXe.Text + "%'";
            if (txtTenLoaiXe.Text != "")
                sql += " AND TenLoaiXe LIKE N'%" + txtTenLoaiXe.Text + "%'";
            LoaiXe = Functions.GetDataToTable(sql);
            if (LoaiXe.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + LoaiXe.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvLoaiXe.DataSource = LoaiXe;
            ResetValue();
        }
    }
}
