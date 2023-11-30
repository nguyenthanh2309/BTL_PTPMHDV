using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public int ID { get; set; }
        public DateTime NgayTao { get { return DateTime.MaxValue; } set { value = DateTime.MaxValue; } }
        public DateTime NgayThanhToan { get { return DateTime.MaxValue; } set { value = DateTime.MaxValue; } }
        public string TrangThai { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public List<ChiTietHoaDon> json_list_chitiethoadon { get; set; }
    }

    public class ChiTietHoaDon
    {
        public int HoaDonID { get; set; }
        public string SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public int TongGia { get; set; }
        public int Status { get; set; }
    }
}
