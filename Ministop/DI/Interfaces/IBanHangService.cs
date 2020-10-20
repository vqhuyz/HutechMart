using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministop.DI.Interfaces
{
    public interface IBanHangService
    {
        int BanHang(int nhanVienID, int? khachHangID, int thueVAT, double tongTien);
        bool ChiTiet(int hoaDonID, int sanPhamID, int soLuong, decimal giaBan);

        int LayMaKhachHang(string soDT);

        int VAT();
    }
}
