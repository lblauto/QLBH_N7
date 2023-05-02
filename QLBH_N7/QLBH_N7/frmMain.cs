using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH_N7.Class;

namespace QLBH_N7
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Function.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Function.DisConnect();
            Application.Exit();
        }

        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            frmChatLieu frmChatLieu = new frmChatLieu();
            frmChatLieu.MdiParent = this;
            frmChatLieu.Show();
        }

        private void mnuHienTroGiup_Click(object sender, EventArgs e)
        {
            frmTroGiup frmTroGiup = new frmTroGiup();
            frmTroGiup.MdiParent = this;
            frmTroGiup.Show();
        }

        private void mnuVaiNet_Click(object sender, EventArgs e)
        {
            frmVaiNet frmVaiNet = new frmVaiNet();
            frmVaiNet.MdiParent= this;
            frmVaiNet.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.MdiParent = this;
            frmNhanVien.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            frmKhachHang.MdiParent = this;
            frmKhachHang.Show();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmHangHoa frmHangHoa = new frmHangHoa();
            frmHangHoa.MdiParent = this;
            frmHangHoa.Show();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDonBan = new frmHoaDonBan();
            frmHoaDonBan.MdiParent = this;
            frmHoaDonBan.Show();
        }

        private void mnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon frmTimKiemHoaDon = new frmTimKiemHoaDon();
            frmTimKiemHoaDon.MdiParent = this;
            frmTimKiemHoaDon.Show();
        }

        private void mnuHang_Click(object sender, EventArgs e)
        {
            frmTimKiemHang frmTimKiemHang = new frmTimKiemHang();
            frmTimKiemHang.MdiParent = this;
            frmTimKiemHang.Show();
        }

        private void mnuTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            frmTimKiemKhachHang frmTimKiemKhachHang = new frmTimKiemKhachHang();
            frmTimKiemKhachHang.MdiParent = this;
            frmTimKiemKhachHang.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frmNhaCungCap = new frmNhaCungCap();
            frmNhaCungCap.MdiParent = this;
            frmNhaCungCap.Show();
        }
    }
}
