using eTicaret.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure.DataContext
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Mert",
                    Email = "cmert34471@outlook.com",
                    UserName = "mert123",
                    Address = new Address
                    {
                        FirstName = "Mert",
                        LastName = "Çelik",
                        Street = "Aykut Ozan Cad",
                        City = "Aydın",
                        State = "TR",
                        ZipCode = "09600",
                    }
                };
                await userManager.CreateAsync(user, "admin123");
            }
        }
    }
}
