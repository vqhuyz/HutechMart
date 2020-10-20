using Dapper;
using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ministop.DI.Implements
{
    public class BanHangService : IBanHangService
    {
        public int BanHang(int nhanVienID, int? khachHangID, int thueVAT, double tongTien)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                var banHang = connection.ExecuteScalar<int>("sp_ThemMoi_HoaDon", new
                {
                    nhanVienID = nhanVienID,
                    khachHangID = khachHangID,
                    thueVAT = thueVAT,
                    ngayMua = DateTime.Now,
                    tongTien = tongTien,
                }, commandType: CommandType.StoredProcedure);
                return banHang;
            }
        }

        public bool ChiTiet(int hoaDonID, int sanPhamID, int soLuong, decimal giaBan)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var chiTiet = connection.Execute("sp_ThemMoi_ChiTietHoaDon", new
                    {
                        hoaDonID = hoaDonID,
                        sanPhamID = sanPhamID,
                        soLuong = soLuong,
                        giaBan = giaBan,
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
                return result;
            }
        }

        public int LayMaKhachHang(string soDT)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<int>("sp_GetById_SoDT_KhachHang", new { soDT = soDT }, commandType: CommandType.StoredProcedure);
            }
        }

        public int VAT()
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<int>("sp_GetVAT", commandType: CommandType.StoredProcedure);
            }
        }
    }
}