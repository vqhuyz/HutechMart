using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface INhanVienService
    {
        IEnumerable<NhanVienViewModel> GetAll(int page, int pagesize);
        NhanVienViewModel GetById(int id);
        bool ThemMoi(NhanVienViewModel nhanVien);
        bool CapNhat(NhanVienViewModel nhanVien);
        bool Xoa(int id);
        bool DoiMatKhau(int id, string matKhauCu, string matKhauMoi);

        bool CapNhatThongTin(NhanVienViewModel nhanVien);

        bool KichHoat(int id);
    }
}
