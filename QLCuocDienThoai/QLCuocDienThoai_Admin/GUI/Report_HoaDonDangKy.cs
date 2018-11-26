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
    public partial class Report_HoaDonDangKy : Form
    {
        public Report_HoaDonDangKy()
        {
            InitializeComponent();
        }

        private void Report_HoaDonDangKy_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
