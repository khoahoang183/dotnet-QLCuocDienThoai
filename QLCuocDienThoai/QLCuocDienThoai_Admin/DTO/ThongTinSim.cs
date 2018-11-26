using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDienThoai_Admin.DTO
{
    class ThongTinSim
    {
        int MASIM;
        String SODT;
        int MAKH;
        int TINHTRANG;

        public int GetMASIM()
        {
            return MASIM;
        }

        public void SetMASIM(int MASIM)
        {
            this.MASIM = MASIM;
        }

        public String GetSODT()
        {
            return SODT;
        }
        public void SetSODT(String SODT)
        {
            this.SODT = SODT;
        }
        public int GetMAKH()
        {
            return MAKH;
        }

        public void SetMAKH(int MAKH)
        {
            this.MAKH = MAKH;
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
