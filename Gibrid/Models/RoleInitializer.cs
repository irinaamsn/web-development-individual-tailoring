using Gibrid.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Gibrid.Models
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {//метод используется для инициализации начальных ролей и учетных записей пользователей в системе
            string adminEmail = "admin@gmail.com";//почта админа
            string password = "_Aa123456";//пароль админа

            if (await roleManager.FindByNameAsync("admin") == null)//проверка, существует ли роль "admin" в системе
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));//иначе создается
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("master") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("master"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)// проверка, существует ли учетная запись пользователя с указанным адресом электронной почты
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, Password = password };
                //admin.Id = Guid.NewGuid().ToString();
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)//Если создание успешно, то пользователь добавляется в роль "admin" 
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
