using Ministop.ModelsView;
using System.Collections.Generic;

namespace Ministop.DI.Interfaces
{
    public interface INhaCungCapService
    {
        IEnumerable<NhaCungCapViewModel> GetAll(int page, int pagesize);
        NhaCungCapViewModel GetById(int id);
        bool ThemMoi(NhaCungCapViewModel nhaCungCap);
        bool CapNhat(NhaCungCapViewModel nhaCungCap);
        bool Xoa(int id);
        bool KichHoat(int id);
    }
}
