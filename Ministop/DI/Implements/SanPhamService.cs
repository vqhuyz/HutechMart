using Dapper;
using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.Models;
using Ministop.ModelsView;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ministop.DI.Implements
{
    public class SanPhamService : ISanPhamService
    {
        public IEnumerable<SanPhamViewModel> GetAll(string search, int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                if(!string.IsNullOrEmpty(search))
                {
                    var sanPham =  connection.Query<SanPhamViewModel>("sp_Search_SanPham",new { tenSanPham = search, thuongHieu = search }, commandType: CommandType.StoredProcedure);
                    return sanPham.ToPagedList(page, pagesize);

                }
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

        public SanPhamViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<SanPhamViewModel>("sp_GetById_SanPham", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(SanPhamViewModel _sanPham, string fileAnh)
        {
            bool result = false;
            SanPham sanPham = new SanPham();
            using (var db = new MinistopDbContext())
            {
                using(var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        sanPham.TenSanPham = _sanPham.TenSanPham;
                        sanPham.LoaiSanPhamID = _sanPham.LoaiSanPhamID;
                        sanPham.ThuongHieu = _sanPham.ThuongHieu;
                        sanPham.HinhAnh = fileAnh;
                        sanPham.GiaBan = _sanPham.GiaBan;
                        sanPham.GiaNhap = _sanPham.GiaNhap;
                        sanPham.SoLuong = _sanPham.SoLuong;
                        sanPham.NgayThem = DateTime.Now;
                        sanPham.GhiChu = _sanPham.GhiChu;
                        sanPham.TinhTrang = true;
                        db.SanPhams.Add(sanPham);
                        db.SaveChanges();
                        trans.Commit();
                        result = true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
            }
            return result;
        }

        public bool CapNhat(SanPhamViewModel _sanPham)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var sanPham = db.SanPhams.Find(_sanPham.ID);
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        sanPham.TenSanPham = _sanPham.TenSanPham;
                        sanPham.LoaiSanPhamID = _sanPham.LoaiSanPhamID;
                        sanPham.ThuongHieu = _sanPham.ThuongHieu;
                        sanPham.GiaBan = _sanPham.GiaBan;
                        sanPham.GiaNhap = _sanPham.GiaNhap;
                        sanPham.SoLuong = _sanPham.SoLuong;
                        sanPham.NgayCapNhat = DateTime.Now;
                        sanPham.GhiChu = _sanPham.GhiChu;
                        sanPham.TinhTrang = true;
                        db.SaveChanges();
                        trans.Commit();
                        result = true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }
                return result;
            }
        }

        public bool Xoa(int id)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var sanPham = db.SanPhams.Find(id);
                sanPham.TinhTrang = false;
                sanPham.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool LoaiSanPham(LoaiSanPhamViewModel _loaiSP)
        {
            bool result = false;
            LoaiSanPham loaiSP = new LoaiSanPham();
            using (var db = new MinistopDbContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        loaiSP.TenLoai = _loaiSP.TenLoai;
                        db.LoaiSanPhams.Add(loaiSP);
                        db.SaveChanges();
                        trans.Commit();
                        result = true;
                    }catch(Exception)
                    {
                        trans.Rollback();                      
                    }
                }
            }
            return result;
        }
    }
}