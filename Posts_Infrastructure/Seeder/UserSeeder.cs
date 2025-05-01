

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Posts_Data.Entities.Identity;

namespace Posts_Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var usersCount = await userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultUser = new User()
                {
                    FullName = "Admin",
                    Email = "Admin@gmail.com",
                    UserName = "admin"
                };
                var result = await userManager.CreateAsync(defaultUser, "P@$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
        }

    }
}
