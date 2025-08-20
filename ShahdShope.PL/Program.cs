
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShahdShope.BLL.Services.classes;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.Data;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.classes;
using ShahdShope.DAL.Repositories.interfaces;
using ShahdShope.DAL.Utils;

namespace ShahdShope.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])); 
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<ISeedData, SeedData>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            var scope = app.Services.CreateScope();
            var objectOfSeedData = scope.ServiceProvider.GetRequiredService<ISeedData>();
            await objectOfSeedData.DataSeedingAsync();
            await objectOfSeedData.IdentityDataSeedingAsync();
();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
