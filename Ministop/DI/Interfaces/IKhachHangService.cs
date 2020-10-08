using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministop.DI.Interfaces
{
    public interface IKhachHangService
    {
        IEnumerable<KhachHangViewModel> GetAll(string search, int page, int pagesize);
        KhachHangViewModel GetById(int id);
        bool ThemMoi(KhachHangViewModel khachHang);
        bool CapNhat(KhachHangViewModel khachHang);
        bool Xoa(int id);
    }
}
