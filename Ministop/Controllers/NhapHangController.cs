using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: NhapHang
        ISanPhamService sanPham;
        public NhapHangController(ISanPhamService _sanPham)
        {
            sanPham = _sanPham;
        }
        public ActionResult Index(string search, int page = 1, int pagesize = 10)
        {
            return View(sanPham.GetAll(search, page, pagesize));
        }

        public ActionResult XacNhanDatHang()
        {
            var danhSach = Session["SanPham"];
            var danhSachSanPham = new List<NhapHangViewModel>();
            if (danhSach != null)
            {
                danhSachSanPham = (List<NhapHangViewModel>)danhSach;
            }
            return View(danhSachSanPham);
        }

        public ActionResult ThemSanPham(int sanPhamID, int soLuong)
        {
            var laySanPham = sanPham.GetById(sanPhamID);
            var danhSach = Session["SanPham"];

            if (danhSach != null)
            {
                var list = (List<NhapHangViewModel>)danhSach;

                if (list.Exists(x => x.SanPham.ID == sanPhamID))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.ID == sanPhamID)
                        {
                            item.SoLuong += soLuong;
                        }
                    }
                }
                else
                {
                    var themSanPham = new NhapHangViewModel();
                    themSanPham.SanPham = laySanPham;
                    themSanPham.SoLuong = soLuong;
                    list.Add(themSanPham);
                }
                Session["SanPham"] = list;
            }
            else
            {
                var themSanPham = new NhapHangViewModel();
                themSanPham.SanPham = laySanPham;
                themSanPham.SoLuong = soLuong;
                var list = new List<NhapHangViewModel>();
                list.Add(themSanPham);
                Session["SanPham"] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult CapNhat(int id)
        {
            var list = new List<NhapHangViewModel>();
            NhapHangViewModel nhapHang = list.Find(x => x.SanPham.ID == id);
            nhapHang.SoLuong++;
            var soLuong = nhapHang.SoLuong;
            var tongTien = String.Format("{0:0,0}", TongTien());
            return Json(new { soluong = soLuong, tongtien = tongTien }, JsonRequestBehavior.AllowGet);
        }


        public decimal TongTien()
        {
            decimal tongTien = 0;
            if (Session["SanPham"] != null)
            {
                var list = (List<NhapHangViewModel>)Session["SanPham"];
                tongTien = list.Sum(x => x.SoLuong * x.SanPham.GiaBan);
            }
            return tongTien;
        }


        //       public JsonResult IncreaseCount(long id, int count)
        //{

        //    Cart cartItem = listCartItem.Find(x => x.Id == id);

        //    cartItem.Count++;

        //    var counter = cartItem.Count;
        //    var total = String.Format("{0:0,0}", TotalMoney());

        //    return Json(new { Count = counter, TotalMoney = total }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult DecreaseCount(long id, int count)
        //{
        //    Cart cartItem = listCartItem.Find(x => x.Id == id);

        //    cartItem.Count--;

        //    var counter = cartItem.Count;
        //    var total = String.Format("{0:0,0}", TotalMoney());

        //    return Json(new { Count = counter, TotalMoney = total }, JsonRequestBehavior.AllowGet);
        //}
    }
}