using Dapper;
using Ministop.Common;
using Ministop.DI.Interfaces;
using Ministop.ModelsView;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ministop.DI.Implements
{
    public class HoaDonService : IHoaDonService
    {
        public IEnumerable<HoaDonViewModel> GetAll(int page, int pagesize)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<HoaDonViewModel>("sp_GetAll_HoaDon", commandType: CommandType.StoredProcedure).ToPagedList(page, pagesize);
            }
        }

        public IEnumerable<ChiTietHoaDonViewModel> GetById(int ID)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.Query<ChiTietHoaDonViewModel>("sp_GetById_HoaDon", new { id = ID }, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ChiTietHoaDonViewModel LaySanPham(int ID)
        {
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                return connection.QueryFirstOrDefault<ChiTietHoaDonViewModel>("sp_GetById_HoaDon", new { id = ID }, commandType: CommandType.StoredProcedure);
            }
        }

        public bool TraHang(int sanPhamID, int hoaDonID, int soLuong)
        {
            bool result = true;
            using (var connection = new SqlConnection(ConnectionS.connectionString))
            {
                var traHang = connection.Execute("sp_TraHang_HoaDon", new
                {
                    sanphamID = sanPhamID,
                    hoadonID = hoaDonID,
                    soluong = soLuong
                }, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}