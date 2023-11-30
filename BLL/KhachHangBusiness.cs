using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepos _res;
        public KhachHangBusiness(IKhachHangRepos res)
        {
            _res = res;
        }
        public KhachHang GetKhachHangByID(int id)
        {
            return _res.GetKhachHangByID(id);
        }
        public List<KhachHang> GetAllKhachHang()
        {
            return _res.GetAllKhachHang();
        }
        public void Create(KhachHang kh)
        {
            _res.Create(kh);
        }
        public void Update(KhachHang kh)
        {
            _res.Update(kh);
        }

        public void Delete(int id)
        {
            _res.Delete(id);
        }
    }
}
