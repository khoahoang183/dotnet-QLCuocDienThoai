using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLCuocDienThoai_Admin.DAL;
using QLCuocDienThoai_Admin.DTO;
namespace QLCuocDienThoai_Admin.DAL
{
    class HoaDonTinhCuocDLL
    {
        HoaDonTinhCuocDAL dal = new HoaDonTinhCuocDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable GetData_CapNhat(int phihangthang)
        {
            return dal.GetData_CapNhat(phihangthang);
        }
    }
}
