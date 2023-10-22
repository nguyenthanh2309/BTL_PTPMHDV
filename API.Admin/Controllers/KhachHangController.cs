using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _khachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _khachHangBusiness = khachHangBusiness;
        }
        [Route("{id}")]
        [HttpGet]
        public KhachHang GetKhachHangByID(string id)
        {
            return _khachHangBusiness.GetKhachHangByID(id);
        }
        [HttpPost]
        public ActionResult Create([FromBody] KhachHang kh)
        {
            _khachHangBusiness.Create(kh);
            return Ok("Khach hang da duoc tao thanh cong");
        }
        [HttpPut]
        public ActionResult Update(string id, [FromBody] KhachHang kh)
        {
            _khachHangBusiness.Update(id, kh);
            return Ok("Thong tin khach hang da duoc cap nhat thanh cong");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            _khachHangBusiness.Delete(id);
            var target = _khachHangBusiness.GetKhachHangByID(id);
            if (target == null)
            {
                return Ok("Da xoa khach hang nay");
            }
            return NotFound("Khong tim thay khach hang nay");
        }
    }
}
