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
            return Ok("Khach hang da duoc tao thanh cong");
        }
        [Route("update/{id}")]
        [HttpPut]
        public IActionResult Update(string id, [FromBody] KhachHang kh)
        {
            KhachHang kh_target = _khachHangBusiness.GetKhachHangByID(id);
            UtilFunctions.SetDefaultIfEmpty(kh, kh_target);
            var result = new
            {
                Message = "Thong tin khach hang da duoc cap nhat thanh cong",
                KhachHang = kh
            };
            _khachHangBusiness.Update(id, kh);
            return Ok(result);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            KhachHang target = _khachHangBusiness.GetKhachHangByID(id);
            if (target != null)
            {
                _khachHangBusiness.Delete(id);
                return Ok("Da xoa khach hang nay");
            }
            return NotFound("Khong tim thay khach hang nay");
        }
    }
}
