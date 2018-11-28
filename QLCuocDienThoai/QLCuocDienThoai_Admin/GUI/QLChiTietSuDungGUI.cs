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

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class QLChiTietSuDungGUI : Form
    {
        public QLChiTietSuDungGUI()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtTenFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {

        }
        private void QLChiTietSuDungGUI_Load(object sender, EventArgs e)
        {
            txtThang.Text = "10";
            txtNam.Text = "2018";
        }

        private void txtPhatSinh_Click(object sender, EventArgs e)
        {
            int nam = Int32.Parse(txtNam.Text.Trim());
            int thang = Int32.Parse(txtThang.Text.Trim());
            string tenfile = txtTenFile.Text.Trim();
            Random rd = new Random();

            //mo file
            tenfile = "E:\\test.txt";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = tenfile;
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.UTF8);

            //ghi file
            for (int i=0; i< 30; i++)
            {
                int masim = i;
                int ngay = rd.Next(1, 29);
                int gio = rd.Next(0, 23);
                int phutbatdau = rd.Next(1, 59);
                int phutgoi = rd.Next(1, 1000);

                DateTime ngaybatdau = new DateTime(nam, thang, ngay, gio, phutbatdau, 0);
                DateTime ngayketthuc = ngaybatdau;
                ngayketthuc.AddMinutes(phutgoi);
                streamWriter.WriteLine(masim + "  " + ngaybatdau + "   " + ngayketthuc);
                streamWriter.Flush();
            }
            fs.Close();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {

        }


    }
}
