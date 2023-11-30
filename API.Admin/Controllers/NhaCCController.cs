using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class NhaCCController : ControllerBase
    {
        private INhaCCBusniess _NhaCCBusiness;

        public NhaCCController(INhaCCBusniess NhaCCBusiness)
        {
            _NhaCCBusiness = NhaCCBusiness;
        }

        [Route("{id}")]
        [HttpGet]
        public NhaCC GetNhaCCByID(int id)
        {
            return _NhaCCBusiness.GetNhaCCByID(id);
        }

        [Route("getall")]
        [HttpGet]
        public List<NhaCC> GetAllNhaCC()
        {
            var listNhaCC = _NhaCCBusiness.GetAllNhaCC();
            return listNhaCC;
        }

        [Route("create")]
        [HttpPost]
        [Authorize]
        public void Create([FromForm] NhaCC nhacc)
        {
            _NhaCCBusiness.Create(nhacc);
        }

        [Route("update")]
        [HttpPost]
        [Authorize]
        public void Update([FromBody] string json)
        {
            _NhaCCBusiness.Update(json);
        }

        [Route("delete")]
        [HttpPost]
        public void Delete(int id)
        {
            _NhaCCBusiness.Delete(id);
        }
    }
}
