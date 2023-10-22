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
        object GetSanPhamByID(string id);
        bool Create(SanPham sp);
        bool Update(SanPham sp);
        void Delete(string id);
    }
}
