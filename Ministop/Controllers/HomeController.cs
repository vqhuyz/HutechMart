using Dapper;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Thang = DateTime.Now.Month;
            return View();
        }

        public JsonResult GetData()
        {
            var dt = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<Dulieu> view = new List<Dulieu>();
            Dulieu dulieu = new Dulieu();
            DoanhSoViewModel data = new DoanhSoViewModel();
            List<DoanhSoView> dsv = new List<DoanhSoView>();
            for (int i = 1; i <= dt; i++)
            {
                using (var conn = new SqlConnection(Common.ConnectionS.connectionString))
                {
                    var doanhSo = conn.Query<string>("sp_DoanhSo_Thang", new { ngay = i }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    double test = Convert.ToDouble(doanhSo);
                    dsv.Add(new DoanhSoView(test, "Ngày" + i.ToString()));
                }
            }
            dulieu.data = dsv;
            view.Add(dulieu);

            DoanhSoView d1 = new DoanhSoView(312312, "Ngày" + "1");
            Dulieu dulieu1 = new Dulieu();
            List<DoanhSoView> dsv1 = new List<DoanhSoView>();
            dsv1.Add(d1);
            dulieu1.data = dsv1;
            view.Add(dulieu1);
            data.dulieu = view;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}