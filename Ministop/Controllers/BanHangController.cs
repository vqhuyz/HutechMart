using Ministop.Common;
using Ministop.DI.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class BanHangController : BaseController
    {
        // GET: BanHang
        ISanPhamService sanPham;
        IBanHangService banHang;
        public BanHangController(ISanPhamService _sanPham, IBanHangService _banHang)
        {
            sanPham = _sanPham;
            banHang = _banHang;
        }

        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            return View(sanPham.GetAll(page, pagesize));
        }

        public ActionResult GetAll(int page = 1, int pagesize = 10)
        {
            return Json(sanPham.GetAll(page, pagesize));
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

        public ActionResult KiemTra(string soDT)
        {
            var khachHang = banHang.LayMaKhachHang(soDT);
            return Json(khachHang, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThanhToan(int nhanVienID, string soDT)
        {
            bool result = false;
            int hoaDonID;
            var sanPham = DanhSachSanPham.DanhSach;
            int VAT = banHang.VAT();
            var tongTien = sanPham.TongTien;
            int? khachHangID = banHang.LayMaKhachHang(soDT);
            if (khachHangID == 0)
            {
                khachHangID = null;
            }
            if (banHang.KiemTraSoluong(sanPham.listSanPham))
            {
                foreach (var item in sanPham.listSanPham)
                {
                    hoaDonID = banHang.BanHang(nhanVienID, khachHangID, VAT, tongTien);

                    result = banHang.ChiTiet(hoaDonID, item.ID, item.SoLuong, item.GiaBan);
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}