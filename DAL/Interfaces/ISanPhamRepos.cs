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
        SanPham GetSanPhamByID(int id);
        List<SanPham> GetAllSanPham();
        void Create(SanPham sp);
        void Update(string json);
        void Delete(int id);
    }
}
