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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepos _res;
        private string access;
        public UserBusiness(IUserRepos res, IConfiguration configuration)
        {
            _res = res;
            access = configuration["AppSettings:Access"];
        }

        public TaiKhoan Login(string username, string password)
        {
            var user = _res.Login(username, password);
            if (user == null)
                return null;
            else
            {
                GenerateAccessToken(user);
                user.RefreshToken = GenerateRefreshToken();
            }
            return user;
        }

        public string SignUp(TaiKhoan tk)
        {
            return _res.SignUp(tk);
        }

        public void GenerateAccessToken(TaiKhoan tk)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var access_key = Encoding.ASCII.GetBytes(access);
            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, tk.TenTK),
                    new Claim(ClaimTypes.Email, tk.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(access_key), SecurityAlgorithms.Aes128CbcHmacSha256),
            };
            var access_token = tokenHandler.CreateToken(accessTokenDescriptor);
            tk.AccessToken = tokenHandler.WriteToken(access_token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
