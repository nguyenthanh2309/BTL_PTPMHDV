using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IKhachHangRepos
    {
        KhachHang GetKhachHangByID(int id);
        List<KhachHang> GetAllKhachHang();
        void Create(KhachHang kh);
        void Update(KhachHang kh);
        void Delete(int id);
    }
}
