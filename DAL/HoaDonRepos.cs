using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonRepos : IHoaDonRepos
    {
        public IDatabaseHelper _dbHelper;
        public HoaDonRepos(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public HoaDon GetHoaDonByID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_hoa_don_by_id",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDon>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Create(HoaDon hd)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_hoa_don",
                "@id", hd.ID,
                "@ngaytao", hd.NgayTao,
                "@ngaythanhtoan", hd.NgayThanhToan,
                "@trangthai", hd.TrangThai,
                "@tenkh", hd.TenKH,
                "@sdt", hd.SDT,
                "@diachi", hd.DiaChi,
                "@json_list_chitiethoadon", hd.json_list_chitiethoadon != null ? MessageConvert.SerializeObject(hd.json_list_chitiethoadon) : null);
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

        public void Update(HoaDon hd)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_hoa_don",
                "@trangthai", hd.TrangThai,
                "@hoadonid", hd.ID,
                "@tenkh", hd.TenKH,
                "@sdt", hd.SDT,
                "@diachi", hd.DiaChi,
                "@json_list_chitiethoadon", hd.json_list_chitiethoadon != null ? MessageConvert.SerializeObject(hd.json_list_chitiethoadon) : null);
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

        public void Delete(int id) {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_delete_hoa_don",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
