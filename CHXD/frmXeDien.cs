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
    public partial class frmXeDien : Form
    {
        DataTable XeDien;
        public frmXeDien()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaXe, MaLoaiXe, TenXe, HangSanXuat, NamSanXuat, GiaBan, SoLuong,MoTa FROM XeDien";
            XeDien = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvxedien.DataSource = XeDien; //Nguồn dữ liệu            
            dgvxedien.Columns[0].HeaderText = "Mã Xe";
            dgvxedien.Columns[1].HeaderText = "Mã Loại Xe";
            dgvxedien.Columns[2].HeaderText = "Tên Xe";
            dgvxedien.Columns[3].HeaderText = "Hãng Sản Xuất";
            dgvxedien.Columns[4].HeaderText = "Năm Sản Xuất";
            dgvxedien.Columns[5].HeaderText = "Giá Bán";
            dgvxedien.Columns[6].HeaderText = "Số lượng";
            dgvxedien.Columns[7].HeaderText = "Mô Tả";
   
            dgvxedien.Columns[0].Width = 140;
            dgvxedien.Columns[1].Width = 140;
            dgvxedien.Columns[2].Width = 140;
            dgvxedien.Columns[3].Width = 140;
            dgvxedien.Columns[4].Width = 140;
            dgvxedien.Columns[5].Width = 140;
            dgvxedien.Columns[6].Width = 140;
            dgvxedien.Columns[6].Width = 140;
            dgvxedien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvxedien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmXeDien_Load(object sender, EventArgs e)
        {
            txtmaxe.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng

        }

        private void dgvxedien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaxe.Focus();
                return;
            }
            if (XeDien.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaxe.Text = dgvxedien.CurrentRow.Cells["MaXe"].Value.ToString();
            txtmaloaixe.Text = dgvxedien.CurrentRow.Cells["MaLoaiXe"].Value.ToString();
            txttenxe.Text = dgvxedien.CurrentRow.Cells["TenXe"].Value.ToString();
            txthangsx.Text = dgvxedien.CurrentRow.Cells["HangSanXuat"].Value.ToString();
            txtnamsx.Text = dgvxedien.CurrentRow.Cells["NamSanXuat"].Value.ToString();
            txtgiaban.Text = dgvxedien.CurrentRow.Cells["GiaBan"].Value.ToString();
            txtsoluong.Text = dgvxedien.CurrentRow.Cells["SoLuong"].Value.ToString();  
            txtmota.Text = dgvxedien.CurrentRow.Cells["MoTa"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtmaxe.Text = "";
            txtmaloaixe.Text = "";
            txttenxe.Text = "";
            txthangsx.Text = "";
            txtnamsx.Text = "";
            txtgiaban.Text = "";
            txtsoluong.Text = "";
            txtmota.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtmaxe.Enabled = true; //cho phép nhập mới
            txtmaxe.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmaxe.Text.Trim().Length == 0) //Nếu chưa nhập mã khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaxe.Focus();
                return;
            }
            if (txtmaloaixe.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaloaixe.Focus();
                return;
            }
            if (txttenxe.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập tên xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenxe.Focus();
                return;
            }
            if (txthangsx.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthangsx.Focus();
                return;
            }
            if (txtnamsx.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập năm sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnamsx.Focus();
                return;
            }
            if (txtgiaban.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgiaban.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            if (txtmota.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmota.Focus();
                return;
            }
            sql = "Select MaXe From XeDien where MaXe=N'" + txtmaxe.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã xe này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaxe.Focus();
                return;
            }

            sql = "INSERT INTO XeDien VALUES(N'" +
                txtmaxe.Text + "',N'" + txtmaloaixe.Text + "',N'" + txttenxe.Text + "',N'" + txthangsx.Text + "',N'" + txtnamsx.Text + "',N'" + txtgiaban.Text + "',N'" + txtsoluong.Text + "',N'" + txtmota.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaxe.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (XeDien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaxe.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaloaixe.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaloaixe.Focus();
                return;
            }
            if (txttenxe.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập tên xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenxe.Focus();
                return;
            }
            if (txthangsx.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập hãng sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthangsx.Focus();
                return;
            }
            if (txtnamsx.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập năm sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnamsx.Focus();
                return;
            }
            if (txtgiaban.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgiaban.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            if (txtmota.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmota.Focus();
                return;
            }
            sql = "UPDATE XeDien SET MaXe=N'" + txtmaxe.Text.ToString() +
                "', MaLoaiXe = N'" + txtmaloaixe.Text.ToString() +
                "', TenXe = N'" + txttenxe.Text.ToString() +
                "', HangSanXuat = N'" + txthangsx.Text.ToString() +
                "', NamSanXuat = N'" + txtnamsx.Text.ToString() +
                "', SoLuong = N'" + txtsoluong.Text.ToString() +
                "', MoTa = N'" + txtmota.Text.ToString() +
                "' WHERE MaXe=N'" + txtmaxe.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (XeDien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaxe.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE XeDien WHERE MaXe=N'" + txtmaxe.Text + "'";
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
            txtmaxe.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmaxe.Text == "") && (txttenxe.Text == "") && (txtmaloaixe.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from XeDien WHERE 1=1";
            if (txtmaxe.Text != "")
                sql += " AND MaXe LIKE N'%" + txtmaxe.Text + "%'";
            if (txttenxe.Text != "")
                sql += " AND TenXe LIKE N'%" + txttenxe.Text + "%'";
            if (txtmaloaixe.Text != "")
                sql += " AND MaLoaiXe LIKE N'%" + txtmaloaixe.Text + "%'";
            XeDien = Class.Functions.GetDataToTable(sql);
            if (XeDien.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + XeDien.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvxedien.DataSource = XeDien;
            ResetValue();
        }
    }
}
