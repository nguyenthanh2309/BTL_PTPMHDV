using BLL;
using BLL.Interfaces;
using DTO;
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
        [Route("get")]
        [HttpGet]
        public IActionResult GetSanPhamByID(string id) {
            var result = _hoaDonBusiness.GetHoaDonByID(id);
            if (result == null)
            {
                return NotFound("Khong tim thay hoa don nay");
            }
            return Ok(result);
        }
        [Route("post")]
        [HttpPost]
        public IActionResult Create(HoaDon hd)
        {
            _hoaDonBusiness.Create(hd);
            return Ok();
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update(HoaDon hd)
        {
            _hoaDonBusiness.Update(hd);
            return Ok("Thanh cong");
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _hoaDonBusiness.Delete(id);
            var hdToDelete = _hoaDonBusiness.GetHoaDonByID(id);
            if (hdToDelete != null)
            {
                return BadRequest("Xoa khong thanh cong");
            }
            return Ok("Xoa thanh cong");
        }
    }
}
