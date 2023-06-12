using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Microsoft.AspNetCore.Mvc;
using Gibrid.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Gibrid.VewModels;

namespace Gibrid.Controllers
{
    public class SignUpController:Controller
    {
        private readonly IAllSignUp allSignUp;
        private readonly IListTime listTimerepos;
        private readonly IAllSpecialist allSpecialist;
        private readonly IDataStorage dataStorageRepos;
        private readonly Reseption reseption;
        private readonly UserManager<User> _userManager;
 
        public SignUpController(Reseption reseption,IAllSignUp allSignUp, IAllSpecialist allSpecialist,UserManager<User> user,IDataStorage data,IListTime listTime)
        {
            this.reseption = reseption;
            this.allSignUp = allSignUp;
            this.allSpecialist = allSpecialist;
            _userManager=user;  
            dataStorageRepos=data;
            listTimerepos=listTime;
        }
        public IActionResult CheckSignUp()//will some actions on view - click on button
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CheckSignUp(string name, string phone, int timeId )//UserName=Email
        {
            var sign = new SignUp { Name = name, phone = phone };
            var user = User.Identity.Name;
            var id = _userManager.FindByNameAsync(user).Result.Id;
            //var anySign = allSignUp.AllSignUpDetails.SingleOrDefault(x => x.UserId == id);
            //if (allSignUp.AllSignUpDetails.Any(x => x.UserId == id)) return RedirectToAction("Complete2");
            reseption.ReseptionItem = reseption.getReseptionItem();
            if (ModelState.IsValid)
            {
                allSignUp.createSignUp(sign, id, timeId);

                var signDet = allSignUp.AllSignUpDetails.SingleOrDefault(x => x.SignUpId == sign.Id);
               
                listTimerepos.DeleteTime(timeId);//DELETE
                                                            //return RedirectToAction("Complete");
                return RedirectToAction("CreateSignUp", "PersonalAccount", new { idSp = signDet.SpecialistId });
            }
            return View(sign);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Вы записаны";
            return View();
        }

    }
}
