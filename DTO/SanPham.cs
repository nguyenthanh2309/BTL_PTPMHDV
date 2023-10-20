using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public PhanLoai PhanLoai { get; set; }
        public string NhaCCID { set; get; }
        public NhaCC NhaCC { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public string? VatLieu { get; set; }
        public string? KichThuoc { get; set; }
    }
}
