using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public string ID { get; set; }
        public string? TenSP { get; set; }
        public string? PhanLoaiID { get; set; }
        public string NhaCCID { set; get; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string? VatLieu { get; set; }
        public string? KichThuoc { get; set; }
    }
}
