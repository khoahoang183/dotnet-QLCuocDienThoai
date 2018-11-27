using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLCuocDienThoai_User.DAO;

namespace QLCuocDienThoai_User.Controllers
{
    public class ThongTinSuDungController : Controller
    {
        // GET: ThongTinSuDung
        public ActionResult Index(string sdt)
        {
            var dao = new ThongTinSuDung();
            var model = dao.GetThongTinSuDung(sdt);
            return View(model);
        }
    }
}