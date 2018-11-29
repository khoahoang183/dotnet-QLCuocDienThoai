using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLCuocDienThoai_Admin.DTO;
using QLCuocDienThoai_Admin.DLL;
using System.Text.RegularExpressions;


namespace QLCuocDienThoai_Admin.GUI
{   
    public partial class QLChiTietSuDungGUI : Form
    {
        
        ChiTietSuDungDLL chitietdll = new ChiTietSuDungDLL();

        public QLChiTietSuDungGUI()
        {
            InitializeComponent();
        }

        private void QLChiTietSuDungGUI_Load(object sender, EventArgs e)
        {   
            this.Location = new Point(150, 50);
            DataTable chitiettable = new DataTable();
            chitiettable = chitietdll.GetData();
            dgvTable.DataSource = chitiettable;
            
            dgvTable.Columns[0].HeaderText = "Mã Sim";
            dgvTable.Columns[1].HeaderText = "Thời Gian Bắt Đầu";
            dgvTable.Columns[2].HeaderText = "Thời Gian Kết Thúc";
            dgvTable.Columns[3].HeaderText = "Số phút sau 23h";
            dgvTable.Columns[4].HeaderText = "Số phút sau 7h";
            dgvTable.Columns[5].HeaderText = "Cước phí";
            dgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            txtTenFile.Text = "D:\\LOG.txt";
            txtThang.Text = "10";
            txtNam.Text = "2018";
            Luubtn.Enabled = false;
        }

        private void txtPhatSinh_Click(object sender, EventArgs e)
        {
            // lay du lieu tu texxtbox
            int nam = Int32.Parse(txtNam.Text.Trim());
            int thang = Int32.Parse(txtThang.Text.Trim());
            string tenfile = txtTenFile.Text.Trim();
            Random rd = new Random();// de random so
            int soluongSIM = chitietdll.CountSIM();// so luong sim
            //mo file     
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = tenfile;
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);
            //ghi file
            for (int i=0; i< rd.Next(50); i++)
            {
                // random thong tin
                int ngay = rd.Next(1, 29);
                int giobatdau = rd.Next(0, 23);
                int phutbatdau = rd.Next(1, 59);
                int phutgoi = rd.Next(1, 1000);
                // random sim + 2 moc thoi gian
                int masim = rd.Next(1, soluongSIM);
                DateTime ngaybatdau = new DateTime(nam, thang, ngay, giobatdau, phutbatdau, 0);
                DateTime ngayketthuc = ngaybatdau.AddMinutes(phutgoi); 
                // in vao file
                streamWriter.WriteLine(masim + "  " + ngaybatdau + "   " + ngayketthuc);
                streamWriter.Flush();
            }
            fs.Close();
            MessageBox.Show("Phát Sinh File Log hoàn tất!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            dgvTable.DataSource = null;
            dgvTable.Refresh();
           
           
           
            StreamReader sr = new StreamReader(txtTenFile.Text.Trim());
            string s = "";
            int countline = File.ReadLines(txtTenFile.Text.Trim()).Count();
            string[,] a = new string[countline, 6];
            int i = 0;

            while ((s = sr.ReadLine()) != null)
            {
                s = Regex.Replace(s, @"\s+", " ");

                string[] content = s.Trim().Split(' ');
                int m = 0;
                for (int j = 0; j < content.Length; j++)
                { if (j == 1 || j == 4)
                    {

                        a[i, m] = (content[j] + " " + content[j + 1] + " " + content[j + 2]);
                        j = j + 2;
                        m++;
                    }
                    else
                    {
                        a[i, j] = (content[j]);
                        m++;
                    }
                }

                i++;
            }
            dgvTable.ColumnCount = a.GetLength(1);
            dgvTable.Columns[0].HeaderText = "Mã Sim";
            dgvTable.Columns[1].HeaderText = "Thời Gian Bắt Đầu";
            dgvTable.Columns[2].HeaderText = "Thời Gian Kết Thúc";
            dgvTable.Columns[3].HeaderText = "Số phút sau 23h";
            dgvTable.Columns[4].HeaderText = "Số phút sau 7h";
            dgvTable.Columns[5].HeaderText = "Cước phí";
            dgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            for (int b = 1;b<a.GetLength(0);b++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvTable);
                for (int c = 0; c < a.GetLength(1); c++)
                {
                    row.Cells[c].Value = a[b, c];
                }
                dgvTable.Rows.Add(row);
            }
            for (int p = 0; p < dgvTable.RowCount; p++)
            {
                DateTime batdau = Convert.ToDateTime(dgvTable.Rows[p].Cells[1].Value);
                DateTime ketthuc = Convert.ToDateTime(dgvTable.Rows[p].Cells[2].Value);
                TimeSpan sophut = ketthuc - batdau;
                double cuocphi = 0;
                double sophutsau7h = 0;
                double sophutsau23h = 0;

                if (batdau.Hour >= 7 && ketthuc.Hour < 23 && batdau.Day == ketthuc.Day)
                {
                    cuocphi = sophut.TotalMinutes * 200;
                     sophutsau7h = sophut.TotalMinutes;
                     sophutsau23h = 0;
                }
                else if ((batdau.Hour >= 23 && ketthuc.Hour < 7 && batdau.Day == ketthuc.Day + 1) || (batdau.Hour >= 23 && ketthuc.Hour < 24 && batdau.Day == ketthuc.Day) || (batdau.Hour >=0 && ketthuc.Hour <7 && batdau.Day==ketthuc.Day))
                {
                    cuocphi = sophut.TotalMinutes * 150;
                     sophutsau23h = sophut.TotalMinutes;
                     sophutsau7h = 0;
                }
                else if ((batdau.Hour <7 && ketthuc.Hour >=7 && batdau.Day==ketthuc.Day && ketthuc.Hour<23) || (batdau.Hour >=23 && ketthuc.Hour >=7 && batdau.Day==ketthuc.Day+1 && ketthuc.Hour <23))
                {
                    DateTime bayh = new DateTime(batdau.Year, batdau.Month, ketthuc.Day, 7, 0, 0);
                    TimeSpan sau23h = bayh - batdau;
                    sophutsau23h = sau23h.TotalMinutes;
                    sophutsau7h = sophut.TotalMinutes - sophutsau23h;
                    cuocphi = sophutsau23h * 150 + sophutsau7h * 200;
                    
                }
                else if ((batdau.Hour >=7 && ketthuc.Hour >=23 && batdau.Day == ketthuc.Day) || (batdau.Hour >=7 && ketthuc.Hour <7 &&batdau.Day== ketthuc.Day+1 && batdau.Hour <23))
            {
                DateTime bayh = new DateTime(batdau.Year, batdau.Month, batdau.Day, 7, 0, 0);
                    TimeSpan sau7h = batdau - bayh;
                    sophutsau7h = sau7h.TotalMinutes;
                    sophutsau23h = sophut.TotalMinutes - sophutsau7h;
                    cuocphi = sophutsau23h * 150 + sophutsau7h * 200;
                }
                else if ((batdau.Hour >= 7 && batdau.Hour<23 && batdau.Day < ketthuc.Day))
                {
                    DateTime bayhbatdau = new DateTime(batdau.Year, batdau.Month, batdau.Day, 7, 0, 0);
                    DateTime bayhketthuc = new DateTime(batdau.Year, batdau.Month, ketthuc.Day, 7, 0, 0);

                    TimeSpan sau7h = batdau - bayhbatdau + (ketthuc - bayhketthuc);
                    sophutsau7h = sau7h.TotalMinutes + (Math.Floor((sophut.TotalDays)) * 960);
                    sophutsau23h = (Math.Ceiling((sophut.TotalDays)) * 480);
                    cuocphi = sophutsau23h * 150 + sophutsau7h * 200;
                }
                
                dgvTable.Rows[p].Cells[3].Value = sophutsau7h;
                dgvTable.Rows[p].Cells[4].Value = sophutsau23h;
                dgvTable.Rows[p].Cells[5].Value = cuocphi;

            }

            sr.Close();
            Luubtn.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DataTable chitiettable = new DataTable();
            chitiettable = chitietdll.GetData();
            dgvTable.DataSource = chitiettable;

            dgvTable.Columns[0].HeaderText = "Mã Sim";
            dgvTable.Columns[1].HeaderText = "Thời Gian Bắt Đầu";
            dgvTable.Columns[2].HeaderText = "Thời Gian Kết Thúc";
            dgvTable.Columns[3].HeaderText = "Số phút sau 23h";
            dgvTable.Columns[4].HeaderText = "Số phút sau 7h";
            dgvTable.Columns[5].HeaderText = "Cước phí";
            dgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void Luubtn_Click(object sender, EventArgs e)
        {   
            for(int i = 0; i<dgvTable.Rows.Count;i++)
            {
                ChiTietSuDung chitiet = new ChiTietSuDung();
                chitiet.SetMASIM(Convert.ToInt32(dgvTable.Rows[i].Cells[0].Value));
                chitiet.SetBATDAU(Convert.ToDateTime(dgvTable.Rows[i].Cells[1].Value));
                chitiet.SetKETTHUC(Convert.ToDateTime(dgvTable.Rows[i].Cells[2].Value));
                chitiet.SetSOPHUTSUDUNGSAU23H(Convert.ToInt32(dgvTable.Rows[i].Cells[3].Value));
                chitiet.SetSOPHUTSUDUNGSAU7H(Convert.ToInt32(dgvTable.Rows[i].Cells[4].Value));
                chitiet.SetCUOCPHI(Convert.ToInt32(dgvTable.Rows[i].Cells[5].Value));
                chitietdll.AddData(chitiet);
            }
            dgvTable.Rows.Clear();
            dgvTable.Columns.Clear();
            dgvTable.Refresh();
            btnLamMoi_Click(sender,e);
            Luubtn.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable chitiettable = new DataTable();
            chitiettable = chitietdll.SearchData(Convert.ToInt32(txtTimKiem.Text));
            dgvTable.DataSource = chitiettable;
            dgvTable.Columns[0].HeaderText = "Mã Sim";
            dgvTable.Columns[1].HeaderText = "Thời Gian Bắt Đầu";
            dgvTable.Columns[2].HeaderText = "Thời Gian Kết Thúc";
            dgvTable.Columns[3].HeaderText = "Số phút sau 23h";
            dgvTable.Columns[4].HeaderText = "Số phút sau 7h";
            dgvTable.Columns[5].HeaderText = "Cước phí";
            dgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTable.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
