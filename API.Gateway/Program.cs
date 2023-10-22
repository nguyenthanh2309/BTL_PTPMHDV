
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using BLL.Interfaces;
using BLL;
using DAL;
using DAL.Interfaces;

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.UseOcelot().Wait();

            app.Run();
        }
    }
}