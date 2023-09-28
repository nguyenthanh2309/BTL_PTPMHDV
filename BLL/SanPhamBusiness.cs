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
        public bool Create(SanPham model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPham model)
        {
            return _res.Update(model);
        }

    }
}