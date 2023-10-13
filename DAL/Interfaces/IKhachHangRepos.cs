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
        KhachHang GetKhachHangByID(string id);
        void Create(KhachHang kh);
        void Update(string id, KhachHang kh);
        void Delete(string id);
    }
}
