using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDienThoai_Admin.DTO
{
    class ChiTietSuDung
    {
        int MACTSD;
        int MASIM;
        DateTime BATDAU;
        DateTime KETTHUC;
        int SOPHUTSUDUNGSAU23H;
        int SOPHUTSUDUNGSAU7H;
        double CUOCPHI;

        public int GetMACTSD()
        {
            return MACTSD;
        }

        public void SetMACTSD(int MACTSD)
        {
            this.MACTSD = MACTSD;
        }

        public int GetMASIM()
        {
            return MASIM;
        }

        public void SetMASIM(int MASIM)
        {
            this.MASIM = MASIM;
        }

        public DateTime GetBATDAU()
        {
            return BATDAU;
        }
        public void SetBATDAU(DateTime BATDAU)
        {
            this.BATDAU = BATDAU;
        }
        public DateTime GetKETTHUC()
        {
            return KETTHUC;
        }
        public void SetKETTHUC(DateTime KETTHUC)
        {
            this.KETTHUC = KETTHUC;
        }
        public int GetSOPHUTSUDUNGSAU23H()
        {
            return SOPHUTSUDUNGSAU23H;
        }

        public void SetSOPHUTSUDUNGSAU23H(int SOPHUTSUDUNGSAU23H)
        {
            this.SOPHUTSUDUNGSAU23H = SOPHUTSUDUNGSAU23H;
        }
        public int GetSOPHUTSUDUNGSAU7H()
        {
            return SOPHUTSUDUNGSAU7H;
        }

        public void SetSOPHUTSUDUNGSAU7H(int SOPHUTSUDUNGSAU7H)
        {
            this.SOPHUTSUDUNGSAU7H = SOPHUTSUDUNGSAU7H;
        }
        public double GetCUOCPHI()
        {
            return CUOCPHI;
        }

        public void SetCUOCPHI(double CUOCPHI)
        {
            this.CUOCPHI = CUOCPHI;
        }
    }
}
