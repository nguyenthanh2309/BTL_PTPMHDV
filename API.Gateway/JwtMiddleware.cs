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
            var tenTk = context.Request.Form["tenTk"].ToString();
            var matKhau = context.Request.Form["matKhau"].ToString();
            var user = _userBusiness.Login(tenTk, matKhau);
            var response = new { TenTaiKhoan = user.TenTK, Email = user.Email, access_token = user.AccessToken, refresh_token = user.RefreshToken };
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