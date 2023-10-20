using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string ID { get; set; }
        public string TrangThai { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public List<ChiTietHoaDon> json_list_chitiethoadon { get; set; }
    }

    public class ChiTietHoaDon
    {
        public string ID { get; set; }
        public string HoaDonID { get; set; }
        public string SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public int TongGia { get; set; }
        public int Status { get; set; }
    }
}
