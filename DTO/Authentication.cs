using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Authentication
    {
        [Required]
        public string TenTk { get; set; }

        [Required]
        public string MatKhau { get; set; }

        public class AppSettings
        {
            public string Secret { get; set; }

        }
    }
}
