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
    public class NhaCungCapService : INhaCungCapService
    {
        public IEnumerable<NhaCungCapViewModel> GetAll(string search, int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                if (!string.IsNullOrEmpty(search))
                {
                    var nhaCungCap = connection.Query<NhaCungCapViewModel>("sp_Search_NhaCungCap", new { tenNCC = search, email = search }, commandType: CommandType.StoredProcedure);
                    return nhaCungCap.ToPagedList(page, pagesize);
                }
                else
                    return connection.Query<NhaCungCapViewModel>("sp_GetAll_NhaCungCap", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public NhaCungCapViewModel GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<NhaCungCapViewModel>("sp_GetById_NhaCungCap", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool ThemMoi(NhaCungCapViewModel _nhaCungCap)
        {
            bool result = false;
            NhaCungCap nhaCungCap = new NhaCungCap();
            using (var db = new MinistopDbContext())
            {
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        nhaCungCap.TenNCC = _nhaCungCap.TenNCC;
                        nhaCungCap.SoDT = _nhaCungCap.SoDT.Trim();
                        nhaCungCap.DiaChi = _nhaCungCap.DiaChi;
                        nhaCungCap.Email = _nhaCungCap.Email.Trim();
                        nhaCungCap.CongTy = _nhaCungCap.CongTy;
                        nhaCungCap.MaSoThue = _nhaCungCap.MaSoThue.Trim();
                        nhaCungCap.NgayThamGia = DateTime.Now;
                        nhaCungCap.GhiChu = _nhaCungCap.GhiChu;
                        nhaCungCap.TinhTrang = true;
                        db.NhaCungCaps.Add(nhaCungCap);
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


        public bool CapNhat(NhaCungCapViewModel _nhaCungCap)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var nhaCungCap = db.NhaCungCaps.Find(_nhaCungCap.ID);
                using (var trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        nhaCungCap.TenNCC = _nhaCungCap.TenNCC;
                        nhaCungCap.SoDT = _nhaCungCap.SoDT.Trim();
                        nhaCungCap.DiaChi = _nhaCungCap.DiaChi;
                        nhaCungCap.Email = _nhaCungCap.Email.Trim();
                        nhaCungCap.CongTy = _nhaCungCap.CongTy;
                        nhaCungCap.MaSoThue = _nhaCungCap.MaSoThue.Trim();
                        nhaCungCap.GhiChu = _nhaCungCap.GhiChu;
                        nhaCungCap.NgayCapNhat = DateTime.Now;
                        nhaCungCap.TinhTrang = true;
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

        public bool Xoa(int id)
        {
            bool result = false;
            using (var db = new MinistopDbContext())
            {
                var nhaCungCap = db.NhaCungCaps.Find(id);
                nhaCungCap.TinhTrang = false;
                nhaCungCap.NgayCapNhat = DateTime.Now;
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}