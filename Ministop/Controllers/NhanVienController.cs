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
        public ActionResult Index(string search, int page = 1, int pagesize = 10)
        {
            ViewBag.Search = search;
            return View(nhanVien.GetAll(search, page, pagesize));
        }

        public ActionResult NgungHoatDong(string search, int page = 1, int pagesize = 10)
        {
            ViewBag.Search = search;
            return View(nhanVien.GetAll(search, page, pagesize));
        }

        public ActionResult KichHoat(int id)
        {
            nhanVien.KichHoat(id);
            return RedirectToAction("NgungHoatDong");
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVienViewModel _nhanVien, HttpPostedFileBase HinhAnh)
        {
            _nhanVien.HinhAnh = LayHinhAnh(HinhAnh, _nhanVien.TenNhanVien);
            nhanVien.ThemMoi(_nhanVien);
            return RedirectToAction("Index");
        }

        public ActionResult CapNhat(int id)
        {
            return View(nhanVien.GetById(id));
        }

        [HttpPost]
        public ActionResult CapNhat(NhanVienViewModel _nhanVien, HttpPostedFileBase HinhAnh)
        {
            Random rd = new Random();
            var thayAnh = _nhanVien.TenNhanVien + rd.Next(1, 10);
            if (HinhAnh != null)
            {
                _nhanVien.HinhAnh = LayHinhAnh(HinhAnh, thayAnh);
                nhanVien.CapNhat(_nhanVien);
            }
            else
            {
                var id = nhanVien.GetById(_nhanVien.ID);
                _nhanVien.HinhAnh = id.HinhAnh;
                nhanVien.CapNhat(_nhanVien);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Xoa(int id)
        {
            nhanVien.Xoa(id);
            return RedirectToAction("Index");
        }

        //public JsonResult Xoa(int id)
        //{
        //    bool result = nhanVien.Xoa(id);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

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

        [HttpPost]
        public JsonResult CapNhatThongTin(NhanVienViewModel _nhanVien)
        {
            bool result = nhanVien.CapNhatThongTin(_nhanVien);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string LayHinhAnh(HttpPostedFileBase HinhAnh, string tenNV)
        {
            string path = "";
            string fileName = tenNV + ".jpg";
            if (HinhAnh != null && HinhAnh.ContentLength > 0)
            {
                string extension = Path.GetExtension(HinhAnh.FileName);
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                {
                    path = Path.Combine(Server.MapPath("~/Img/NhanVien/"), fileName);
                    HinhAnh.SaveAs(path);
                }
            }
            return fileName;
        }
    
    }
}