using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class SanPhamController : BaseController
    {
        ISanPhamService sanPham;
        public SanPhamController(ISanPhamService _sanPham)
        {
            sanPham = _sanPham;
        }
        // GET: SanPham
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            return View(sanPham.GetAll(page, pagesize));
        }

        public ActionResult GiamGia(int id, int giamGia)
        {
            bool result = sanPham.GiamGia(id, giamGia);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThemMoi()
        {
            ViewBag.LoaiSanPhamID = new SelectList(sanPham.GetAll_LoaiSp(), "ID", "TenLoai");
            return PartialView();
        }

        [HttpPost]
        public JsonResult ThemMoi(SanPhamViewModel _sanPham, HttpPostedFileBase HinhAnh)
        {
            if (HinhAnh == null)
            {
                _sanPham.HinhAnh = "SanPham.png";
            }
            else
            {
                _sanPham.HinhAnh = LayHinhAnh(HinhAnh, _sanPham.TenSanPham);
            }
            bool result = sanPham.ThemMoi(_sanPham);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhat(int id)
        {
            ViewBag.LoaiSanPhamID = new SelectList(sanPham.GetAll_LoaiSp(), "ID", "TenLoai");
            return PartialView(sanPham.GetById(id));
        }

        [HttpPost]
        public JsonResult CapNhat(SanPhamViewModel _sanPham, HttpPostedFileBase HinhAnh)
        {
            if (HinhAnh != null)
            {
                Random rd = new Random();
                var thayAnh = _sanPham.TenSanPham + rd.Next(1, 10);
                _sanPham.HinhAnh = LayHinhAnh(HinhAnh, thayAnh);
            }
            else
            {
                var id = sanPham.GetById(_sanPham.ID);
                _sanPham.HinhAnh = id.HinhAnh;
            }
            bool result = sanPham.CapNhat(_sanPham);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Xoa(int id)
        {
            bool result = sanPham.Xoa(id);
            return RedirectToAction("Index");
        }

        public ActionResult BanHang(string search, int page = 1, int pagesize = 30)
        {
            return View(sanPham.GetAll(page, pagesize));
        }

        public string LayHinhAnh(HttpPostedFileBase HinhAnh, string tenSP)
        {
            string path = "";
            string fileName = tenSP + ".jpg";
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