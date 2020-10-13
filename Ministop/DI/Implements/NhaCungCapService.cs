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
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var themMoi = connection.Execute("sp_ThemMoi_NhaCungCap", new
                    {
                        tenNCC = _nhaCungCap.TenNCC,
                        soDT = _nhaCungCap.SoDT,
                        diaChi = _nhaCungCap.DiaChi,
                        email = _nhaCungCap.Email,
                        congTy = _nhaCungCap.CongTy,
                        maSoThue = _nhaCungCap.MaSoThue,
                        ngayThamGia = DateTime.Now,
                        ghiChu = _nhaCungCap.GhiChu,
                    }, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                    result = false;
                }
            }

            return result;
        }


        public bool CapNhat(NhaCungCapViewModel _nhaCungCap)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                try
                {
                    var capNhat = connection.Execute("sp_CapNhat_NhaCungCap", new
                    {
                        id = _nhaCungCap.ID,
                        tenNCC = _nhaCungCap.TenNCC,
                        soDT = _nhaCungCap.SoDT,
                        diaChi = _nhaCungCap.DiaChi,
                        email = _nhaCungCap.Email,
                        congTy = _nhaCungCap.CongTy,
                        maSoThue = _nhaCungCap.MaSoThue,
                        ngayCapNhat = DateTime.Now,
                        ghiChu = _nhaCungCap.GhiChu,
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
                var xoa = connection.Execute("sp_Xoa_NhaCungCap", new { Id = id, ngayCapNhat = DateTime.Now}, commandType: CommandType.StoredProcedure);
                result = true;
            }
            return result;
        }
    }
}