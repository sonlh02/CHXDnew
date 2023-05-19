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
    public partial class frmBaoHanh : Form
    {
        DataTable BaoHanh;
        public frmBaoHanh()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaBaoHanh, MaKhachHang, MaXe, NgayLap, NgayHetHan, NoiDung, TinhTrang FROM BaoHanh";
            BaoHanh = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvbaohanh.DataSource = BaoHanh; //Nguồn dữ liệu            
            dgvbaohanh.Columns[0].HeaderText = "Mã Bảo Hành";
            dgvbaohanh.Columns[1].HeaderText = "Mã Khách Hàng";
            dgvbaohanh.Columns[2].HeaderText = "Mã Xe";
            dgvbaohanh.Columns[3].HeaderText = "Ngày Lập";
            dgvbaohanh.Columns[4].HeaderText = "Ngày Hết Hạn";
            dgvbaohanh.Columns[5].HeaderText = "Nội Dung";
            dgvbaohanh.Columns[6].HeaderText = "Tình Trạng";
            dgvbaohanh.Columns[0].Width = 140;
            dgvbaohanh.Columns[1].Width = 140;
            dgvbaohanh.Columns[2].Width = 140;
            dgvbaohanh.Columns[3].Width = 140;
            dgvbaohanh.Columns[4].Width = 140;
            dgvbaohanh.Columns[5].Width = 140;
            dgvbaohanh.Columns[6].Width = 140;
            dgvbaohanh.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvbaohanh.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void frmBaoHanh_Load(object sender, EventArgs e)
        {
            txtmabaohanh.Enabled = false;
            btnLuu.Enabled = false;
            //btnthoat.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng
        }

        private void dgvbaohanh_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmabaohanh.Focus();
                return;
            }
            if (BaoHanh.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmabaohanh.Text = dgvbaohanh.CurrentRow.Cells["MaBaoHanh"].Value.ToString();
            txtmakhachhang.Text = dgvbaohanh.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            txtmaxe.Text = dgvbaohanh.CurrentRow.Cells["MaXe"].Value.ToString();
            dtpngaylap.Text = dgvbaohanh.CurrentRow.Cells["NgayLap"].Value.ToString();
            dtpngayhethan.Text = dgvbaohanh.CurrentRow.Cells["NgayHetHan"].Value.ToString();
            txtnoidung.Text = dgvbaohanh.CurrentRow.Cells["NoiDung"].Value.ToString();
            txttinhtrang.Text = dgvbaohanh.CurrentRow.Cells["TinhTrang"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private void ResetValue()
        {
            txtmabaohanh.Text = "";
            txtmakhachhang.Text = "";
            txtmaxe.Text = "";
            txtnoidung.Text = "";
            txttinhtrang.Text = "";
            dtpngaylap.Text = "";
            dtpngayhethan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtmabaohanh.Enabled = true; //cho phép nhập mới
            txtmabaohanh.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmabaohanh.Text.Trim().Length == 0) //Nếu chưa nhập mã khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmabaohanh.Focus();
                return;
            }
            if (txtmaxe.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaxe.Focus();
                return;
            }
            if (txtmakhachhang.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhachhang.Focus();
                return;
            }
            if (txtnoidung.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnoidung.Focus();
                return;
            }
            if (txttinhtrang.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (dtpngaylap.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpngaylap.Focus();
                return;
            }
            if (dtpngayhethan.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpngayhethan.Focus();
                return;
            }
            sql = "Select MaBaoHanh From BaoHanh where MaBaoHanh=N'" + txtmabaohanh.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmakhachhang.Focus();
                return;
            }

            sql = "INSERT INTO BaoHanh VALUES(N'" +
                txtmabaohanh.Text + "',N'" + txtmakhachhang.Text + "',N'" + txtmaxe.Text + "',N'" + dtpngaylap.Text + "',N'" + dtpngayhethan.Text + "',N'" + txtnoidung.Text + "',N'" + txttinhtrang.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtmabaohanh.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (BaoHanh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmabaohanh.Text.Trim().Length == 0) //Nếu chưa nhập mã khách hàng
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmabaohanh.Focus();
                return;
            }
            if (txtmaxe.Text.Trim().Length == 0) //Nếu chưa nhập tên khách hàng
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaxe.Focus();
                return;
            }
            if (txtmakhachhang.Text.Trim().Length == 0) //Nếu chưa nhập địa chỉ
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmakhachhang.Focus();
                return;
            }
            if (txtnoidung.Text.Trim().Length == 0) //Nếu chưa nhập số điện thoại
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnoidung.Focus();
                return;
            }
            if (txttinhtrang.Text.Trim().Length == 0) //Nếu chưa nhập email
            {
                MessageBox.Show("Bạn phải nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttinhtrang.Focus();
                return;
            }
            if (dtpngaylap.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpngaylap.Focus();
                return;
            }
            if (dtpngayhethan.Text.Trim().Length == 0) //Nếu chưa nhập giới tính
            {
                MessageBox.Show("Bạn phải nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpngayhethan.Focus();
                return;
            }
            sql = "UPDATE BaoHanh SET MaKhachHang=N'" + txtmakhachhang.Text.ToString() +
                "', MaXe = N'" + txtmaxe.Text.ToString() +
                "', NgayLap = N'" + dtpngaylap.Text.ToString() +
                "', NgayHetHan = N'" + dtpngayhethan.Text.ToString() +
                "', NoiDung = N'" + txtnoidung.Text.ToString() +
                "', TinhTrang = N'" + txttinhtrang.Text.ToString() +
                "' WHERE MaBaoHanh=N'" + txtmabaohanh.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (BaoHanh.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmabaohanh.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE BaoHanh WHERE MaBaoHanh=N'" + txtmabaohanh.Text + "'";
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
            txtmabaohanh.Enabled = false;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtmakhachhang.Text == "") && (txtmabaohanh.Text == "") && (txtmaxe.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from BaoHanh WHERE 1=1";
            if (txtmakhachhang.Text != "")
                sql += " AND MaKhachHang LIKE N'%" + txtmakhachhang.Text + "%'";
            if (txtmabaohanh.Text != "")
                sql += " AND MaBaohanh LIKE N'%" + txtmabaohanh.Text + "%'";
            if (txtmaxe.Text != "")
                sql += " AND MaXe LIKE N'%" + txtmaxe.Text + "%'";
            BaoHanh = Class.Functions.GetDataToTable(sql);
            if (BaoHanh.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + BaoHanh.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvbaohanh.DataSource = BaoHanh;
            ResetValue();
        }
    }
}
