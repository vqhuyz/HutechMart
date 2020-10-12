using Ministop.DI.Interfaces;
using Ministop.Models;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class SanPhamController : Controller
    {
        ISanPhamService sanPham;
        public SanPhamController(ISanPhamService _sanPham)
        {
            sanPham = _sanPham;
        }
        // GET: SanPham
        public ActionResult Index(string search, int page = 1, int pagesize = 10)
        {
            return View(sanPham.GetAll(search, page, pagesize));
        }
        
        public ActionResult ThemMoi()
        {
            ViewBag.LoaiSanPhamID = new SelectList(sanPham.GetAll_LoaiSp(), "ID", "TenLoai");
            return PartialView();
        }

        [HttpPost]
        public ActionResult ThemMoi(SanPhamViewModel _sanPham, HttpPostedFileBase HinhAnh)
        {
            string path = "";
            if (HinhAnh != null && HinhAnh.ContentLength > 0)
            {
                string extension = Path.GetExtension(HinhAnh.FileName);
                if (extension.Equals(".jpg") || extension.Equals(".png") || extension.Equals(".jpeg"))
                {
                    path = Path.Combine(Server.MapPath("~/Img/SanPham/"), HinhAnh.FileName);
                    HinhAnh.SaveAs(path);
                    bool result = sanPham.ThemMoi(_sanPham, HinhAnh.FileName);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult CapNhat(int id)
        {
            ViewBag.LoaiSanPhamID = new SelectList(sanPham.GetAll_LoaiSp(), "ID", "TenLoai");
            return PartialView(sanPham.GetById(id));
        }

        [HttpPost]
        public ActionResult CapNhat(SanPhamViewModel _sanPham)
        {
            bool result = sanPham.CapNhat(_sanPham);
            return RedirectToAction("Index");
        }

        public ActionResult Xoa(int id)
        {
            bool result = sanPham.Xoa(id);
            return RedirectToAction("Index");
        }

        //public JsonResult Xoa(int id)
        //{
        //    bool result = sanPham.Xoa(id);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult LoaiSanPham()
        {  
            return PartialView();
        }

        [HttpPost]
        public JsonResult LoaiSanPham(LoaiSanPhamViewModel _loaiSP)
        {
            bool result = sanPham.LoaiSanPham(_loaiSP);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BanHang(string search, int page = 1, int pagesize = 30)
        {
            return View(sanPham.GetAll(search, page, pagesize));
        }
    }
}