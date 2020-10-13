using Dapper;
using Ministop.Common;
using Ministop.Models;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ministop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string taiKhoan, string matKhau)
        {
            matKhau = Encryptor.MD5Hash(matKhau);
            using (var db = new SqlConnection(ConnectionS.connectionString))
            {
                var dangNhap = db.QueryFirstOrDefault<DangNhapViewModel>("sp_Login", new { taiKhoan, matKhau }, commandType: CommandType.StoredProcedure);
                if (dangNhap != null)
                {
                    Session["DangNhap"] = dangNhap;
                    //Session["NhanVien"] = dangNhap.ID;
                    //Session["TenNV"] = dangNhap.TenNhanVien;
                    //Session["ChucVu"] = dangNhap.ChucVu;
                    //Session["HinhAnh"] = dangNhap.HinhAnh;
                    //Session["QuyenHan"] = dangNhap.PhanQuyenID;

                    return Json("OK",JsonRequestBehavior.AllowGet);
                }
                return Json("!OK", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}