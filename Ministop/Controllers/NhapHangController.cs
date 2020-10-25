using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  Microsoft.Office.Interop.Excel;
using Ministop.ModelsView;

namespace Ministop.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: NhapHang
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excel)
        {
            List<SanPhamViewModel> lst = new List<SanPhamViewModel>();
            if (excel.FileName.EndsWith("xls") || excel.FileName.EndsWith("xlsx"))
            {
                string path = Server.MapPath("~/Content/" + excel.FileName);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                excel.SaveAs(path);
                Application application = new Application();
                Workbook workbook = application.Workbooks.Open(path);
                Worksheet worksheet = workbook.ActiveSheet;
                Range range = worksheet.UsedRange;
                for (int i = 1; i <= range.Rows.Count; i++)
                {
                    SanPhamViewModel sanPham = new SanPhamViewModel
                    {
                        ThuongHieu = ((Range)range.Cells[i, 1]).Text,
                        TenSanPham = ((Range)range.Cells[i, 2]).Text
                    };
                    lst.Add(sanPham);
                }
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}