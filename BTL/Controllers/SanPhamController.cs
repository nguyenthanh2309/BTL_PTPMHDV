using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;

namespace BTL.Controllers
{
    [Route("api/[controller]")]
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
        public SanPham Create([FromBody] SanPham sp)
        {
            _sanPhamBusiness.Create(sp);
            return sp;
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _sanPhamBusiness.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Not a valid id");
            }
        }
    }
}
