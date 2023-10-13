using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace API.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _khachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _khachHangBusiness = khachHangBusiness;
        }
        [Route("getbyid/{id}")]
        [HttpGet]
        public KhachHang GetKhachHangByID(string id)
        {
            return _khachHangBusiness.GetKhachHangByID(id);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] KhachHang kh)
        {
            _khachHangBusiness.Create(kh);
            return Ok("San pham da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update(string id, [FromBody] KhachHang kh)
        {
            KhachHang kh_target = _khachHangBusiness.GetKhachHangByID(id);
            UtilFunctions.SetDefaultIfEmpty(kh, kh_target);
            var result = new
            {
                Message = "San pham da duoc cap nhat thanh cong",
                KhachHang = kh
            };
            _khachHangBusiness.Update(id, kh);
            return Ok(result);
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            KhachHang target = _khachHangBusiness.GetKhachHangByID(id);
            if (target != null)
            {
                _khachHangBusiness.Delete(id);
                return Ok("Da xoa san pham nay");
            }
            return BadRequest("Co loi xay ra");
        }
    }
}
