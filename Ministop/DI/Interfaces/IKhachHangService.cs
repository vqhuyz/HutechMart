using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface IKhachHangService
    {
        IEnumerable<KhachHangViewModel> GetAll(int page, int pagesize);
        KhachHangViewModel GetById(int id);
        bool ThemMoi(KhachHangViewModel khachHang);
        bool CapNhat(KhachHangViewModel khachHang);
        bool Xoa(int id);
        bool KichHoat(int id);
    }
}
