using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class DatHangViewModel
    {
        public int ID { get; set; }

        public int NhanVienID { set; get; }

        public string TenNhanVien { get; set; }

        public int NhaCungCapID { set; get; }

        public string TenNCC { get; set; }

        public int SanPhamID { get; set; }
        public string TenSanpham { get; set; }

        public DateTime? NgayDat { get; set; }

        public decimal? TongTien { get; set; }

        public int SoLuong { get; set; }
        public decimal? GiaTien { get; set; }

    }
}