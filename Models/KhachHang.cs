using System;
using System.Collections.Generic;

#nullable disable

namespace WebBanDienThoai.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string Diachi { get; set; }
        public DateTime Ngaysinh { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
