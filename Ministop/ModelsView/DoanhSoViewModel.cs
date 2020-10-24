using System.Collections.Generic;

namespace Ministop.ModelsView
{
    public class DoanhSoViewModel
    {
        public List<Dulieu> dulieu { get; set; }
    }
    public class DoanhSoView
    {
        public DoanhSoView(double doanhso, string ngay)
        {
            this.ngay = ngay;
            this.doanhso = doanhso;
        }
        public string ngay { get; set; }
        public double doanhso { get; set; }
    }
    public class Dulieu
    {
        public List<DoanhSoView> data { get; set; }
    }

}