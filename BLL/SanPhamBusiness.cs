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
        public object GetSanPhamByID(string id)
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

        public void Delete(string id) {
            _res.Delete(id);
        }

    }
}