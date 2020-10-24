using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface IHoaDonService
    {
        IEnumerable<HoaDonViewModel> GetAll(int page, int pagesize);
        IEnumerable<ChiTietHoaDonViewModel> GetById(int id);
        ChiTietHoaDonViewModel LaySanPham(int ID);
        bool TraHang(int sanPhamID, int hoaDonID, int soLuong);
    }
}
