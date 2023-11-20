using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IUserBusiness
    {
        TaiKhoan Login(string tenTk, string matKhau);
        string SignUp(TaiKhoan tk);
    }
}
