using Microsoft.EntityFrameworkCore;
using SuperShop2.Data;
using SuperShop2.Data.Entities;
using Microsoft.AspNetCore.Identity;
using SuperShop2.Helpers;

namespace SuperShop2.Seed
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            // Aplica as migrações
            //await _context.Database.MigrateAsync();
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("nunosalavessa@hotmail.com");

            if(user == null)
            {
                user = new User
                {
                    FirstName = "Nuno",
                    LastName = "Mota",
                    Email = "nunosalavessa@hotmail.com",
                    UserName = "nunosalavessa@hotmail.com",
                    PhoneNumber = "1234567890",
                };

                var result = await _userHelper.AddUserAsync(user, "Password1!");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            // Cria produtos, se necessário
            if (!_context.Products.Any())
            {
                AddProduct("Iphone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series 4", user);
                AddProduct("iPad Mini", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(100, 2000),
                IsAvailable = true,
                Stock = _random.Next(10, 100),
                User = user
            });
        }
    }
}
