using System;

namespace Ministop.ModelsView
{
    public class HoaDonViewModel
    {
        public int ID { get; set; }
        public DateTime? NgayMua { get; set; }
        public string TenNhanVien { get; set; }
        public double TongTien { get; set; }
    }
}