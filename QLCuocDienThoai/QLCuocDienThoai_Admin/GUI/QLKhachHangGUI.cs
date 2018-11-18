using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCuocDienThoai_Admin.DTO;
using QLCuocDienThoai_Admin.DLL;

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class QLKhachHangGUI : Form
    {
        KhachHangDLL khachhangdll = new KhachHangDLL();
        KhachHang khachhang = new KhachHang();

        public QLKhachHangGUI()
        {
            InitializeComponent();
        }

        private void QLKhachHangGUI_Load(object sender, EventArgs e)
        {
            this.Location = new Point(150, 50);
            // load danhsach
            DataTable khachhangtable = new DataTable();
            khachhangtable = khachhangdll.GetData();
            dgvTable.DataSource = khachhangtable;
            dgvTable.AutoResizeColumns();
            dgvTable.Columns[1].Width = 158;
            dgvTable.Columns[2].Width = 158;
            dgvTable.Columns[3].Width = 158;

            BingDing();
        }
        void BingDing()    // load du hieu qua cac text
        {
            txtMAKH.DataBindings.Clear();
            txtMAKH.DataBindings.Add("Text", dgvTable.DataSource, "MAKH");
            txtTEN.DataBindings.Clear();
            txtTEN.DataBindings.Add("Text", dgvTable.DataSource, "TEN");
            txtTHONGTIN.DataBindings.Clear();
            txtTHONGTIN.DataBindings.Add("Text", dgvTable.DataSource, "THONGTIN");
            txtTINHTRANG.DataBindings.Clear();
            txtTINHTRANG.DataBindings.Add("Text", dgvTable.DataSource, "TINHTRANG");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            khachhang.SetMAKH(Int32.Parse(txtMAKH.Text.Trim()));
            khachhang.SetTEN(txtTEN.Text.Trim());
            khachhang.SetTHONGTIN(txtTHONGTIN.Text.Trim());
            khachhang.SetTINHTRANG(Int32.Parse(txtTINHTRANG.Text.Trim()));
            khachhangdll.AddData(khachhang);
            QLKhachHangGUI_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            khachhang.SetMAKH(Int32.Parse(txtMAKH.Text.Trim()));
            khachhang.SetTEN(txtTEN.Text.Trim());
            khachhang.SetTHONGTIN(txtTHONGTIN.Text.Trim());
            khachhang.SetTINHTRANG(Int32.Parse(txtTINHTRANG.Text.Trim()));
            khachhangdll.UpdateData(khachhang);
            QLKhachHangGUI_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            khachhang.SetMAKH(Int32.Parse(txtMAKH.Text.Trim()));
            khachhang.SetTINHTRANG(Int32.Parse(txtTINHTRANG.Text.Trim()));
            khachhangdll.LockData(khachhang.GetMAKH(), khachhang.GetTINHTRANG());
            QLKhachHangGUI_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int TimKiem = Int32.Parse(txtTimKiem.Text.Trim());

            DataTable khachhangtable = new DataTable();
            khachhangtable = khachhangdll.SearchData(TimKiem);
            dgvTable.DataSource = khachhangtable;
            dgvTable.AutoResizeColumns();
            dgvTable.Columns[1].Width = 158;
            dgvTable.Columns[2].Width = 158;
            dgvTable.Columns[3].Width = 158;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QLKhachHangGUI_Load(sender, e);
        }
    }
}
