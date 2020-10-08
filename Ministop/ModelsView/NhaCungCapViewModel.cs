using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class NhaCungCapViewModel
    {
        public int ID { get; set; }

        public string TenNCC { get; set; }

        public string SoDT { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        public string CongTy { get; set; }

        public string MaSoThue { get; set; }

        public DateTime? NgayThamGia { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }
    }
}