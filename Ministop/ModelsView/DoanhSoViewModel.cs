using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class DoanhSoViewModel
    {
        public DoanhSoViewModel(double doanhso, string ngay)
        {
            this.DoanhSo = doanhso;
            this.Ngay = ngay;
        }
        public double DoanhSo { get; set; }
        public string Ngay { get; set; }
    }
}