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

        public ActionResult Add(int id)
        {
            var cart = NhapHangViewModel.Cart;
            cart.Add(id);

            var info = new { cart.Count, cart.Total };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

    }
}