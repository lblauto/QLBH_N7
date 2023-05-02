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
using QLBH_N7.Class;

namespace QLBH_N7
{
    public partial class frmNhaCungCap : Form
    {
        DataTable tblNCC;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView(); //Hiển thị bằng bảng Chất liệu
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MANCC, TENNCC , MAHANGCC FROM NHACUNGCAP";
            tblNCC = Function.GetDataToTable(sql);
            dgvNhaCungCap.DataSource = tblNCC; //Nguồn dữ liệu            
            dgvNhaCungCap.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNhaCungCap.Columns[2].HeaderText = "Mã hàng cung cấp";
            dgvNhaCungCap.Columns[0].Width = 100;
            dgvNhaCungCap.Columns[1].Width = 300;
            dgvNhaCungCap.Columns[2].Width = 200;
            dgvNhaCungCap.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0)//Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNCC.Text = dgvNhaCungCap.CurrentRow.Cells["MANCC"].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.CurrentRow.Cells["TENNCC"].Value.ToString();
            txtMaHang.Text = dgvNhaCungCap.CurrentRow.Cells["MAHANGCC"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xóa trắng dữ liệu
            txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }
        private void ResetValue()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtMaHang.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã Nhà Cung Cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
            if(txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return;
            }
            if(txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHang.Focus();
                return;
            }
            sql = "Select MANCC FROM NHACUNGCAP WHERE MANCC=N'" + txtMaNCC.Text.Trim() + "'";
            if (Function.ChecKey(sql))
            {
                MessageBox.Show("Mã Nhà Cung Cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }
            sql = "INSERT INTO NHACUNGCAP VALUES(N'" +
                txtMaNCC.Text + "',N'" + txtTenNCC.Text + "',N'" + txtMaHang.Text + "')";
            Function.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(txtMaNCC.Text == "")
            {
                MessageBox.Show("Không có bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên Nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NHACUNGCAP SET TENNCC = N'" + txtTenNCC.Text.ToString() + 
                "' WHERE MANCC=N'" + txtMaNCC.Text.ToString() + "'";
            sql = "UPDATE NHACUNGCAP SET MAHANGCC = N'" + txtMaHang.Text.ToString() +
                "' WHERE MANCC=N'" + txtMaNCC.Text.ToString() + "'";
            Function.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")//Nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NHACUNGCAP WHERE MANCC=N'" + txtMaNCC.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void txtMaNCC_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
