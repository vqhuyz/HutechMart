using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class NhanVienController : BaseController
    {
        INhanVienService nhanVien;
        public NhanVienController(INhanVienService _nhanVien)
        {
            nhanVien = _nhanVien;
        }
        // GET: NhanVien
        public ActionResult Index(string search, int page = 1, int pagesize = 1)
        {
            ViewBag.Search = search;
            return View(nhanVien.GetAll(search, page, pagesize));
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVienViewModel _nhanVien, HttpPostedFileBase HinhAnh)
        {
            string path = "";
            if (HinhAnh != null && HinhAnh.ContentLength > 0)
            {
                string extension = Path.GetExtension(HinhAnh.FileName);
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                {
                    path = Path.Combine(Server.MapPath("~/Img/NhanVien/"), HinhAnh.FileName);
                    HinhAnh.SaveAs(path);
                    bool result = nhanVien.ThemMoi(_nhanVien, HinhAnh.FileName);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult CapNhat(int id)
        {
            return View(nhanVien.GetById(id));
        }

        [HttpPost]
        public JsonResult CapNhat(NhanVienViewModel _nhanVien)
        {
            bool result = nhanVien.CapNhat(_nhanVien);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Xoa(int id)
        {
            bool result = nhanVien.Xoa(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThongTin(int id)
        {
            return View(nhanVien.GetById(id));
        }

        [HttpPost]
        public JsonResult DoiMatKhau(int id, string matKhauCu, string matKhauMoi)
        {
            bool result = nhanVien.DoiMatKhau(id, matKhauCu, matKhauMoi);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
    }
}