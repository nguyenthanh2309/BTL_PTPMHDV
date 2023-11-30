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
    public class NhaCCBusniess:INhaCCBusniess
    {
        private INhaCCRepos _res;
        
        public NhaCCBusniess(INhaCCRepos res)
        {
            _res = res;
        }
        public NhaCC GetNhaCCByID(int id)
        {
            return _res.GetNhaCCByID(id);
        }
        public List<NhaCC> GetAllNhaCC()
        {
            return _res.GetAllNhaCC();
        }
        public void Create(NhaCC nhacc)
        {
            _res.Create(nhacc);
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
