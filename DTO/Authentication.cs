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
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public class AppSettings
        {
            public string Access { get; set; }
        }
    }
}
