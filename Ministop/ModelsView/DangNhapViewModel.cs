﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ministop.ModelsView
{
    public class DangNhapViewModel
    {
        public int ID { get; }
        public string TenNhanVien { get; }
        public string ChucVu { get; }
        public string HinhAnh { get; }
        public int PhanQuyenID { get; }
    }
}