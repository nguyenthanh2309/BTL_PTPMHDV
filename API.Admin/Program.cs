
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using static DTO.Authentication;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BTL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            builder.Services.AddTransient<ISanPhamRepos, SanPhamRepos>();
            builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
            builder.Services.AddTransient<ITaiKhoanRepos, TaiKhoanRepos>();
            builder.Services.AddTransient<ITaiKhoanBusiness, TaiKhoanBusiness>();
            builder.Services.AddTransient<IKhachHangRepos, KhachHangRepos>();
            builder.Services.AddTransient<IKhachHangBusiness, KhachHangBusiness>();
            builder.Services.AddTransient<IUserRepos, UserRepos>();
            builder.Services.AddTransient<IUserBusiness, UserBusiness>();
            builder.Services.AddTransient<IDanhMucRepos, DanhMucRepos>();
            builder.Services.AddTransient<IDanhMucBusiness, DanhMucBusiness>();
            builder.Services.AddTransient<INhaCCRepos, NhaCCRepos>();
            builder.Services.AddTransient<INhaCCBusniess, NhaCCBusniess>();

            IConfiguration configuration = builder.Configuration;
            var appSettingsSection = configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var access_key = Encoding.ASCII.GetBytes(appSettings.Access);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(access_key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}