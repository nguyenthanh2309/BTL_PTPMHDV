using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public SanPham GetSanPhamByID(int id)
        {
            return _sanPhamBusiness.GetSanPhamByID(id);
        }
        [Route("getall")]
        [HttpGet]
        [Authorize]
        public List<SanPham> GetAllSanPham()
        {
            return _sanPhamBusiness.GetAllSanPham();
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create([FromForm] SanPham sp)
        {
            _sanPhamBusiness.Create(sp);
            return Ok("San pham da duoc tao thanh cong");
        }
        [Route("update")]
        [HttpPost]
        [Authorize]
        public void Update([FromBody] string json)
        {
            _sanPhamBusiness.Update(json);
        }
        [Route("delete/{id}")]
        [HttpPost]
        [Authorize]
        public void Delete(int id)
        {
            _sanPhamBusiness.Delete(id);
        }
    }
}
