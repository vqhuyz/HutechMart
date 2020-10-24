namespace Ministop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string QuyenHan { get; set; }

        public virtual DangNhap DangNhap { get; set; }
    }
}
