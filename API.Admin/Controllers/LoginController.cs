using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Newtonsoft.Json;

namespace API.Client.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        public LoginController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost]
        public string Login([FromForm] Authentication tk)
        {
            var user = _userBusiness.Login(tk.Username, tk.Password);
            if (user == null)
                return "Khong tim thay tai khoan nay";
            return JsonConvert.SerializeObject(new
            {
                access_token = user.AccessToken,
                refresh_token = user.RefreshToken
            });
        }
    }
}
