using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class NhaCungCapController : BaseController
    {
        INhaCungCapService nhaCungCap;
        public NhaCungCapController(INhaCungCapService _nhaCungCap)
        {
            nhaCungCap = _nhaCungCap;
        }
        // GET: NhaCungCap
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            return View(nhaCungCap.GetAll(page, pagesize));
        }
        public ActionResult KichHoat(int id)
        {
            nhaCungCap.KichHoat(id);
            return RedirectToAction("Index");
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ThemMoi(NhaCungCapViewModel _nhaCungCap)
        {
            var result = nhaCungCap.ThemMoi(_nhaCungCap);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhat(int id)
        {
            return View(nhaCungCap.GetById(id));
        }

        [HttpPost]
        public JsonResult CapNhat(NhaCungCapViewModel _nhaCungCap)
        {
            bool result = nhaCungCap.CapNhat(_nhaCungCap);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Xoa(int id)
        //{
        //    var result = nhaCungCap.Xoa(id);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Xoa(int id)
        {
            nhaCungCap.Xoa(id);
            return RedirectToAction("Index");
        }

    }
}