using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        [Authorize]
        public KhachHang GetKhachHangByID(int id)
        {
            return _khachHangBusiness.GetKhachHangByID(id);
        }
        [Route("getall")]
        [HttpGet]
        [Authorize]
        public List<KhachHang> GetAllKhachHang()
        {
            return _khachHangBusiness.GetAllKhachHang();
        }
        [HttpPost("create")]
        [Authorize]
        public ActionResult Create([FromForm] KhachHang kh)
        {
            _khachHangBusiness.Create(kh);
            return Ok("Khach hang da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPost]
        [Authorize]
        public void Update([FromBody] JsonElement json)
        {
            _khachHangBusiness.Update(json.ToString());
        }
        [HttpPost("delete")]
        [Authorize]
        public void Delete(int id)
        {
            _khachHangBusiness.Delete(id);
        }
    }
}
