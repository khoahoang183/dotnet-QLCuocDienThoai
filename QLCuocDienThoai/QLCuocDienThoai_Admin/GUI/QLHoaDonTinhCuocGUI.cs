using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO;
using QLCuocDienThoai_Admin.DTO;
using QLCuocDienThoai_Admin.DLL;
using System.Text.RegularExpressions;
using QLCuocDienThoai_Admin.DAL;

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class QLHoaDonTinhCuocGUI : Form
    {
        HoaDonTinhCuocDLL hoadondll = new HoaDonTinhCuocDLL();
        HoaDonTinhCuoc hoadon = new HoaDonTinhCuoc();
        public QLHoaDonTinhCuocGUI()
        {
            InitializeComponent();
        }

        private void QLHoaDonTinhCuocGUI_Load(object sender, EventArgs e)
        {
           
            txtPhiHangThang.Text = "50000";
            this.Location = new Point(150, 50);

            txtMASIM.Enabled = false;
            txtMAKH.Enabled = false;
            txtNgay.Enabled = false;
            txtThang.Enabled = false;
            txtNam.Enabled = false;
            txtCuocPhi.Enabled = false;

            txtMaHDTC.Enabled = false;
            txtMASIM2.Enabled = false;
            txtNam2.Enabled = false;
            txtTongTien.Enabled = false;
            txtThanhToan.Enabled = false;
           



            DataTable dataTable1 = new DataTable();
            dataTable1 = hoadondll.GetData();
            dgvTable.DataSource = dataTable1;
            dgvTable.AutoResizeColumns();

            int PhiHangThang = Int32.Parse(txtPhiHangThang.Text);
            DataTable dataTable2 = new DataTable();
            dataTable2 = hoadondll.GetData_CapNhat(PhiHangThang);
            dgvTable2.DataSource = dataTable2;
            dgvTable2.AutoResizeColumns();

            BingDing();
            
        }

        void BingDing()    // load du hieu qua cac text
        {
            txtMASIM.DataBindings.Clear();
            txtMASIM.DataBindings.Add("Text", dgvTable2.DataSource, "MASIM");
            txtMAKH.DataBindings.Clear();
            txtMAKH.DataBindings.Add("Text", dgvTable2.DataSource, "MAKH");
            txtCuocPhi.DataBindings.Clear();
            txtCuocPhi.DataBindings.Add("Text", dgvTable2.DataSource, "CUOCPHI");
            txtNgay.DataBindings.Clear();
            txtNgay.DataBindings.Add("Text", dgvTable2.DataSource, "NGAYDANGKY");
            txtThang.DataBindings.Clear();
            txtThang.DataBindings.Add("Text", dgvTable2.DataSource, "THANG");
            txtNam.DataBindings.Clear();
            txtNam.DataBindings.Add("Text", dgvTable2.DataSource, "NAM");
        }
        void BingDing2()
        {
            txtMaHDTC.DataBindings.Clear();
            txtMaHDTC.DataBindings.Add("Text", dgvTable.DataSource, "MAHDTC");
            txtMASIM2.DataBindings.Clear();
            txtMASIM2.DataBindings.Add("Text", dgvTable.DataSource, "MASIM");
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", dgvTable.DataSource, "TONGTIEN");
            txtThanhToan.DataBindings.Clear();
            txtThanhToan.DataBindings.Add("Text", dgvTable.DataSource, "THANHTOAN");
            abc.DataBindings.Clear();
            abc.DataBindings.Add("Text", dgvTable.DataSource, "THANG");
            txtNam2.DataBindings.Clear();
            txtNam2.DataBindings.Add("Text", dgvTable.DataSource, "NAM");
        }

    private void button6_Click(object sender, EventArgs e)
        {
            int PhiHangThang = Int32.Parse(txtPhiHangThang.Text);
            DataTable dataTable2 = new DataTable();
            dataTable2 = hoadondll.GetData_CapNhat(PhiHangThang);
            dgvTable2.DataSource = dataTable2;
            dgvTable2.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLHoaDonTinhCuocGUI_Load(sender,e);
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLHoaDonTinhCuocGUI_Load(sender, e);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {   
            try
            { 
            DialogResult dialog = MessageBox.Show("Bạn đã chắc chắn muốn lưu?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvTable2.Rows.Count; i++)
                    {
                        HoaDonTinhCuoc hd = new HoaDonTinhCuoc();
                        hd.SetMASIM(Convert.ToInt32(dgvTable2.Rows[i].Cells[0].Value));
                        hd.SetTONGTIEN(Convert.ToDouble(dgvTable2.Rows[i].Cells[2].Value));
                        hd.SetTHANG(Convert.ToInt32(dgvTable2.Rows[i].Cells[4].Value));
                        hd.SetNAM(Convert.ToInt32(dgvTable2.Rows[i].Cells[5].Value));
                        int ngay = Convert.ToInt32(dgvTable2.Rows[i].Cells[3].Value);
                        DateTime b = new DateTime(hd.GetNAM(), hd.GetTHANG(), ngay, 0, 0, 0);
                        TimeSpan songay = new TimeSpan();
                        songay = DateTime.Today - b;

                        if (songay.TotalDays < 30)
                            hd.SetTHANHTOAN(1);
                        else if (songay.TotalDays >= 30 && songay.TotalDays < 33)
                            hd.SetTHANHTOAN(2);
                        else if (songay.TotalDays >= 33)
                            hd.SetTHANHTOAN(3);
                        hoadondll.AddData(hd);

                    }
                    
                }
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                
            }

            QLHoaDonTinhCuocGUI_Load(sender, e);
        }
    }
}
