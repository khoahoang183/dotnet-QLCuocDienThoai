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
            txtTenFile.Text = "D:\\LOG.txt";
            txtThang.Text = "10";
            txtNam.Text = "2018";
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

        }


    }
}
