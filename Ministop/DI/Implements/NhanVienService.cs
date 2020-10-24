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
    public class NhanVienService : INhanVienService
    {
        public IEnumerable<NhanVienViewModel> GetAll(int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<NhanVienViewModel>("sp_GetAll_NhanVien", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public NhanVienViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<NhanVienViewModel>("sp_GetById_NhanVien", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(NhanVienViewModel _nhanVien)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var themMoi = connection.Execute("sp_ThemMoi_NhanVien", new
                    {
                        tenNV = _nhanVien.TenNhanVien,
                        gioiTinh = _nhanVien.GioiTinh,
                        ngaysinh = _nhanVien.NgaySinh,
                        soCMND = _nhanVien.SoCMND,
                        soDT = _nhanVien.SoCMND,
                        ngayThamGia = DateTime.Now,
                        email = _nhanVien.Email,
                        hinhAnh = _nhanVien.HinhAnh,
                        diaChi = _nhanVien.DiaChi,
                        chucVu = _nhanVien.ChucVu,
                        mucLuong = _nhanVien.GhiChu,
                        ghiChu = _nhanVien.GhiChu,
                        matKhau = Encryptor.MD5Hash("1"),
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
            }

            return result;

        }

        public bool CapNhat(NhanVienViewModel _nhanVien)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var capNhat = connection.Execute("sp_CapNhat_NhanVien", new
                    {
                        id = _nhanVien.ID,
                        tenNV = _nhanVien.TenNhanVien,
                        gioiTinh = _nhanVien.GioiTinh,
                        ngaysinh = _nhanVien.NgaySinh,
                        soCMND = _nhanVien.SoCMND,
                        soDT = _nhanVien.SoCMND,
                        ngayCapNhat = DateTime.Now,
                        email = _nhanVien.Email,
                        hinhAnh = _nhanVien.HinhAnh,
                        diaChi = _nhanVien.DiaChi,
                        chucVu = _nhanVien.ChucVu,
                        mucLuong = _nhanVien.GhiChu,
                        ghiChu = _nhanVien.GhiChu,
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
                var xoa = connection.Execute("sp_Xoa_NhanVien", new
                {
                    Id = id,
                    ngayCapNhat = DateTime.Now,
                }, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }
        public bool DoiMatKhau(int id, string MatKhauCu, string MatKhauMoi)
        {
            bool result = false;
            var test1 = Encryptor.MD5Hash(MatKhauCu);
            var test2 = Encryptor.MD5Hash(MatKhauMoi);
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var doiMatKhau = connection.Execute("sp_DoiMatKhau_NhanVien", new
                    {
                        Id = id,
                        matKhau = test1,
                        matKhauMoi = test2,
                    }, commandType: CommandType.StoredProcedure);
                    if (doiMatKhau != 0)
                    {
                        result = true;
                    }
                }
                catch { }
            }
            return result;
        }

        public bool CapNhatThongTin(NhanVienViewModel _nhanVien)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var capNhat = connection.Execute("sp_CapNhat_ThongTin", new
                    {
                        id = _nhanVien.ID,
                        tenNV = _nhanVien.TenNhanVien,
                        gioiTinh = _nhanVien.GioiTinh,
                        ngaysinh = _nhanVien.NgaySinh,
                        soCMND = _nhanVien.SoCMND,
                        soDT = _nhanVien.SoCMND,
                        ngayCapNhat = DateTime.Now,
                        email = _nhanVien.Email,
                        diaChi = _nhanVien.DiaChi,
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
                var kichHoat = connection.Execute("sp_KichHoat_NhanVien", new { Id = id }, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }
    }
}