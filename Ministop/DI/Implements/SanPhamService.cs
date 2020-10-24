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
    public class SanPhamService : ISanPhamService
    {
        public IEnumerable<SanPhamViewModel> GetAll(int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<SanPhamViewModel>("sp_GetAll_SanPham", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public IEnumerable<LoaiSanPhamViewModel> GetAll_LoaiSp()
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<LoaiSanPhamViewModel>("sp_GetAll_LoaiSanPham", commandType: CommandType.StoredProcedure);
            }
        }

        public void test()
        {

        }

        public SanPhamViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<SanPhamViewModel>("sp_GetById_SanPham", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(SanPhamViewModel _sanPham)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var themMoi = connection.Execute("sp_ThemMoi_SanPham", new
                    {
                        loaiSanPhamID = _sanPham.LoaiSanPhamID,
                        tenSanPham = _sanPham.TenSanPham,
                        thuongHieu = _sanPham.ThuongHieu,
                        hinhAnh = _sanPham.HinhAnh,
                        giaBan = _sanPham.GiaBan,
                        giaNhap = _sanPham.GiaNhap,
                        soLuong = _sanPham.SoLuong,
                        ngayThem = DateTime.Now,
                        ghiChu = _sanPham.GhiChu,
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public bool CapNhat(SanPhamViewModel _sanPham)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var capNhat = connection.Execute("sp_CapNhat_SanPham", new
                    {
                        id = _sanPham.ID,
                        loaiSanPhamID = _sanPham.LoaiSanPhamID,
                        tenSanPham = _sanPham.TenSanPham,
                        thuongHieu = _sanPham.ThuongHieu,
                        hinhAnh = _sanPham.HinhAnh,
                        giaBan = _sanPham.GiaBan,
                        giaNhap = _sanPham.GiaNhap,
                        soLuong = _sanPham.SoLuong,
                        ngayCapNhat = DateTime.Now,
                        ghiChu = _sanPham.GhiChu,
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
                var xoa = connection.Execute("sp_Xoa_SanPham", new { Id = id, ngayCapNhat = DateTime.Now }, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }

        public bool LoaiSanPham(LoaiSanPhamViewModel loaiSP)
        {
            throw new NotImplementedException();
        }
    }
}
