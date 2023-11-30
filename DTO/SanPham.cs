using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public int ID { get; set; }
        public string? TenSP { get; set; }
        public int DanhMucID { get; set; }
        public int NhaCCID { get; set; }
        public string? TenDanhMuc { get; set; }
        public string? TenNhaCC { set; get; }
        public string KichThuoc { get; set; }
        public string VatLieu { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
    }
}
