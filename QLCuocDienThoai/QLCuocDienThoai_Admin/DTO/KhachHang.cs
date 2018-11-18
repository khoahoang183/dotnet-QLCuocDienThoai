using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDienThoai_Admin.DTO
{
    class KhachHang
    {
        int MAKH;
        String TEN;
        String THONGTIN;
        int TINHTRANG;

        public int GetMAKH()
        {
            return MAKH;
        }

        public void SetMAKH(int MAKH)
        {
            this.MAKH = MAKH;
        }

        public String GetTEN()
        {
            return TEN;
        }
        public void SetTEN(String TEN)
        {
            this.TEN = TEN;
        }
        public String GetTHONGTIN()
        {
            return THONGTIN;
        }
        public void SetTHONGTIN(String THONGTIN)
        {
            this.THONGTIN = THONGTIN;
        }
        public int GetTINHTRANG()
        {
            return TINHTRANG;
        }

        public void SetTINHTRANG(int TINHTRANG)
        {
            this.TINHTRANG = TINHTRANG;
        }
    }
}
