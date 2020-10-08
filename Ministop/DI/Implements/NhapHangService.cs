using Dapper;
using Ministop.DI.Interfaces;
using Ministop.Models;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Ministop.DI.Implements
{
    public class NhapHangService : INhapHangService
    {
        public IEnumerable<DatHangViewModel> GetAll()
        {
            using(var db = new SqlConnection(Common.ConnectionS.connectionString))
            {
                return db.Query<DatHangViewModel>("sp_GetAll_PhieuNhap",commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(DatHangViewModel _datHang)
        {
            bool result = false;
            PhieuNhap phieuNhap = new PhieuNhap();
            ChiTietPhieuNhap chiTietPhieu = new ChiTietPhieuNhap();
            using(var db = new MinistopDbContext())
            {
                phieuNhap.NhanVienID = _datHang.NhanVienID;
                phieuNhap.NhaCungCapID = _datHang.NhaCungCapID;
                phieuNhap.NgayDat = _datHang.NgayDat;
                phieuNhap.TongTien = _datHang.SoLuong*_datHang.GiaTien;
                db.PhieuNhaps.Add(phieuNhap);
                db.SaveChanges();

                chiTietPhieu.SanPhamID = _datHang.SanPhamID;
                chiTietPhieu.PhieuNhapID = phieuNhap.ID;
                chiTietPhieu.SoLuong = _datHang.SoLuong;
                chiTietPhieu.GiaTien = _datHang.GiaTien;
                db.ChiTietPhieuNhaps.Add(chiTietPhieu);
                db.SaveChanges();
            }
            return result;
        }
    }
}