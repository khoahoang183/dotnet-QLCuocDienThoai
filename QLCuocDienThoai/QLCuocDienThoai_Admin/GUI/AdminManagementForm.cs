using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class AdminManagementForm : Form
    {
        public AdminManagementForm()
        {
            InitializeComponent();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            QLKhachHangGUI form = new QLKhachHangGUI();
            form.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            QLDangKiSimGUI form = new QLDangKiSimGUI();
            form.Show();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminManagementForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(150, 50);
        }
    }
}
