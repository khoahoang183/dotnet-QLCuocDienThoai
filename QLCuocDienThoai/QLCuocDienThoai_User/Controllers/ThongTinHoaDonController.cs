using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLCuocDienThoai_User.DAO;

namespace QLCuocDienThoai_User.Controllers
{
    public class ThongTinHoaDonController : Controller
    {
        // GET: ThongTinHoaDon
        public ActionResult Index(string sdt)
        {
            var dao = new ThongTinHoaDon();
            var model = dao.GetThongTinHoaDon(sdt);
            return View(model);
        }
    }
}