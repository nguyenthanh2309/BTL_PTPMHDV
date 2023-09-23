using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanLoai
    {
        [Key] public int Id { get; set; }   
        public string TenPL { get; set; }
    }
}
