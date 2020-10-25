using Ministop.DI.Implements;
using Ministop.ModelsView;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.Common
{
    public class DanhSachSanPham
    {
        public List<SanPhamViewModel> listSanPham = new List<SanPhamViewModel>();

        public static DanhSachSanPham DanhSach
        {
            get
            {
                var sanPham = HttpContext.Current.Session["SanPham"] as DanhSachSanPham;
                if (sanPham == null)
                {
                    sanPham = new DanhSachSanPham();
                    HttpContext.Current.Session["SanPham"] = sanPham;
                }
                return sanPham;
            }
        }

        public int SoLuong
        {
            get
            {
                return listSanPham.Sum(p => p.SoLuong);
            }
        }

        float Thue()
        {
            var banHang = new BanHangService();
            var vat = banHang.VAT();
            float thue = (float)vat / 100;
            return thue;
        }

        public double TongTien
        {                                                                                                                                                                                              
            get
            {
                return listSanPham.Sum(p => (p.SoLuong * (p.GiaBan - p.GiaBan * p.GiamGia/100)) + (p.SoLuong * (p.GiaBan - p.GiaBan * p.GiamGia / 100) * Thue()));
            }
        }

        public void ThemSanPham(int id)
        {
            var sanPham = listSanPham.Find(i => i.ID == id);
            if (sanPham != null)
            {
                sanPham.SoLuong++;
            }
            else
            {
                var sanPhamID = new SanPhamService();
                var item = sanPhamID.GetById(id);
                item.SoLuong = 1;
                listSanPham.Add(item);
            }
        }

        public void XoaSanPham(int id)
        {
            var item = listSanPham.Find(i => i.ID == id);
            listSanPham.Remove(item);
        }

        public void CapNhatSoLuong(int id, int soLuong)
        {
            var item = listSanPham.Find(i => i.ID == id);
            item.SoLuong = soLuong;
        }

        public void XoaHet()
        {
            listSanPham.Clear();
        }
    }
}