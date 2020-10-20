using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.Models;
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
        IBanHangService banHang;
        public BanHangController(ISanPhamService _sanPham, IBanHangService _banHang)
        {
            sanPham = _sanPham;
            banHang = _banHang;
        }

        public ActionResult Index(string search, int page = 1, int pagesize = 10)
        {
            return View(sanPham.GetAll(search, page, pagesize));
        }

        public ActionResult ThemSanPham(int id)
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.ThemSanPham(id);

            return Json(banHang, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhatSoLuong(int id, int soLuong)
        {
            var banHang = DanhSachSanPham.DanhSach;
            banHang.CapNhatSoLuong(id, soLuong);

            var p = banHang.listSanPham.Single(i => i.ID == id);
            var chiTiet = new
            {
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

        public ActionResult ThanhToan(int nhanVienID, string soDT)
        {
            bool result = false;
            var sanPham = DanhSachSanPham.DanhSach;
            int VAT = banHang.VAT();
            var tongTien = double.Parse(sanPham.TongTien);
            int? khachHangID = banHang.LayMaKhachHang(soDT);
            if (khachHangID == 0)
            {
                khachHangID = null;
            }
            var hoaDonID = banHang.BanHang(nhanVienID, khachHangID, VAT , tongTien);
            foreach (var item in sanPham.listSanPham)
            {
                result = banHang.ChiTiet(hoaDonID, item.ID, item.SoLuong, item.GiaBan);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}