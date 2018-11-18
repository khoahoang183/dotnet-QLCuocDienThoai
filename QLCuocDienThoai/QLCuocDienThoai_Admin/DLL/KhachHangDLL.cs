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
    class KhachHangDLL
    {
        KhachHangDAL dal = new KhachHangDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public bool AddData(KhachHang khachhang)
        {
            return dal.AddData(khachhang);
        }
        public bool UpdateData(KhachHang khachhang)
        {
            return dal.UpdateData(khachhang);
        }
        public bool LockData(int MaKH,int TinhTrang)
        {
            return dal.LockData(MaKH, TinhTrang);
        }
        public DataTable SearchData(int MaNV)
        {
            return dal.SearchData(MaNV);
        }
    }
}
