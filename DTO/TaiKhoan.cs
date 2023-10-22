using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {   
        public string ID { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string LoaiTaiKhoanID { get; set; }
        public string Token { get; set; }
    }
}
