using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLCuocDienThoai_User.Models;
using QLCuocDienThoai_User.DTO;

namespace QLCuocDienThoai_User.DAO
{
    public class ThongTinSuDung
    {
        QLCuocDienThoaiEntities context;
        public ThongTinSuDung()
        {
            context = new QLCuocDienThoaiEntities();
        }
        public int GetMaSimBySdt(string sdt)
        {
           return context.THONGTINSIMs.Where(x => x.SODT == sdt).Select(x => x.MASIM).FirstOrDefault();
        }
        public List<CHITIETSUDUNG> GetAllByMaSim(int MaSim)
        {
            return context.CHITIETSUDUNGs.Where(x => x.MASIM == MaSim).ToList();
        }
        public List<ThongTinSuDungDTO> GetThongTinSuDung(string sdt)
        {
            var list_tmp = GetAllByMaSim(GetMaSimBySdt(sdt));
            List<ThongTinSuDungDTO> list = new List<ThongTinSuDungDTO>();
            foreach(var item in list_tmp)
            {
                ThongTinSuDungDTO dto = new ThongTinSuDungDTO();
                dto.Tgbd = item.BATDAU;
                dto.Tgkt = item.KETTHUC;
                dto.Sophut = int.Parse(item.SOPHUTSUDUNG.ToString());
                dto.Cuocphi = Convert.ToInt32(item.CUOCPHI);
                list.Add(dto);
            }
            return list;
        }
    }
}