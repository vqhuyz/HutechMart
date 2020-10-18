using Ministop.Common;
using Ministop.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class BanHangController : Controller
    {
        // GET: BanHang
        ISanPhamService sanPham;
        public BanHangController(ISanPhamService _sanPham)
        {
            sanPham = _sanPham;
        }

        public ActionResult Index(string search, int page = 1, int pagesize = 10)
        {
            var nhapHang = DanhSachSanPham.DanhSach;
            ViewBag.SanPham = nhapHang.listSanPham;
            return View(sanPham.GetAll(search, page, pagesize));
        }

        public ActionResult ThemSanPham(int id)
        {
            var nhapHang = DanhSachSanPham.DanhSach;
            nhapHang.ThemSanPham(id);

            var chiTiet = new { nhapHang.SoLuong, nhapHang.TongTien };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhatSoLuong(int id, int soLuong)
        {
            var nhapHang = DanhSachSanPham.DanhSach;
            nhapHang.CapNhatSoLuong(id, soLuong);

            var p = nhapHang.listSanPham.Single(i => i.ID == id);
            var chiTiet = new { nhapHang.SoLuong, nhapHang.TongTien };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XoaSanPham(int id)
        {
            var nhapHang = DanhSachSanPham.DanhSach;
            nhapHang.XoaSanPham(id);

            var chiTiet = new { nhapHang.SoLuong, nhapHang.TongTien };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }
    }
}