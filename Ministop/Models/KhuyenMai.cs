namespace Ministop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
