using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiTaiKhoan
    {
        [Key] public string ID { get; set; }
        public string TenLoaiTK { get; set; }
    }
}
