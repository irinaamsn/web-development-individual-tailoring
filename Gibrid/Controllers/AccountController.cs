
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Threading.Tasks;
using Gibrid.Models;


namespace Gibrid.Controllers
{
    public class AccountController : Controller//аккаунт пользователя
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account model)//получение в виде модели данныз из формы заполненной пользователем при регистрации
        {
            if (ModelState.IsValid)//если данные заполнены валидно
            {
                User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year, Password = model.Password };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);//создание аккаунта

                if (result.Succeeded)
                {
                    // установка куки
                    await _userManager.AddToRoleAsync(user, "user");//установка роли зарегистрировавшему пользователю
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "/Account/PersonalAccount")
        {
            return View(new Login { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)//получение в модели данные введенные пользователем для входа
        {
            if (ModelState.IsValid)
            {
                User user = _userManager.FindByNameAsync(model.Email).Result;
                var res = _signInManager.UserManager.CheckPasswordAsync(user, model.Password).Result;//проверка данных

                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и(или) пароль");
                }
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()//выход из аккаунта
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
