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
        public string SignUp([FromForm] TaiKhoan tk)
        {
            return _userBusiness.SignUp(tk);
        }
    }
}
