using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperShop2.Data;
using SuperShop2.Data.Entities;
using SuperShop2.Helpers;

namespace SuperShop2;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        // Load configuration
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<DataContext>(cfg =>
        {
            cfg.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddIdentity<User, IdentityRole>(cfg =>
        {
            cfg.User.RequireUniqueEmail = true;
            cfg.Password.RequireDigit = false;
            cfg.Password.RequiredUniqueChars = 0;
            cfg.Password.RequireUppercase = false;
            cfg.Password.RequireLowercase = false;
            cfg.Password.RequireNonAlphanumeric = false;
            cfg.Password.RequiredLength = 6;
        })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

        //builder.Services.AddScoped<IRepository, Repository>();
        builder.Services.AddScoped<IUserHelper, UserHelper >();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DataContext>();
            var userHelper = services.GetRequiredService<IUserHelper>();

            var seeder = new Seed.SeedDb(context, userHelper);
            await seeder.SeedAsync();
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }
}