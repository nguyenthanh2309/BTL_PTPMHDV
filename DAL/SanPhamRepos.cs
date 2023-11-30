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

        public SanPham GetSanPhamByID(int id)
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

        public List<SanPham> GetAllSanPham()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_san_pham");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return (List<SanPham>)dt.ConvertTo<SanPham>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Create (SanPham sp)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_san_pham",
                "@tensp", sp.TenSP,
                "@danhmucid", sp.DanhMucID,
                "@nhaccid", sp.NhaCCID,
                "@vatlieu", sp.VatLieu,
                "@kichthuoc", sp.KichThuoc,
                "@soluong", sp.SoLuong,
                "@gia", sp.Gia
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
        public void Update(string json)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_san_pham",
                "@json", json
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

        public void Delete(int id)
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
