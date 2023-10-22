using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;

namespace API.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("{id}")]
        [HttpGet]
        public object GetSanPhamByID(string id)
        {
            return _sanPhamBusiness.GetSanPhamByID(id);
        }
        [HttpPost]
        public ActionResult Create([FromBody] SanPham sp)
        {
            _sanPhamBusiness.Create(sp);
            return Ok("San pham da duoc tao thanh cong");
        }
        [HttpPut]
        public ActionResult Update([FromBody] SanPham sp)
        {
            _sanPhamBusiness.Update(sp);
            return Ok("San pham da duoc cap nhat thanh cong");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var target = _sanPhamBusiness.GetSanPhamByID(id);
            if (target != null) { 
                _sanPhamBusiness.Delete(id);
                return Ok("Da xoa san pham nay");
            }
            return NotFound("Khong tim thay san pham nay");
        }
    }
}
