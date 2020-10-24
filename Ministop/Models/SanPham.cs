namespace Ministop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDatHangs = new HashSet<ChiTietDatHang>();
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public int ID { get; set; }

        public int? LoaiSanPhamID { get; set; }

        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(50)]
        public string ThuongHieu { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public string GhiChu { get; set; }

        public bool? TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatHang> ChiTietDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
