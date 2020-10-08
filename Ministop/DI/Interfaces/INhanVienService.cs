using Ministop.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ministop.DI.Interfaces
{
    public interface INhanVienService
    {
        IEnumerable<NhanVienViewModel> GetAll(string search, int page, int pagesize);
        NhanVienViewModel GetById(int id);
        bool ThemMoi(NhanVienViewModel nhanVien, string fileAnh);
        bool CapNhat(NhanVienViewModel nhanVien);
        bool Xoa(int id);
        bool DoiMatKhau(int id, string matKhauCu, string matKhauMoi);
    }
}
