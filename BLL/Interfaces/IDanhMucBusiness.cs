using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IDanhMucBusiness
    {
        DanhMuc GetDanhMucByID(int ID);
        List<DanhMuc> GetAllDanhMuc();
        void Create(DanhMuc dm);
        void Update(string json);
        void Delete(int ID);
    }
}
