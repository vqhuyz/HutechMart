namespace Ministop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        public int SanPhamID { get; set; }

        public double? GiamGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaMoi { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
