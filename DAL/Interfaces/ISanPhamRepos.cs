using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial interface ISanPhamRepos
    {
        object GetSanPhamByID(string id);
        List<SanPham> GetAllSanPham();
        bool Create(SanPham sp);
        bool Update(SanPham sp);
        void Delete(string id);
    }
}
