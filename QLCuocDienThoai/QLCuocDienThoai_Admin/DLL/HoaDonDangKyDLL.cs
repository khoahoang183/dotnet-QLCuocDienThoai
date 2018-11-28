using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLCuocDienThoai_Admin.DAL;
using QLCuocDienThoai_Admin.DTO;
namespace QLCuocDienThoai_Admin.DLL
{
    class HoaDonDangKyDLL
    {
        HoaDonDangKyDAL dal = new HoaDonDangKyDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable GetData_Combobox_MaSIM()
        {
            return dal.GetData_Combobox_MaSIM();
        }
        public bool AddData(HoaDonDangKy HoaDonDangKy)
        {
            return dal.AddData(HoaDonDangKy);
        }
        public bool UpdateData(HoaDonDangKy HoaDonDangKy)
        {
            return dal.UpdateData(HoaDonDangKy);
        }
        public bool DeleteData(int MAHDDK)
        {
            return dal.DeleteData(MAHDDK);
        }
        public DataTable SearchData(int MAHDDK)
        {
            return dal.SearchData(MAHDDK);
        }
        public DataTable Report_HDDK(int MAHDDK)
        {
            return dal.Report_HDDK(MAHDDK);
        }
    }
}
