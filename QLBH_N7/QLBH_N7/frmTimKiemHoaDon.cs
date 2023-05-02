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
    public partial class frmTimKiemHoaDon : Form
    {
        DataTable tblHDB;
        public frmTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemHoaDon.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaNhanVien.Text == "") && (txtMaKhachHang.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM HOADONBAN WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MAHOADON Like N'%" + txtMaHDBan.Text + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(NGAYBAN) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(NGAYBAN) =" + txtNam.Text;
            if (txtMaNhanVien.Text != "")
                sql = sql + " AND MANV Like N'%" + txtMaNhanVien.Text + "%'";
            if (txtMaKhachHang.Text != "")
                sql = sql + " AND MAKH Like N'%" + txtMaKhachHang.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND TONGTIEN <=" + txtTongTien.Text;
            tblHDB = Function.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTimKiemHoaDon.DataSource = tblHDB;
                LoadDataGridView();
            }
        }
        private void LoadDataGridView()
        {
            dgvTimKiemHoaDon.Columns[0].HeaderText = "Mã HĐB";
            dgvTimKiemHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgvTimKiemHoaDon.Columns[2].HeaderText = "Ngày bán";
            dgvTimKiemHoaDon.Columns[3].HeaderText = "Mã khách";
            dgvTimKiemHoaDon.Columns[4].HeaderText = "Tổng tiền";
            dgvTimKiemHoaDon.Columns[0].Width = 150;
            dgvTimKiemHoaDon.Columns[1].Width = 100;
            dgvTimKiemHoaDon.Columns[2].Width = 80;
            dgvTimKiemHoaDon.Columns[3].Width = 80;
            dgvTimKiemHoaDon.Columns[4].Width = 80;
            dgvTimKiemHoaDon.AllowUserToAddRows = false;
            dgvTimKiemHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemHoaDon.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTimKiemHoaDon_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvTimKiemHoaDon.CurrentRow.Cells["MAHDBAN"].Value.ToString();
                frmTimKiemHoaDon frm = new frmTimKiemHoaDon();
                frm.txtMaHDBan.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
