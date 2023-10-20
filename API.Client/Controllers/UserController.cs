using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;

namespace API.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Authentication tk)
        {
            var user = _userBusiness.Login(tk.TenTk, tk.MatKhau);
            if (user == null)
                return NotFound("Sai tai khoan hoac mat khau. Vui long xem lai" );
            return Ok(new { taikhoan = user.TenTK, email = user.Email, token = user.Token });
        }
    }
}
