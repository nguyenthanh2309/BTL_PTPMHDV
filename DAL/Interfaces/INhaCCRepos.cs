using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface INhaCCRepos
    {
        NhaCC GetNhaCCByID(int ID);
        List<NhaCC> GetAllNhaCC();
        void Create(NhaCC nhacc);
        void Update(NhaCC nhacc);
        void Delete(int ID);
    }
}
