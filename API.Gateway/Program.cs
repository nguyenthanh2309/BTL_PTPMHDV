using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using BLL.Interfaces;
using BLL;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using static DTO.Authentication;
using System.Text;

namespace API.Gateway
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

            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                                 .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            builder.Services.AddControllers();
            builder.Services.AddOcelot();

            IConfiguration configuration = builder.Configuration;
            var appSettingsSection = configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var access_key = Encoding.ASCII.GetBytes(appSettings.Access);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            builder.Services.AddTransient<IUserRepos, UserRepos>();
            builder.Services.AddTransient<IUserBusiness, UserBusiness>();

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

            app.UseMiddleware<JWTMiddleware>();

            app.UseOcelot().Wait();

            app.Run();
        }
    }
}