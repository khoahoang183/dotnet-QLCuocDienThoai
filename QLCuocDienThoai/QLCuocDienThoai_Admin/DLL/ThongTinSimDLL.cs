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
    class ThongTinSimDLL
    {
        ThongTinSimDAL dal = new ThongTinSimDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable GetData_Combobox_MaKH()
        {
            return dal.GetData_Combobox_MaKH();
        }
        public bool AddData(ThongTinSim ThongTinSim)
        {
            return dal.AddData(ThongTinSim);
        }
        public bool UpdateData(ThongTinSim ThongTinSim)
        {
            return dal.UpdateData(ThongTinSim);
        }
        public bool LockData(int MaSIM, int TinhTrang)
        {
            return dal.LockData(MaSIM, TinhTrang);
        }
        public DataTable SearchData(int MaNV)
        {
            return dal.SearchData(MaNV);
        }
    }
}
