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
    public partial class KH : Form
    {
        public KH()
        {
            InitializeComponent();
        }

        private void KH_Load_1(object sender, EventArgs e)
        {
            Function.Connect();
        }

        private void tậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmTimKiemHang frmTimKiemHang = new frmTimKiemHang();
           frmTimKiemHang.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon frmTimKiemHoaDon = new frmTimKiemHoaDon();
            frmTimKiemHoaDon.Show();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroGiup frmTroGiup = new frmTroGiup();
            frmTroGiup.Show();
        }

        private void vàiNétToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVaiNet frmVaiNet = new frmVaiNet();
            frmVaiNet.Show();
        }
    }
}
