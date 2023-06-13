using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Gibrid.VewModels;

namespace Gibrid.Controllers
{
    public class UserController:Controller
    {
        
            UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            RoleManager<IdentityRole> _roleManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
            }

            public async Task<IActionResult> Index()
            {
                //User user = await _userManager.FindByIdAsync(model.Id.ToString());//
                return View(_userManager.Users.ToList());
            }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)//создание пользователя используя необходимые данные
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year, Password=model.Password };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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
        public async Task<IActionResult> ChangePassword(string id)//изменение пароля пользователя зная его ID
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)// получение модели новых данных и сохранение изменений 
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result =  await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    user.Password=model.NewPassword;
                    var result2 = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(string id)//редактиование ПД пользователя
        {
                User user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Year = user.Year };
                return View(model);
        }

            [HttpPost]
            public async Task<IActionResult> Edit(EditUserViewModel model)//получение модели с новыми данными
            {
                if (ModelState.IsValid)
                {
                    User user = await _userManager.FindByIdAsync(model.Id.ToString());//
                    if (user != null)
                    {
                        user.Email = model.Email;
                        user.UserName = model.Email;
                        user.Year = model.Year;

                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                return View(model);
            }

            [HttpPost]
            public async Task<ActionResult> Delete(string id)//удаление пользователя
            {
                User user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);
                }

                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
    }
}
