using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDienThoai_Admin.DTO
{
    class HoaDonTinhCuoc
    {
        int MAHDTC;
        int MASIM;
        double TONGTIEN;
        int THANHTOAN;
        int THANG;
        int NAM;

        public int GetMAHDTC()
        {
            return MAHDTC;
        }

        public void SetMAHDTC(int MAHDTC)
        {
            this.MAHDTC = MAHDTC;
        }
        public int GetMASIM()
        {
            return MASIM;
        }

        public void SetMASIM(int MASIM)
        {
            this.MASIM = MASIM;
        }
        public double GetTONGTIEN()
        {
            return TONGTIEN;
        }
        public void SetTONGTIEN(double TONGTIEN)
        {
            this.TONGTIEN = TONGTIEN;
        }
        public int GetTHANHTOAN()
        {
            return THANHTOAN;
        }
        public void SetTHANHTOAN(int THANHTOAN)
        {
            this.THANHTOAN = THANHTOAN;
        }
        public int GetTHANG()
        {
            return THANG;
        }
        public void SetTHANG(int THANG)
        {
            this.THANG = THANG;
        }
        public int GetNAM()
        {
            return NAM;
        }
        public void SetNAM(int NAM)
        {
            this.NAM = NAM;
        }
    }
}
