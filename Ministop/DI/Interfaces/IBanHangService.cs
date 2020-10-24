using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface IBanHangService
    {
        int BanHang(int nhanVienID, int? khachHangID, int thueVAT, double tongTien);

        bool ChiTiet(int hoaDonID, int sanPhamID, int soLuong, double giaBan);

        SanPhamViewModel LaySanPham(int Id);

        int LayMaKhachHang(string soDT);

        int VAT();
        bool KiemTraSoluong(List<SanPhamViewModel> lstSanPham);
    }
}
