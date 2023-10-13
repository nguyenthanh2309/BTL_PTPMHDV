using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;
using Utils;

namespace BTL.Controllers
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
        [Route("/getbyid/{id}")]
        [HttpGet]
        public SanPham GetSanPhamByID(string id)
        {
            return _sanPhamBusiness.GetSanPhamByID(id);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] SanPham sp)
        {
            _sanPhamBusiness.Create(sp);
            return Ok("San pham da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update(string id, [FromBody] SanPham sp)
        {
            SanPham sp_target = _sanPhamBusiness.GetSanPhamByID(id);
            UtilFunctions.SetDefaultIfEmpty(sp, sp_target);
            _sanPhamBusiness.Update(id, sp);
            return Ok("San pham da duoc cap nhat thanh cong");
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
                SanPham target = _sanPhamBusiness.GetSanPhamByID(id);
                if (target != null) { 
                    _sanPhamBusiness.Delete(id);
                    return Ok("Da xoa san pham nay");
                }
            return BadRequest("Co loi xay ra");
        }
    }
}
