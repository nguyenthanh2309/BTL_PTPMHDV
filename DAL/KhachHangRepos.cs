using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangRepos : IKhachHangRepos
    {
        private IDatabaseHelper _dbHelper;
        public KhachHangRepos(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public KhachHang GetKhachHangByID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_khach_hang_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHang>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Create(KhachHang kh)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_khach_hang",
                "@id", kh.ID,
                "@tenkh", kh.TenKH,
                "@sdt", kh.SDT,
                "@diachi", kh.DiaChi
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(string id, KhachHang kh)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_khach_hang",
                "@id", id,
                "@tenkh", kh.TenKH,
                "@sdt", kh.SDT,
                "@diachi", kh.DiaChi
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_delete_khach_hang",
                     "@id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
