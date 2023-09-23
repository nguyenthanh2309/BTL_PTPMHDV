using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public partial interface ISanPhamRepository
    {
        SanPham GetSanPhamByID(string id);
        bool Create (SanPham sanPham);
        bool Update (SanPham sanPham);
    }
}
