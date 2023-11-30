using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface INhaCCBusniess
    {
        NhaCC GetNhaCCByID(int ID);
        List<NhaCC> GetAllNhaCC();
        void Create(NhaCC nhacc);
        void Update(string json);
        void Delete(int ID);
    }
}
