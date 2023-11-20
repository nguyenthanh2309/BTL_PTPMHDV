using BLL;
using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoaDonBusiness;
        public HoaDonController(IHoaDonBusiness hoaDonBusiness)
        {
            _hoaDonBusiness = hoaDonBusiness;
        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult GetSanPhamByID(string id) {
            var result = _hoaDonBusiness.GetHoaDonByID(id);
            if (result == null)
            {
                return NotFound("Khong tim thay hoa don nay");
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Create([FromBody] HoaDon hd)
        {
            _hoaDonBusiness.Create(hd);
            return Ok("Thanh cong");
        }
        [HttpPut]
        [Authorize]
        public ActionResult Update([FromBody] HoaDon hd)
        {
            _hoaDonBusiness.Update(hd);
            return Ok("Thanh cong");
        }
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(string id)
        {
            var target = _hoaDonBusiness.GetHoaDonByID(id);
            if (target != null)
            {
                _hoaDonBusiness.Delete(id);
                return BadRequest("Xoa khong thanh cong");
            }
            return Ok("Xoa thanh cong");
        }
    }
}
