using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace API.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _danhMucBusiness;

        public DanhMucController(IDanhMucBusiness danhMucBusiness)
        {
            _danhMucBusiness = danhMucBusiness;
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public DanhMuc GetDanhMucByID(int id)
        {
            return _danhMucBusiness.GetDanhMucByID(id);
        }

        [Route("getall")]
        [HttpGet]
        [Authorize]
        public List<DanhMuc> GetAllDanhMuc()
        {
            var listDanhMuc = _danhMucBusiness.GetAllDanhMuc();
            return listDanhMuc;
        }

        [Route("create")]        
        [HttpPost]
        [Authorize]
        public void Create([FromForm]DanhMuc dm)
        {
            _danhMucBusiness.Create(dm);
        }

        [Route("update")]
        [HttpPost]
        [Authorize]
        public void Update([FromBody]JsonElement json)
        {
            _danhMucBusiness.Update(json.ToString());
        }

        [Route("delete")]
        [HttpPost]
        [Authorize]
        public void Delete(int id)
        {
            _danhMucBusiness.Delete(id);
        }
    }
}
