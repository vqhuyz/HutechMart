using System;

namespace Ministop.ModelsView
{
    public class NhanVienViewModel
    {
        public int ID { get; set; }

        public string TenNhanVien { get; set; }

        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string SoCMND { get; set; }

        public string SoDT { get; set; }

        public string Email { get; set; }

        public string HinhAnh { get; set; }

        public string DiaChi { get; set; }

        public string ChucVu { get; set; }

        public decimal? MucLuong { get; set; }

        public DateTime? NgayThamGia { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }

        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }

    }
}