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
            _sanPham.HinhAnh = LayHinhAnh(HinhAnh, _sanPham.TenSanPham);
            sanPham.ThemMoi(_sanPham);
            return RedirectToAction("Index");
        }

        public ActionResult CapNhat(int id)
        {
            ViewBag.LoaiSanPhamID = new SelectList(sanPham.GetAll_LoaiSp(), "ID", "TenLoai");
            return PartialView(sanPham.GetById(id));
        }

        [HttpPost]
        public ActionResult CapNhat(SanPhamViewModel _sanPham, HttpPostedFileBase HinhAnh)
        {
            Random rd = new Random();
            var thayAnh = _sanPham.TenSanPham + rd.Next(1, 10);
            if(HinhAnh != null)
            {
                _sanPham.HinhAnh = LayHinhAnh(HinhAnh, thayAnh);
                sanPham.CapNhat(_sanPham);
            }         
            else
            {
                var id  = sanPham.GetById(_sanPham.ID);
                _sanPham.HinhAnh = id.HinhAnh;
                sanPham.CapNhat(_sanPham);
            }
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


        public ActionResult BanHang(string search, int page = 1, int pagesize = 30)
        {
            return View(sanPham.GetAll(search, page, pagesize));
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
                    path = Path.Combine(Server.MapPath("~/Img/SanPham/"), fileName);
                    HinhAnh.SaveAs(path);
                }
            }
            return fileName;
        }
    }
}