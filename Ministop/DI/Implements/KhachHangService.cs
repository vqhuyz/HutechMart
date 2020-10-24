using Dapper;
using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ministop.DI.Implements
{
    public class KhachHangService : IKhachHangService
    {
        public IEnumerable<KhachHangViewModel> GetAll(int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<KhachHangViewModel>("sp_GetAll_KhachHang", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public KhachHangViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<KhachHangViewModel>("sp_GetById_KhachHang", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(KhachHangViewModel _khachHang)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var themMoi = connection.ExecuteScalar<int>("sp_ThemMoi_KhachHang",
                                  new
                                  {
                                      tenKH = _khachHang.TenKH,
                                      gioiTinh = _khachHang.GioiTinh,
                                      ngaySinh = _khachHang.NgaySinh,
                                      soCMND = _khachHang.SoCMND,
                                      soDT = _khachHang.SoDT,
                                      email = _khachHang.Email,
                                      diaChi = _khachHang.DiaChi,
                                      facebook = _khachHang.Facebook,
                                      ghiChu = _khachHang.GhiChu,
                                      ngayThamGia = DateTime.Now
                                  }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public bool Xoa(int id)
        {

            bool result = false;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                var Xoa = connection.Execute("sp_Xoa_KhachHang", new { Id = id, ngayCapNhat = DateTime.Now }, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }

        public bool CapNhat(KhachHangViewModel _khachHang)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var capNhat = connection.Execute("sp_CapNhat_KhachHang",
                             new
                             {
                                 id = _khachHang.ID,
                                 tenKH = _khachHang.TenKH,
                                 gioiTinh = _khachHang.GioiTinh,
                                 ngaySinh = _khachHang.NgaySinh,
                                 soCMND = _khachHang.SoCMND,
                                 soDT = _khachHang.SoDT,
                                 email = _khachHang.Email,
                                 diaChi = _khachHang.DiaChi,
                                 facebook = _khachHang.Facebook,
                                 ghiChu = _khachHang.GhiChu,
                                 ngayCapNhat = DateTime.Now
                             }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public bool KichHoat(int id)
        {
            bool result = false;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                var kichHoat = connection.Execute("sp_KichHoat_KhachHang", new { Id = id }, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }
    }
}
