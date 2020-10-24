using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface ISanPhamService
    {
        IEnumerable<SanPhamViewModel> GetAll(int page, int pagesize);
        IEnumerable<LoaiSanPhamViewModel> GetAll_LoaiSp();
        SanPhamViewModel GetById(int id);
        bool ThemMoi(SanPhamViewModel sanPham);
        bool CapNhat(SanPhamViewModel sanPham);
        bool Xoa(int id);
        bool LoaiSanPham(LoaiSanPhamViewModel loaiSP);
    }
}
