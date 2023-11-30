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
        [Authorize]
        public TaiKhoan GetTaiKhoanByID(int id)
        {
            return _taiKhoanBusiness.GetTaiKhoanByID(id);
        }
        [HttpGet("getall")]
        [Authorize]
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return _taiKhoanBusiness.GetAllTaiKhoan();
        }
        [Route("create")]
        [HttpPost]
        [Authorize]
        public ActionResult Create([FromForm] TaiKhoan tk)
        {
            _taiKhoanBusiness.Create(tk);
            return Ok("Tai khoan da duoc tao thanh cong");
        }
        [HttpPost("update")]
        [Authorize]
        public void Update([FromBody] string json)
        {
            _taiKhoanBusiness.Update(json);
        }
        [HttpPost("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _taiKhoanBusiness.Delete(id);
        }
    }
}
