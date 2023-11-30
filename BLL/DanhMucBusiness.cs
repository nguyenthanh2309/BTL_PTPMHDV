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
    public class DanhMucBusiness:IDanhMucBusiness
    {
        private IDanhMucRepos _res;
        public DanhMucBusiness(IDanhMucRepos res)
        {
            _res = res;
        }

        public DanhMuc GetDanhMucByID(int id)
        {
            return _res.GetDanhMucByID(id); 
        }

        public List<DanhMuc> GetAllDanhMuc()
        {
            return _res.GetAllDanhMuc();
        }

        public void Create(DanhMuc muc)
        {
            _res.Create(muc);
        }

        public void Update(string json)
        {
            _res.Update(json);
        }

        public void Delete(int id) 
        {
            _res.Delete(id);
        }
    }
}
