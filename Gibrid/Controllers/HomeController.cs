using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Gibrid.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAllWorks _allWorks;
        private readonly SignInManager<User> _signInManager;
        public HomeController( IAllWorks allWorks, SignInManager<User> signInManager)
        {
            _allWorks = allWorks;
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User) == User.IsInRole("master"))
            {
                return RedirectToAction("Index", "Master");
            }
                var home = new HomeViewModel()
                {
                    allWorks = _allWorks.WorksDetails.ToList()
                };
                return View(home);
            
            //else if (_signInManager.IsSignedIn(User) == User.IsInRole("master"))
               
            //return RedirectToAction("IndexAdmin","Home");
        }
       public IActionResult IndexAdmin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
