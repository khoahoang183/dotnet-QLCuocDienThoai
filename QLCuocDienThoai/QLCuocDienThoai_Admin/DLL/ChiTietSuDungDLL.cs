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
    class ChiTietSuDungDLL
    {
        ChiTietSuDungDAL dal = new ChiTietSuDungDAL();
        public int CountSIM()
        {
            return dal.CountSIM();
        }
        public bool AddData(ChiTietSuDung chitiet)
        {
            return dal.AddData(chitiet);
        }
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable SearchData(int MaSIM)
        {
            return dal.SearchData(MaSIM);
        }
    }
}
