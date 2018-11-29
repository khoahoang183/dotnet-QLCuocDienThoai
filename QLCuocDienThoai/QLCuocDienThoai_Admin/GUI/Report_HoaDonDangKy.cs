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
    public partial class Report_HoaDonDangKy : Form
    {
        public int MAHDDK; 
        public Report_HoaDonDangKy()
        {
            InitializeComponent();
        }

        private void Report_HoaDonDangKy_Load(object sender, EventArgs e)
        {
            string StrCon = @"Data Source=.;Initial Catalog=QLCUOCDIENTHOAI;Persist Security Info=True;User ID=sa;Password=123456";

            SqlConnection connect = new SqlConnection(StrCon);
            string sql = "Report_HoaDonDangKy @vMaHDDK";
            object para = "1";
            SqlCommand cmd = new SqlCommand(sql, connect);

            string[] listParament = sql.Split(' ');
            foreach (string item in listParament)
                if (item.Contains('@'))
                {
                    cmd.Parameters.AddWithValue(item, para);
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
