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
        public SanPham GetSanPhamByID(int id)
        {
            return _res.GetSanPhamByID(id);
        }

        public List<SanPham> GetAllSanPham()
        {
            return _res.GetAllSanPham();
        }
        public void Create(SanPham sp)
        {
            _res.Create(sp);
        }
        public void Update(string json)
        {
            _res.Update(json);
        }

        public void Delete(int id) {
            _res.Delete(id);
        }

    }
}