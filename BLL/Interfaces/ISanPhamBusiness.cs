using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial interface ISanPhamBusiness
    {
        SanPham GetSanPhamByID(string id);
        bool Create(SanPham sp);
        bool Update(string id, SanPham sp);
        void Delete(string id);
    }
}
