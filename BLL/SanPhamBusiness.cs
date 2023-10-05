using DAL;
using BLL;
using DTO;
using System.Reflection;

namespace BLL
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepos _res;
        public SanPhamBusiness(ISanPhamRepos res)
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
        public bool Update(string id, SanPham sp)
        {
            return _res.Update(id, sp);
        }

        public void Delete(string id) {
            _res.Delete(id);
        }

    }
}