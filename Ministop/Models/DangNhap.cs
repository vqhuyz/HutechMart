namespace Ministop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DangNhap")]
    public partial class DangNhap
    {
        [Key]
        public int NhanVienID { get; set; }

        public int? PhanQuyenID { get; set; }

        [StringLength(20)]
        public string TaiKhoan { get; set; }

        [StringLength(32)]
        public string MatKhau { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
