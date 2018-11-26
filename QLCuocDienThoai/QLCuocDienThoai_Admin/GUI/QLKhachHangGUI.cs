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
        int flag = 0; // 1 la them, 2 la sua, 3 la khoa

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
            DisableTextBox(false);

        }
        void DisableTextBox(bool res)
        {
            txtMAKH.Enabled = res;
            txtTEN.Enabled = res;
            txtTHONGTIN.Enabled = res;
            txtTINHTRANG.Enabled = res;

            // button
            btnThem.Enabled = !res;
            btnSua.Enabled = !res;
            btnXoa.Enabled = !res;
            btnLuu.Enabled = res;
            btnHuy.Enabled = res;
        }
        void ClearData()
        {
            txtMAKH.Clear();
            txtTEN.Clear();
            txtTHONGTIN.Clear();
            txtTINHTRANG.Clear();
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
            flag = 1;
            DisableTextBox(true);
            ClearData();
            txtMAKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            DisableTextBox(true);
            txtMAKH.Enabled = false;
            txtTEN.Text = null;
            txtTHONGTIN.Text = null;
            txtTINHTRANG.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            flag = 3;
            DisableTextBox(true);
            txtMAKH.Enabled = false;
            txtTEN.Enabled = false;
            txtTHONGTIN.Enabled = false;
            txtTINHTRANG.Enabled = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag !=1) // them ko can ma
            {
                khachhang.SetMAKH(Int32.Parse(txtMAKH.Text.Trim()));
            }
            khachhang.SetTEN(txtTEN.Text.Trim());
            khachhang.SetTHONGTIN(txtTHONGTIN.Text.Trim());
            khachhang.SetTINHTRANG(Int32.Parse(txtTINHTRANG.Text.Trim()));

            if (flag == 1) // them 
            {                
                if (khachhangdll.AddData(khachhang) == true)
                {
                    MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (flag == 2) // sua 
            {
                if (khachhangdll.UpdateData(khachhang) == true)
                {
                    MessageBox.Show("Sửa Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Hóa Đơn Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (flag==3)
            {
                if (khachhangdll.LockData(khachhang.GetMAKH(), khachhang.GetTINHTRANG()) == true)
                {
                    MessageBox.Show("Đổi Tình Trạng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đổi Tình Trạng Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            flag = 0;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QLKhachHangGUI_Load(sender, e);
        }


    }
}
