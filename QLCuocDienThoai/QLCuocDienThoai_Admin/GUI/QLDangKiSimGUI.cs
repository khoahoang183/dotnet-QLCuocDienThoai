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
using System.Data;
using System.Drawing;

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class QLDangKiSimGUI : Form
    {
        ThongTinSimDLL simdll = new ThongTinSimDLL();
        ThongTinSim sim = new ThongTinSim();

        HoaDonDangKyDLL hoadondll = new HoaDonDangKyDLL();
        HoaDonDangKy hoadon = new HoaDonDangKy();

        int flag = 0; // 1 la them, 2 la sua, 3 la khoa
        int flag1 = 0; // 1 la them, 2 la sua, 3 la khoa
        public QLDangKiSimGUI()
        {
            InitializeComponent();
        }

        private void QLDangKiSimGUI_Load(object sender, EventArgs e)
        {
            this.Location = new Point(150, 50);
            // load danhsach
            DataTable simtable = new DataTable();
            simtable = simdll.GetData();
            dgvTable.DataSource = simtable;
            dgvTable.AutoResizeColumns();
            dgvTable.Columns[1].Width = 157;
            dgvTable.Columns[2].Width = 156;
            dgvTable.Columns[3].Width = 156;

            DataTable hoadontable = new DataTable();
            hoadontable = hoadondll.GetData();
            dgvTable1.DataSource = hoadontable;
            dgvTable1.AutoResizeColumns();
            dgvTable1.Columns[1].Width = 155;
            dgvTable1.Columns[2].Width = 151;
            dgvTable1.Columns[3].Width = 151;

            Combobox_Load();
            BingDing();
            BingDing1();

            DisableTextBox(false);
            DisableTextBox1(false);
        }
        void Combobox_Load()
        {
            DataTable combobox_MAKH = new DataTable();
            combobox_MAKH = simdll.GetData_Combobox_MaKH();
            cbxMaKH.DataSource = combobox_MAKH;
            cbxMaKH.ValueMember = "MAKH";

            DataTable combobox_MASIM = new DataTable();
            combobox_MASIM = hoadondll.GetData_Combobox_MaSIM();
            cbxMaSIM.DataSource = combobox_MASIM;
            cbxMaSIM.ValueMember = "MASIM";
        }
        void DisableTextBox(bool res)
        {
            txtMASIM.Enabled = res;
            txtSODT.Enabled = res;
            cbxMaKH.Enabled = res;
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
            txtMASIM.Clear();
            txtSODT.Clear();
            txtTINHTRANG.Clear();
        }
        void BingDing()    // load du hieu qua cac text
        {
            txtMASIM.DataBindings.Clear();
            txtMASIM.DataBindings.Add("Text", dgvTable.DataSource, "MASIM");
            txtSODT.DataBindings.Clear();
            txtSODT.DataBindings.Add("Text", dgvTable.DataSource, "SODT");
            cbxMaKH.DataBindings.Clear();
            cbxMaKH.DataBindings.Add("Text", dgvTable.DataSource, "MAKH");
            txtTINHTRANG.DataBindings.Clear();
            txtTINHTRANG.DataBindings.Add("Text", dgvTable.DataSource, "TINHTRANG");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            DisableTextBox(true);
            ClearData();
            txtMASIM.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            DisableTextBox(true);
            txtMASIM.Enabled = false;
            //txtSODT.Text = null;
            //cbxMaKH.Text = null;
            txtTINHTRANG.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            flag = 3;
            DisableTextBox(true);
            txtMASIM.Enabled = false;
            txtSODT.Enabled = false;
            cbxMaKH.Enabled = false;
            txtTINHTRANG.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag != 1) // them ko can ma
            {
                sim.SetMASIM(Int32.Parse(txtMASIM.Text.Trim()));
            }
            sim.SetSODT(txtSODT.Text.Trim());
            sim.SetMAKH(Int32.Parse(cbxMaKH.Text.Trim()));
            sim.SetTINHTRANG(Int32.Parse(txtTINHTRANG.Text.Trim()));

            if (flag == 1) // them 
            {
                if (simdll.AddData(sim) == true)
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
                if (simdll.UpdateData(sim) == true)
                {
                    MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (flag == 3)
            {
                if (simdll.LockData(sim.GetMASIM(), sim.GetTINHTRANG()) == true)
                {
                    MessageBox.Show("Đổi Tình Trạng Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đổi Tình Trạng Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            flag = 0;
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int TimKiem = Int32.Parse(txtTimKiem.Text.Trim());

            DataTable simdata = new DataTable();
            simdata = simdll.SearchData(TimKiem);
            dgvTable.DataSource = simdata;
            dgvTable.AutoResizeColumns();
            dgvTable.Columns[1].Width = 157;
            dgvTable.Columns[2].Width = 156;
            dgvTable.Columns[3].Width = 156;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnMaKH_Click(object sender, EventArgs e)
        {
            QLKhachHangGUI form = new QLKhachHangGUI();
            form.Show();
        }


        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        void DisableTextBox1(bool res)
        {
            txtMaHD.Enabled = res;
            cbxMaSIM.Enabled = res;
            txtPhiDangKy.Enabled = res;
            dtpNgayDangKy.Enabled = res;

            // button
            btnThem1.Enabled = !res;
            btnSua1.Enabled = !res;
            btnXoa1.Enabled = !res;
            btnLuu1.Enabled = res;
            btnHuy1.Enabled = res;
        }
        void ClearData1()
        {
            txtMaHD.Clear();
            txtPhiDangKy.Clear();
        }
        void BingDing1()    // load du hieu qua cac text
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dgvTable1.DataSource, "MAHDDK");
            cbxMaSIM.DataBindings.Clear();
            cbxMaSIM.DataBindings.Add("Text", dgvTable1.DataSource, "MASIM");
            txtPhiDangKy.DataBindings.Clear();
            txtPhiDangKy.DataBindings.Add("Text", dgvTable1.DataSource, "PHIDANGKI");
            dtpNgayDangKy.DataBindings.Clear();
            dtpNgayDangKy.DataBindings.Add("Text", dgvTable1.DataSource, "NGAYDANGKI");
        }
        private void btnThem1_Click(object sender, EventArgs e)
        {
            flag1 = 1;
            DisableTextBox1(true);
            ClearData();
            txtMaHD.Enabled = false;
            txtMaHD.Clear();
            txtPhiDangKy.Text = "50000";
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            flag1 = 2;
            DisableTextBox1(true);
            txtMaHD.Enabled = false;
            dtpNgayDangKy.Enabled = false;  
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            flag = 3;
            DisableTextBox1(true);
            txtMaHD.Enabled = false;
            cbxMaSIM.Enabled = false;
            txtPhiDangKy.Enabled = false;
            dtpNgayDangKy.Enabled = false;

            if (flag1 != 1) // them ko can ma
            {
                hoadon.SetMAHDDK(Int32.Parse(txtMaHD.Text.Trim()));
            }
            hoadon.SetMASIM(Int32.Parse(cbxMaSIM.Text.Trim()));
            hoadon.SetPHIDANGKI(Double.Parse(txtPhiDangKy.Text.Trim()));
            hoadon.SetNGAYDANGKI(Convert.ToDateTime(dtpNgayDangKy.Text));

            DialogResult dialog = MessageBox.Show("Bạn đã chắc chắn muốn xóa?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                if (hoadondll.DeleteData(hoadon.GetMAHDDK()) == true)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLDangKiSimGUI_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            if (flag1 != 1) // them ko can ma
            {
                hoadon.SetMAHDDK(Int32.Parse(txtMaHD.Text.Trim()));
            }
            hoadon.SetMASIM(Int32.Parse(cbxMaSIM.Text.Trim()));
            hoadon.SetPHIDANGKI(Double.Parse(txtPhiDangKy.Text.Trim()));
            hoadon.SetNGAYDANGKI(Convert.ToDateTime(dtpNgayDangKy.Text));

            if (flag1 == 1) // them 
            {
                if (hoadondll.AddData(hoadon) == true)
                {
                    MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (flag1 == 2) // sua 
            {
                if (hoadondll.UpdateData(hoadon) == true)
                {
                    MessageBox.Show("Sửa Hóa Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa Hóa Đơn Thất Bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            flag = 0;
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnTimKiem1_Click(object sender, EventArgs e)
        {
            int TimKiem = Int32.Parse(txtTimKiem1.Text.Trim());

            DataTable hoadondata = new DataTable();
            hoadondata = hoadondll.SearchData(TimKiem);
            dgvTable1.DataSource = hoadondata;
            dgvTable1.AutoResizeColumns();
            dgvTable1.Columns[1].Width = 155;
            dgvTable1.Columns[2].Width = 151;
            dgvTable1.Columns[3].Width = 151;
        }

        private void btnLamMoi1_Click(object sender, EventArgs e)
        {
            QLDangKiSimGUI_Load(sender, e);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            String MaHD_From_Text = txtMaHD.Text;
            if (MaHD_From_Text == "") // khong du thong tin
            {
                MessageBox.Show("Chọn Hóa đơn cần in!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Report_HoaDonDangKy a = new Report_HoaDonDangKy();
                a.MAHDDK = Int32.Parse(txtMaHD.Text);
                a.ShowDialog();
            }
        }
    }
}
