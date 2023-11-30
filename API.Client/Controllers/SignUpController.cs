using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        public SignUpController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        public ActionResult SignUp([FromForm] TaiKhoan tk)
        {
            try
            {
                _userBusiness.SignUp(tk);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
