using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using System.Reflection;

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

        //[HttpPost]
        //public ActionResult Login([FromForm] Authentication tk)
        //{
        //    var user = _userBusiness.Login(tk.TenTk, tk.MatKhau);
        //    if (user == null) return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
        //    return Ok(new { taikhoan = user.TenTK, email = user.Email, token = user.Token });
        //}
    }
}
