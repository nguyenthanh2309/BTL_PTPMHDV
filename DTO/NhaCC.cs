using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCC
    {
        [Key] public int ID { get; set; }  
        public string TenNhaCC { get; set; }    
        public string SDT { get; set; }
        public string DiaChi { get; set; }  
        public string Email { get; set; }   
    }
}
