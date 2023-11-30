using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interfaces
{
    public partial interface IDanhMucRepos
    {
        DanhMuc GetDanhMucByID(int ID);
        List<DanhMuc> GetAllDanhMuc();
        void Create(DanhMuc dm);
        void Update(string json);
        void Delete(int ID);
    }
}
