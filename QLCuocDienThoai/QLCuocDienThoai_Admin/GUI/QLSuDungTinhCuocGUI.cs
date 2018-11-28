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
    public partial class QLSuDungTinhCuocGUI : Form
    {
        public QLSuDungTinhCuocGUI()
        {
            InitializeComponent();
        }

        private void QLSuDungTinhCuocGUI_Load(object sender, EventArgs e)
        {

        }

        private void txtPhatSinh_Click(object sender, EventArgs e)
        {
            int Thang = Int32.Parse(txtThang.Text.Trim());
            int Nam = Int32.Parse(txtNam.Text.Trim());
            string tenfile = txtTenFile.Text.Trim();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            fileDialog.FileName = tenfile;

            FileStream stream = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8);

            streamWriter.WriteLine("khoa dep trai");
            streamWriter.Flush();
            stream.Close();
        }
    }
}
