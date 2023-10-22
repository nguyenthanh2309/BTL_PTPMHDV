using DTO;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("{id}")]
        public TaiKhoan GetTaiKhoanByID(string id)
        {
            return _taiKhoanBusiness.GetTaiKhoanByID(id);
        }
        [HttpPost]
        public ActionResult Create([FromBody] TaiKhoan tk)
        {
            _taiKhoanBusiness.Create(tk);
            return Ok("Tai khoan da duoc tao thanh cong");
        }
        [HttpPut]
        public ActionResult Update(string id, [FromBody] TaiKhoan tk)
        {
            _taiKhoanBusiness.Update(id, tk);
            return Ok("Tai khoan da duoc cap nhat thanh cong");
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var target = _taiKhoanBusiness.GetTaiKhoanByID(id);
            if (target != null)
            {
                _taiKhoanBusiness.Delete(id);
                return Ok("Da xoa tai khoan nay");
            }
            return NotFound("Khong tim thay tai khoan nay");
        }
    }
}
