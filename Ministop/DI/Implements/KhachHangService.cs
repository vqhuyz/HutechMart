using Dapper;
using Ministop.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ministop.Common;
using Ministop.ModelsView;
using Ministop.Models;
using PagedList;

namespace Ministop.DI.Implements
{
    public class KhachHangService : IKhachHangService
    {
        public IEnumerable<KhachHangViewModel> GetAll(string search, int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    var khachHang = connection.Query<KhachHangViewModel>("sp_Search_KhachHang", new { SoDT = search, TenKH = search }, commandType: CommandType.StoredProcedure);
                    return khachHang.ToPagedList(page, pagesize);
                }
                else
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
            bool result = false;
            KhachHang khachHang = new KhachHang();
            using (var db = new MinistopDbContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        khachHang.TenKH = _khachHang.TenKH;
                        khachHang.DiaChi = _khachHang.DiaChi;
                        khachHang.Email = _khachHang.Email.Trim();
                        khachHang.Facebook = _khachHang.Facebook;
                        khachHang.GhiChu = _khachHang.GhiChu;
                        khachHang.GioiTinh = _khachHang.GioiTinh;
                        khachHang.NgaySinh = _khachHang.NgaySinh;
                        khachHang.SoCMND = _khachHang.SoCMND.Trim();
                        khachHang.SoDT = _khachHang.SoDT.Trim();
                        khachHang.NgayThamGia = DateTime.Now;
                        khachHang.TinhTrang = true;
                        db.KhachHangs.Add(khachHang);
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
                var khachHang = db.KhachHangs.Find(id);
                khachHang.TinhTrang = false;
                khachHang.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool CapNhat(KhachHangViewModel _khachHang)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var khachHang = db.KhachHangs.Find(_khachHang.ID);
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        khachHang.TenKH = _khachHang.TenKH;
                        khachHang.DiaChi = _khachHang.DiaChi;
                        khachHang.Email = _khachHang.Email.Trim();
                        khachHang.Facebook = _khachHang.Facebook;
                        khachHang.GhiChu = _khachHang.GhiChu;
                        khachHang.GioiTinh = _khachHang.GioiTinh;
                        khachHang.NgaySinh = _khachHang.NgaySinh;
                        khachHang.SoCMND = _khachHang.SoCMND.Trim();
                        khachHang.SoDT = _khachHang.SoDT.Trim();
                        khachHang.NgayCapNhat = DateTime.Now;
                        khachHang.TinhTrang = true;
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
    }
}
