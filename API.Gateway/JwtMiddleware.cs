using Microsoft.Extensions.Options;
using BLL.Interfaces;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static DTO.Authentication;

namespace API.Gateway
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private IUserBusiness _userBusiness;

        public JWTMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IUserBusiness userBusiness)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _userBusiness = userBusiness;
        }

        public async Task GenerateToken(HttpContext context)
        {
            var taiKhoan = context.Request.Form["username"].ToString();
            var matKhau = context.Request.Form["password"].ToString();
            var user = _userBusiness.Login(taiKhoan, matKhau);
            var response = new { MaNguoiDung = user.ID, Email = user.Email, Token = user.Token };
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
            return;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Expose-Headers", "*");
            if (!context.Request.Path.Equals("/api/token", StringComparison.Ordinal))
            {
                return _next(context);
            }
            if (context.Request.Method.Equals("POST") && context.Request.HasFormContentType)
            {
                return GenerateToken(context);
            }
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Bad request.");
        }
    }
}