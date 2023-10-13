using DTO;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace API.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _taiKhoanBusiness;
        public TaiKhoanController(ITaiKhoanBusiness taiKhoanBusiness)
        {
            _taiKhoanBusiness = taiKhoanBusiness;
        }
        [Route("getbyid/{id}")]
        [HttpGet]
        public TaiKhoan GetTaiKhoanByID(string id)
        {
            return _taiKhoanBusiness.GetTaiKhoanByID(id);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] TaiKhoan tk)
        {
            _taiKhoanBusiness.Create(tk);
            return Ok("Tai khoan da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update(string id, [FromBody] TaiKhoan tk)
        {
            TaiKhoan tk_target = _taiKhoanBusiness.GetTaiKhoanByID(id);
            UtilFunctions.SetDefaultIfEmpty(tk, tk_target);
            _taiKhoanBusiness.Update(id, tk);
            return Ok("Tai khoan da duoc cap nhat thanh cong");
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            TaiKhoan target = _taiKhoanBusiness.GetTaiKhoanByID(id);
            if (target != null)
            {
                _taiKhoanBusiness.Delete(id);
                return Ok("Da xoa tai khoan nay");
            }
            return BadRequest("Co loi xay ra");
        }
    }
}
