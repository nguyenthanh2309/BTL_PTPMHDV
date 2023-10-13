﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        [Key] public string ID { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
    }
}