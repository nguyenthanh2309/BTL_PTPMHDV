using DTO;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok("San pham da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update(string id, [FromBody] TaiKhoan tk)
        {
            _taiKhoanBusiness.Update(id, tk);
            return Ok("San pham da duoc cap nhat thanh cong");
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            TaiKhoan target = _taiKhoanBusiness.GetTaiKhoanByID(id);
            if (target != null)
            {
                _taiKhoanBusiness.Delete(id);
                return Ok();
            }
            return BadRequest("Co loi xay ra.");
        }
    }
}
