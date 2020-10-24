using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class KhachHangController : BaseController
    {
        IKhachHangService khachHang;
        public KhachHangController(IKhachHangService _khachHang)
        {
            khachHang = _khachHang;
        }
        // GET: KhachHang
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            return View(khachHang.GetAll(page, pagesize));
        }

        public ActionResult KichHoat(int id)
        {
            khachHang.KichHoat(id);
            return RedirectToAction("Index");
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ThemMoi(KhachHangViewModel _khachHang)
        {
            bool result = khachHang.ThemMoi(_khachHang);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhat(int id)
        {
            return View(khachHang.GetById(id));
        }

        [HttpPost]
        public JsonResult CapNhat(KhachHangViewModel _khachHang)
        {
            bool result = khachHang.CapNhat(_khachHang);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Xoa(int id)
        //{
        //    bool result = khachHang.Xoa(id);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Xoa(int id)
        {
            khachHang.Xoa(id);
            return RedirectToAction("Index");
        }
    }
}