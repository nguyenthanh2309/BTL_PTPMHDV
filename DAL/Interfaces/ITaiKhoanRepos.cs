using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ITaiKhoanRepos
    {
        TaiKhoan GetTaiKhoanByID(int id);
        List<TaiKhoan> GetAllTaiKhoan();
        void Create(TaiKhoan tk);
        void Update(string json);
        void Delete(int id);
    }
}
