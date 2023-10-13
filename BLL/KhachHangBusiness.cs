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
        public KhachHang GetKhachHangByID(string id)
        {
            return _res.GetKhachHangByID(id);
        }
        public void Create(KhachHang kh)
        {
            _res.Create(kh);
        }
        public void Update(string id, KhachHang kh)
        {
            _res.Update(id, kh);
        }

        public void Delete(string id)
        {
            _res.Delete(id);
        }
    }
}
