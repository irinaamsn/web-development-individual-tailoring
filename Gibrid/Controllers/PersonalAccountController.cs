using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Gibrid.VewModels;

namespace Gibrid.Controllers
{
    public class PersonalAccountController:Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPersonalAccount personalAccountPepos;
        private readonly IListTime listTimeRepos;
        private readonly IAllSpecialist spRepos;
        private readonly IAllSignUp SignUpRepos;
        private readonly IDataStorage dataRepos;
        private readonly IReview reviewRepos;
       
        private readonly Reseption reseption;
        public PersonalAccountController(UserManager<User> userManager,  IPersonalAccount personalAccountPepos, IListTime listTimeRepos, IAllSpecialist spRepos, IAllSignUp allSignUp, IDataStorage dataRepos, IReview reviewRepos, Reseption reseption)
        {          
            _userManager = userManager;
            this.personalAccountPepos = personalAccountPepos;
            this.listTimeRepos = listTimeRepos;
            this.spRepos = spRepos;
            SignUpRepos = allSignUp;
            this.dataRepos = dataRepos;
            this.reviewRepos = reviewRepos;
          
            this.reseption = reseption;
        }

        //public async Task<IActionResult> Index()
        //{
        //    string userName = User.Identity.Name;
        //    User user = await _userManager.FindByNameAsync(userName);

        //    //ViewBag.Message = "Добро пoжаловать в личный кабинет";
        //    return View(user);
        //}
        public IActionResult CreateSignUp(int idSp)
         {
            var list = reseption.getReseptionItem();
            var specialist = spRepos.getObjectSpecialist(idSp);
            var times = listTimeRepos.getAllTimeDetails.Where(x => x.SpecialistDetailsId == specialist.Id && !x.isDelete);
            if (times.Count() == 0) specialist.isHasTime = false;
            var listTime = listTimeRepos.getAllTimeDetails.Where(x => x.SpecialistDetailsId == idSp);
            SignUpDetail sign = null;
            ReseptionItem newLst = null;
            CreateSignUpViewModel model = null;
           if (list==null)
            {
                var user = User.Identity.Name;
                var userId = _userManager.FindByNameAsync(user).Result.Id;

                sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x => x.UserId == userId && !x.isDelete && !x.isServiced);
                if (sign !=null) newLst = new ReseptionItem { Time = sign.Time };
                model = new CreateSignUpViewModel { Specialist = specialist, allTimeSpecialist = listTime, ReseptionItems = newLst };
            }
            else model = new CreateSignUpViewModel { Specialist = specialist, allTimeSpecialist = listTime, ReseptionItems = list };
            return View(model);
        }
        public IActionResult DropdownAlerts()
        {
            return View("MyAlerts",User.Identity.Name);
        }
        //public async Task<IActionResult> MyAlerts(string name)
        //{
        //    User user = await _userManager.FindByNameAsync(name);
           
        //    var list = alertRepos.allAlerts.Where(x => x.UserId == user.Id);
        //    return View(list);
        //}
        public IActionResult RateMaster()
        {     
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RateMaster(ReviewViewModel reviews, int id, int storId ,int Rating)
        {
            var specialist = spRepos.getObjectSpecialist(id);
            spRepos.ChangeRating(specialist, Rating);
            var clientName = User.Identity.Name;
           
            User user = await _userManager.FindByNameAsync(clientName);
            var clientId = user.Id;
            var storage = dataRepos.allDataStorages.SingleOrDefault(x => x.Id == storId);
            //storage.isRate = true;
            if (ModelState.IsValid)
            {
                reviewRepos.createReview(reviews, user, id, Rating);
                
            }
            Thread.Sleep(1000);
            return RedirectToAction("Signs", new { name = clientName });
        }
        public async Task<IActionResult> Settings(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            SettingsViewModel model = new SettingsViewModel { UserName = user.UserName, Email = user.Email, Year = user.Year, OldPassword = user.Password };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(model.UserName);//
                if (user != null)//todo
                {                  
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Year = model.Year;
                    user.Password = model.NewPassword;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return View(model);
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

        public IActionResult Signs(string name)
        {
            UserViewModel model = null;
            var id = _userManager.FindByNameAsync(name).Result.Id;
            var sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x => x.UserId == id && !x.isDelete);

            if (sign != null)
            {
                var time = listTimeRepos.getObjectTimeDetail(sign.TimeSignId);
                model = new UserViewModel
                {
                    Sign = sign,
                    Time = time,
                    Specialist = spRepos.Specialists.SingleOrDefault(x => x.Id == sign.SpecialistId),
                    OldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList()

                };
            }
            else
            {
                var oldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList();
                model = new UserViewModel
                {
                    Sign = sign,

                    OldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList()

                };
            }
            //var obj = personalAccountPepos.mySignUp(id);
            return View(model);
        }


        public ViewResult SpecialistList()
        {
            var allspecialists = spRepos.Specialists;
            var times = listTimeRepos.getAllTimeDetails;
            var list = new PersonalAccountViewModel
            {
                getAllSpecialist=allspecialists,
                getAllTimes=times
            };

            return View(list);
        }
        public IActionResult CancelSignUp(int signId/*, int timeId*/)//idSignUpDetail, idSpecialistDetail, TimeSpecialistDetail
        {
            var sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x=>x.Id==signId);
            var timeId = sign.TimeSignId;
            var specialist = spRepos.Specialists.SingleOrDefault(x => x.Id == sign.SpecialistId); specialist.isHasTime = true;
            listTimeRepos.ReturnTime(timeId);
            personalAccountPepos.DeleteSignUp(signId);
            return RedirectToAction("Signs", "PersonalAccount", new {name=User.Identity.Name});
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Запись отменена";
            return View();
        }
    }
}
