using Ministop.DI.Interfaces;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class HoaDonController : BaseController
    {
        IHoaDonService hoaDon;
        public HoaDonController(IHoaDonService _hoaDon)
        {
            hoaDon = _hoaDon;
        }
        // GET: HoaDon
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            return View(hoaDon.GetAll(page, pagesize));
        }

        public ActionResult ChiTietHoaDon(int id)
        {
            return PartialView(hoaDon.GetById(id));
        }

        public ActionResult TraHang(int id)
        {
            return View(hoaDon.GetById(id));
        }
    }
}