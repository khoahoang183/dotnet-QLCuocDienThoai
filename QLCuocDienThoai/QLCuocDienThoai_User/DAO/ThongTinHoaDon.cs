using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLCuocDienThoai_User.Models;
using QLCuocDienThoai_User.DTO;

namespace QLCuocDienThoai_User.DAO
{
    public class ThongTinHoaDon
    {
        QLCuocDienThoaiEntities context;
        public ThongTinHoaDon()
        {
            context = new QLCuocDienThoaiEntities();
        }
        public int GetMaSimBySdt(string sdt)
        {
            return context.THONGTINSIMs.Where(x => x.SODT == sdt).Select(x => x.MASIM).FirstOrDefault();
        }
        public List<HOADONTINHCUOC> GetAllByMaSim(int MaSim)
        {
            return context.HOADONTINHCUOCs.Where(x => x.MASIM == MaSim).ToList();
        }
        public List<ThongTinHoaDonDTO> GetThongTinHoaDon(string sdt)
        {
            var list_tmp = GetAllByMaSim(GetMaSimBySdt(sdt));
            List<ThongTinHoaDonDTO> list = new List<ThongTinHoaDonDTO>();
            foreach (var item in list_tmp)
            {
                ThongTinHoaDonDTO dto = new ThongTinHoaDonDTO();
                dto.Tongtien = Convert.ToInt32(item.TONGTIEN);
                if (item.THANHTOAN == 1)
                    dto.Thanhtoan = "Chưa thanh toán";
                else dto.Thanhtoan = "Đã thanh toán";
                list.Add(dto);
            }
            return list;
        }
    }
}