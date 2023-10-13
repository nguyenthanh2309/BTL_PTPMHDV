using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public partial interface IKhachHangBusiness
    {
        KhachHang GetKhachHangByID(string id);
        void Create(KhachHang kh);
        void Update(string id, KhachHang kh);
        void Delete(string id); 
    }
}
