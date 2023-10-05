using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan
    {   
        [Key]
        public string ID { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        [ForeignKey("LoaiTaiKhoanID")]
        public string LoaiTaiKhoanID { get; set; }
        public LoaiTaiKhoan LoaiTaiKhoan { get; set; }
    }
}
