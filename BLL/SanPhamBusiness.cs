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
        public bool Create(SanPham kh)
        {
            return _res.Create(kh);
        }
        public bool Update(string id, SanPham kh)
        {
            return _res.Update(id, kh);
        }

        public void Delete(string id) {
            _res.Delete(id);
        }

    }
}