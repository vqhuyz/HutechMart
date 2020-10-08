using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class PhieuNhapController : Controller
    {
        INhapHangService nhapHang;
        public PhieuNhapController(INhapHangService _nhapHang)
        {
            nhapHang = _nhapHang;
        }
        // GET: PhieuNhap
        public ActionResult Index()
        {
            return View(nhapHang.GetAll());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ThemMoi(DatHangViewModel _datHang)
        {
            return Json(nhapHang.ThemMoi(_datHang), JsonRequestBehavior.AllowGet);
        }
    }
}