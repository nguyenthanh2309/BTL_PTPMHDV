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
        KhachHang GetKhachHangByID(int id);
        List<KhachHang> GetAllKhachHang();
        void Create(KhachHang kh);
        void Update(string json);
        void Delete(int id); 
    }
}
