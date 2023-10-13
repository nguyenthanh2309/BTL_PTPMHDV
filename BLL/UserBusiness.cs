using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepos _res;
        private string secret;
        public UserBusiness(IUserRepos res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public TaiKhoan Login(string tenTk, string matKhau)
        {
            var user = _res.Login(tenTk, matKhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.TenTK),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
