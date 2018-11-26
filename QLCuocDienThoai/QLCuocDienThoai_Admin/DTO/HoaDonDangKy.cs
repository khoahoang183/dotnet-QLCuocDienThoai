using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDienThoai_Admin.DTO
{
    class HoaDonDangKy
    {
        int MAHDDK;
        int MASIM;
        double PHIDANGKI;
        DateTime NGAYDANGKI;

        public int GetMAHDDK()
        {
            return MAHDDK;
        }

        public void SetMAHDDK(int MAHDDK)
        {
            this.MAHDDK = MAHDDK;
        }

        public int GetMASIM()
        {
            return MASIM;
        }

        public void SetMASIM(int MASIM)
        {
            this.MASIM = MASIM;
        }

        public double GetPHIDANGKI()
        {
            return PHIDANGKI;
        }
        public void SetPHIDANGKI(double PHIDANGKI)
        {
            this.PHIDANGKI = PHIDANGKI;
        }
        public DateTime GetNGAYDANGKI()
        {
            return NGAYDANGKI;
        }
        public void SetNGAYDANGKI(DateTime NGAYDANGKI)
        {
            this.NGAYDANGKI = NGAYDANGKI;
        }
    }
}
