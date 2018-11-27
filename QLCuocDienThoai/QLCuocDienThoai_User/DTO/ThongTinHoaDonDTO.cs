using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCuocDienThoai_User.DTO
{
    public class ThongTinHoaDonDTO
    {
        private int _tongtien;
        private String _thanhtoan;
        public ThongTinHoaDonDTO() { }
        public String Thanhtoan { get => _thanhtoan; set => _thanhtoan = value; }
        public int Tongtien { get => _tongtien; set => _tongtien = value; }
    }
}