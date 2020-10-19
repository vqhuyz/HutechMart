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
            var banHang = DanhSachSanPham.DanhSach;
            ViewBag.SanPham = banHang.listSanPham;
            return View(sanPham.GetAll(search, page, pagesize));
        }

        public ActionResult ThemSanPham(int id)
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.ThemSanPham(id);

            var chiTiet = new { banHang.SoLuong, banHang.TongTien };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhatSoLuong(int id, int soLuong)
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.CapNhatSoLuong(id, soLuong);

            var p = banHang.listSanPham.Single(i => i.ID == id);
            var chiTiet = new {
                banHang.SoLuong,
                banHang.TongTien,
                ThanhTien = p.SoLuong * p.GiaBan
            };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XoaSanPham(int id)
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.XoaSanPham(id);

            var chiTiet = new { banHang.SoLuong, banHang.TongTien };
            return Json(chiTiet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XoaHet()
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.XoaHet();
            return RedirectToAction("Index");
        }

        public ActionResult ThanhToan(int maNV, int tongTien)
        {
            //var cart = DanhSachSanPham.DanhSach;
            //int ProductId;
            //decimal UnitPrice;
            //int Discount;
            //foreach (var p in cart.listSanPham)
            //{

            //    ProductId = p.ID;
            //    UnitPrice = p.GiaBan;
            //    Discount = p.SoLuong;
            //}
            return View();
        }
    }
}