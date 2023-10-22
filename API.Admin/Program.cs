
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}