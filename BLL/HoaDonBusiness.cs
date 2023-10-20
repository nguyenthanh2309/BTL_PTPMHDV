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
    public class HoaDonBusiness:IHoaDonBusiness
    {
        private IHoaDonRepos _res;
        public HoaDonBusiness(IHoaDonRepos res)
        {
            _res = res;
        }

        public HoaDon GetHoaDonByID(string id)
        {
            return _res.GetHoaDonByID(id);
        }

        public void Create(HoaDon hd)
        {
            _res.Create(hd);
        }

        public void Update(HoaDon hd)
        {
            _res.Update(hd);
        }
        public void Delete(string id)
        {
            _res.Delete(id);
        }
    }
}
