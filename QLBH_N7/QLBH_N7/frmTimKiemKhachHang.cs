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
    public partial class frmTimKiemKhachHang : Form
    {
        DataTable TKKH;
        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void frmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemKachHang.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaKhachHang.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaKhachHang.Text == "") && (txtTenKhachHang.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM KHACHHANG WHERE 1=1";
            if (txtMaKhachHang.Text != "")
                sql = sql + " AND MAKH Like N'%" + txtMaKhachHang.Text + "%'";
            if (txtTenKhachHang.Text != "")
                sql = sql + " AND TENKH Like N'%" + txtTenKhachHang.Text + "%'";
            TKKH = Function.GetDataToTable(sql);
            if (TKKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có khách hàng nào được tìm thấy!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + TKKH.Rows.Count + " khách hàng được tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiemKachHang.DataSource = TKKH;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTimKiemKachHang.Columns[0].HeaderText = "Mã HĐB";
            dgvTimKiemKachHang.Columns[1].HeaderText = "Mã nhân viên";
            dgvTimKiemKachHang.Columns[0].Width = 100;
            dgvTimKiemKachHang.Columns[1].Width = 150;
            dgvTimKiemKachHang.AllowUserToAddRows = false;
            dgvTimKiemKachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemKachHang.DataSource = null;
        }

        private void dgvTimKiemKachHang_DoubleClick(object sender, EventArgs e)
        {
            string makh;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                makh = dgvTimKiemKachHang.CurrentRow.Cells["MaHDBan"].Value.ToString();
                frmTimKiemKhachHang frm = new frmTimKiemKhachHang();
                frm.txtMaKhachHang.Text = makh;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
