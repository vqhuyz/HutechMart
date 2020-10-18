using Ministop.DI.Implements;
using Ministop.ModelsView;
using System;
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
                // Nếu chưa có giỏ hàng trong session -> tạo mới và lưu vào session
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
                return listSanPham.Count;
            }
        }

        public double TongTien
        {
            get
            {
                return listSanPham.Sum(p => (double)p.GiaBan * p.SoLuong);
            }
        }

        public void ThemSanPham(int id)
        {
            // tìm thấy trong giỏ -> tăng số lượng lên 1
            var sanPham = listSanPham.Find(i => i.ID == id);
            if (sanPham != null)
            {
                sanPham.SoLuong++;
            }
            else // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
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