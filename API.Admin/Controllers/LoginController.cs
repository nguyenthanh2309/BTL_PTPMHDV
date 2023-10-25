using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        public LoginController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost]
        public ActionResult Login([FromBody] Authentication tk)
        {
            var user = _userBusiness.Login(tk.TenTk, tk.MatKhau);
            if (user == null)
                return NotFound("Tài khoản hoặc mật khẩu không đúng!");
            return Ok(new { taikhoan = user.TenTK, email = user.Email, token = user.Token });
        }
    }
}
