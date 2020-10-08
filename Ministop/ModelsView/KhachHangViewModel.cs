using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class KhachHangViewModel
    {
        public int ID { get; set; }

        public string TenKH { get; set; }

        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string SoCMND { get; set; }

        public string SoDT { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string Facebook { get; set; }

        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }

        public DateTime? NgayThamGia { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}