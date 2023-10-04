using DAL;
using BLL;
using DTO;
using System.Reflection;

namespace BLL
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPham GetSanPhamByID(string id)
        {
            return _res.GetSanPhamByID(id);
        }
        public bool Create(SanPham sp)
        {
            return _res.Create(sp);
        }
        public bool Update(SanPham sp)
        {
            return _res.Update(sp);
        }

        public SanPham Delete(string id) {
            return _res.Delete(id);
        }

    }
}