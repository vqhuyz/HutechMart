using Dapper;
using Ministop.Models;
using Ministop.ModelsView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            var dt = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<DataPoint> dataPoints = new List<DataPoint>();
            for (int i = 1; i <= dt; i++)
            {
                using (var conn = new SqlConnection(Common.ConnectionS.connectionString))
                {
                    var doanhSo = conn.Query<string>("sp_DoanhSo_Thang", new { ngay = i }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    double test = Convert.ToDouble(doanhSo);
                    dataPoints.Add(new DataPoint("Ngày" + i.ToString(), test));
                }

            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.Thang = DateTime.Now.Month;

            return View();
        }

        public JsonResult GetData(string thang)
        {
            var dt = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            List<DoanhSoViewModel> data = new List<DoanhSoViewModel>();
            for (int i = 1; i <= dt; i++)
            {
                using (var conn = new SqlConnection(Common.ConnectionS.connectionString))
                {
                    var doanhSo = conn.Query<string>("sp_DoanhSo_Thang", new { ngay = i }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    double test = Convert.ToDouble(doanhSo);
                    data.Add(new DoanhSoViewModel(test, "Ngày" + i.ToString()));
                }
            }           
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}