using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITaiKhoanBusiness
    {
        TaiKhoan GetTaiKhoanByID(string id);
        bool Create(TaiKhoan tk);
        bool Update(string id, TaiKhoan tk);
        void Delete(string id);
    }
}
