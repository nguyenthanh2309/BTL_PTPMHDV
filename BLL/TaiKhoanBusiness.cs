using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBusiness : ITaiKhoanBusiness
    {
        private ITaiKhoanRepos _res;
        public TaiKhoanBusiness(ITaiKhoanRepos res)
        {
            _res = res;
        }
        public TaiKhoan GetTaiKhoanByID(string id)
        {
            return _res.GetTaiKhoanByID(id);
        }
        public bool Create(TaiKhoan tk)
        {
            return _res.Create(tk);
        }
        public bool Update(string id, TaiKhoan tk)
        {
            return _res.Update(id, tk);
        }

        public void Delete(string id)
        {
            _res.Delete(id);
        }
    }
}
