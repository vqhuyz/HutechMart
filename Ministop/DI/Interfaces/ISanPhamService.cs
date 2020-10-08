using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministop.DI.Interfaces
{
    public interface ISanPhamService
    {
        IEnumerable<SanPhamViewModel> GetAll(string search, int page, int pagesize);
        IEnumerable<LoaiSanPhamViewModel> GetAll_LoaiSp();
        SanPhamViewModel GetById(int id);
        bool ThemMoi(SanPhamViewModel sanPham, string fileAnh);
        bool CapNhat(SanPhamViewModel sanPham);
        bool Xoa(int id);
        bool LoaiSanPham(LoaiSanPhamViewModel loaiSP);
    }
}
