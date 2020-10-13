using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministop.DI.Interfaces
{
    public interface INhaCungCapService
    {
        IEnumerable<NhaCungCapViewModel> GetAll(string search, int page, int pagesize);
        NhaCungCapViewModel GetById(int id);
        bool ThemMoi(NhaCungCapViewModel nhaCungCap);
        bool CapNhat(NhaCungCapViewModel nhaCungCap);
        bool Xoa(int id);
        bool KichHoat(int id);
    }
}
