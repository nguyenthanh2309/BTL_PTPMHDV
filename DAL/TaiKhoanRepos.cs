using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoanRepos : ITaiKhoanRepos
    {
        private IDatabaseHelper _dbHelper;
        public TaiKhoanRepos(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public TaiKhoan GetTaiKhoanByID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_tk_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(TaiKhoan tk)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_tk",
                "@id", tk.ID,
                "@tentk", tk.TenTK,
                "@matkhau", tk.MatKhau,
                "@email", tk.Email,
                "@loaitkid", tk.LoaiTaiKhoanID
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(string id, TaiKhoan tk)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_tk",
                "@id", id,
                "@tentk", tk.TenTK,
                "@matkhau", tk.MatKhau,
                "@email", tk.Email,
                "@loaitkid", tk.LoaiTaiKhoanID
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_delete_tk",
                     "@id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
