using AriTechno.Access.Repositories;
using AriTechno.Access.Repositories.Interfaces;
using AriTechno.Database;
using AriTechno.Service.Services;
using AriTechno.Service.Services.Interfaces;

namespace AriTechno.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionAddress = builder.Configuration.GetConnectionString("AriTechnoDBConnection");
            builder.Services.AddSqlServer<AriTechnoDB>(connectionAddress);


            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IBasketService, BasketService>();


            builder.Services.AddScoped<ICategoryRespository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            //AdminPanel alanına ait controller'lar için route tanımlaması yapıyoruz.
            //Route=> URL yapısı. Bu ayarlama olmadan Area'ya ait controller'lara erişmeye çalıştığımızda ulaşamayız.
            app.MapAreaControllerRoute(
                name: "areas",
                areaName: "AdminPanel",
                pattern: "AdminPanel/{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Anasayfa}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
