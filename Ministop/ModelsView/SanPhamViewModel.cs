using Ministop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class SanPhamViewModel
    {
        public int ID { get; set; }

        public int? LoaiSanPhamID { get; set; }

        public string TenSanPham { get; set; }

        public string ThuongHieu { get; set; }

        public string HinhAnh { get; set; }

        public decimal? GiaNhap { get; set; }

        public decimal? GiaBan { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayThem { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }
    }
}