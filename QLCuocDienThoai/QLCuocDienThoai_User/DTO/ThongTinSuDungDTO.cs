using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCuocDienThoai_User.DTO
{
    public class ThongTinSuDungDTO
    {
        private DateTime _tgbd;
        private DateTime _tgkt;
        private int _sophut;
        private int _cuocphi;
        public ThongTinSuDungDTO() { }
        public int Sophut { get => _sophut; set => _sophut = value; }
        public DateTime Tgkt { get => _tgkt; set => _tgkt = value; }
        public DateTime Tgbd { get => _tgbd; set => _tgbd = value; }
        public int Cuocphi { get => _cuocphi; set => _cuocphi = value; }
    }
}