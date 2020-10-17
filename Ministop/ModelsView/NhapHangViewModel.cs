using Ministop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class NhapHangViewModel
    {
        // Lấy giỏ hàng từ Session
        public static NhapHangViewModel Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as NhapHangViewModel;
                // Nếu chưa có giỏ hàng trong session -> tạo mới và lưu vào session
                if (cart == null)
                {
                    cart = new NhapHangViewModel();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }
        //Download source code tại Sharecode.vn
        // Chứa các mặt hàng đã chọn
        public List<SanPham> Items = new List<SanPham>();

        public void Add(int id)
        {
            try // tìm thấy trong giỏ -> tăng số lượng lên 1
            {
                var item = Items.Single(i => i.ID == id);
                item.SoLuong++;
            }
            catch // chưa có trong giỏ -> truy vấn CSDL và bỏ vào giỏ
            {
                var db = new MinistopDbContext();
                var item = db.SanPhams.Find(id);
                item.SoLuong = 1;
                Items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var item = Items.Single(i => i.ID == id);
            Items.Remove(item);
        }

        public void Update(int id, int newQuantity)
        {
            var item = Items.Single(i => i.ID == id);
            item.SoLuong = newQuantity;
        }

        public void Clear()
        {
            Items.Clear();
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public double Total
        {
            get
            {
                return Items.Sum(p =>
                    (double)p.GiaBan * p.SoLuong);
            }
        }

    }
}