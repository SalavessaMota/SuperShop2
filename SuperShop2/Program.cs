using Microsoft.EntityFrameworkCore;
using SuperShop2.Data;

namespace SuperShop2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Load configuration
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DataContext>(cfg =>
        {
            cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });


        //builder.Services.AddScoped<IRepository, Repository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();
            db.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}