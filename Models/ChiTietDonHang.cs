using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDienThoai.Models
{
    public partial class ChiTietDonHang
    {
        public int MaCtdh { get; set; }
        public int MaDh { get; set; }
        public int MaSp { get; set; }
        public int TongTien { get; set; }
        public int Ngaygiao { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
