using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuocDienThoai_Admin.GUI
{
    public partial class Form_Report_HoaDonDangKy : Form
    {
        public int MAHDDK; // chua truyen qua sao no hieu lul
        public Form_Report_HoaDonDangKy()
        {
            InitializeComponent();
        }

        private void Form_Report_HoaDonDangKy_Load(object sender, EventArgs e)
        {
            //ReportParameter para = new ReportParameter(); 
            // para = new ReportParameter("vMaHDDK", "1");
            //this.reportViewer1.LocalReport.SetParameters(para);


            string StrCon = @"Data Source=.;Initial Catalog=QLCUOCDIENTHOAI;Persist Security Info=True;User ID=sa;Password=123456";

            SqlConnection connect = new SqlConnection(StrCon);
            string sql = "Report_HoaDonDangKy @vMaHDDK";
            object para = "1";   // ma hoa don
            SqlCommand cmd = new SqlCommand(sql, connect);

            string[] listParament = sql.Split(' ');
            if (listParament[1].Contains('@'))
            {
                cmd.Parameters.AddWithValue(listParament[1], para);
            }


            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Report_HoaDonDangKy";
            reportDataSource.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
