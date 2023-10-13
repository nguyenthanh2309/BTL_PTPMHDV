using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepos : IUserRepos
    {
        private IDatabaseHelper _dbHelper;
        public UserRepos(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public TaiKhoan Login(string tenTk, string matKhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@tentk", tenTk,
                     "@matkhau", matKhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoan>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
