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
    public partial class frmTimKiemHang : Form
    {
        DataTable TKH;
        public frmTimKiemHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimKiemHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemHang.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHang.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHang.Text == "") && (txtMaChatLieu.Text == "") && (txtTenHang.Text == "")) 
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HANG WHERE 1=1";
            if (txtMaHang.Text != "")
                sql = sql + " AND MAHANG Like N'%" + txtMaHang.Text + "%'";
            if (txtTenHang.Text != "")
                sql = sql + " AND TENHANG Like N'%" + txtTenHang.Text + "%'";
            if (txtMaChatLieu.Text != "")
                sql = sql + " AND MACL Like N'%" + txtMaChatLieu.Text + "%'";
            TKH = Function.GetDataToTable(sql);
            if (TKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + TKH.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiemHang.DataSource = TKH;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTimKiemHang.Columns[0].HeaderText = "Mã Hàng";
            dgvTimKiemHang.Columns[1].HeaderText = "Tên Hàng";
            dgvTimKiemHang.Columns[2].HeaderText = "Mã Chất Liệu";
            dgvTimKiemHang.Columns[0].Width = 150;
            dgvTimKiemHang.Columns[1].Width = 150;
            dgvTimKiemHang.Columns[2].Width = 100;
            dgvTimKiemHang.AllowUserToAddRows = false;
            dgvTimKiemHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTimKiemHang_DoubleClick(object sender, EventArgs e)
        {
            string mah;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mah = dgvTimKiemHang.CurrentRow.Cells["MAHANG"].Value.ToString();
                frmTimKiemHang frm = new frmTimKiemHang();
                frm.txtMaHang.Text = mah;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
