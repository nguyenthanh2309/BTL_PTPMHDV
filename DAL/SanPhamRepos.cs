using DTO;
using System.Reflection;

namespace DAL
{
    public class SanPhamRepos:ISanPhamRepos
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepos(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public object GetSanPhamByID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_san_pham_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create (SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_san_pham",
                "@id", sp.ID,
                "@tensp", sp.TenSP,
                "@phanloaiid", sp.PhanLoaiID,
                "@nhaccid", sp.NhaCCID,
                "@gia", sp.Gia,
                "@soluong", sp.SoLuong,
                "@vatlieu", sp.VatLieu,
                "@kichthuoc", sp.KichThuoc
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
        public bool Update(string id, SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_san_pham",
                "@id", id,
                "@tensp", sp.TenSP,
                "@phanloaiid", sp.PhanLoaiID,
                "@nhaccid", sp.NhaCCID,
                "@gia", sp.Gia,
                "@soluong", sp.SoLuong,
                "@vatlieu", sp.VatLieu,
                "@kichthuoc", sp.KichThuoc
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
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_delete_san_pham",
                     "@id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
