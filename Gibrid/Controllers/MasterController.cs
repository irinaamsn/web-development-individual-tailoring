using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gibrid.Models.Enum;

namespace Gibrid.Controllers
{
    public class MasterController:Controller
    {
        private readonly IAllSignUp SignUpRepos;
        private readonly IAllSpecialist specialistRepos;
        private readonly ISpecialistCategory categoryRepos;
        private readonly UserManager<User> _userManager;
        private readonly IPersonalAccount personRepos;
        private readonly IAllWorks workRepos;
        private readonly IReview review;
        public MasterController(IAllSignUp sign, IAllSpecialist spRepos,  UserManager<User> _userManager, IPersonalAccount personalAccount, IAllWorks workRepos, ISpecialistCategory categoryRepos, IReview review)
        {
            SignUpRepos = sign;
            specialistRepos = spRepos;
            this._userManager = _userManager;
            personRepos = personalAccount;
            this.workRepos = workRepos;
            this.categoryRepos = categoryRepos;
            this.review = review;
        }
        public IActionResult Index()
        {
            string user = User.Identity.Name;
            User userObj = _userManager.FindByNameAsync(user).Result;
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.userId == userObj.Id);
            var listWorks = workRepos.WorksDetails.Where(x => x.SpecialistId == specialist.Id);
            var listsignUpDetails = SignUpRepos.AllSignUpDetails.Where(x => x.SpecialistId == specialist.Id);//find his signUps  
            var home = new MasterViewModel()
            {
                signUps = listsignUpDetails,
                worksDetails=listWorks
                
            };
                return View(home);
        }
        public async Task<IActionResult> MySigns(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            // var list = _userManager.GetUsersInRoleAsync("master").Result;
            var listSignVM = new List<SignViewModel>();
            var master = specialistRepos.Specialists.SingleOrDefault(x => x.userId == user.Id);//find master
            var listsignUpDetails = SignUpRepos.AllSignUpDetails.Where(x => x.SpecialistId == master.Id);//find his signUps
            var listSignUp = SignUpRepos.AllSignUp;
            foreach (var signup in listsignUpDetails)
                foreach (var sign in listSignUp)
                {
                    if (signup.SignUpId == sign.Id )//TODO
                    {
                        var model = new SignViewModel
                        {
                            UserId = user.Id,
                            SignId = sign.Id,
                            NameUser = sign.Name,
                            PhoneUser = sign.phone,
                            Time = signup.Time,
                            IsServiced = signup.isServiced
                        };
                        listSignVM.Add(model);
                    }
                }
            return View(listSignVM);
        }
        public async Task<IActionResult> MyRates(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            // var list = _userManager.GetUsersInRoleAsync("master").Result;
            var master = specialistRepos.Specialists.SingleOrDefault(x => x.userId == user.Id);//find master
            var listReviews = review.allReviewsDetails.Where(x => x.SpecialistId == master.Id);//find his signUps
               
            return View(listReviews.ToList());
        }
        public IActionResult Serviced(int signId)
        {
            var userId = SignUpRepos.getObjSignUpDetail(signId).UserId;
            User user = _userManager.FindByIdAsync(userId).Result;

            personRepos.DeleteSignUpByMaster(signId);
           
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.Id == SignUpRepos.getObjSignUpDetail(signId).SpecialistId);
           
            var name = _userManager.FindByIdAsync(specialist.userId).Result;
            // alertRepos.createAlert(CategoryAlertEnum.PostReview, user);
            return RedirectToAction("MySigns", new { name = name.UserName});
        }
        
        public IActionResult ListReviews()//will some actions on view - click on button
        {
            return View();
        }
        public IActionResult ListWorks()//will some actions on view - click on button
        {
            string user = User.Identity.Name;
            User userObj = _userManager.FindByNameAsync(user).Result;
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.userId == userObj.Id);
            var listWorks = workRepos.WorksDetails.Where(x => x.SpecialistId == specialist.Id);
            return View(listWorks);
        }
        public IActionResult AddWork()//will some actions on view - click on button
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWork(WorkViewModel work)//
        {
            string user = User.Identity.Name;
            User userObj = _userManager.FindByNameAsync(user).Result;
            workRepos.createWork(work, userObj.Id);
            
            return RedirectToAction("ListWorks");

        }
        //[HttpPost]
        public ActionResult DeleteWork(int id)
        {
            string user = User.Identity.Name;
            var work = workRepos.WorksDetails.SingleOrDefault(x => x.Id == id);
            //var idSp = work.SpecialistId;
            
            if (work != null)
               workRepos.Delete(work);
            User userObj = _userManager.FindByNameAsync(user).Result;
            return  RedirectToAction("Index", "Master");
        }
        
        
       //public ActionResult GetWork(int id, bool isJson)
       // {

       // }
      
        public IActionResult CompleteWork()
        {
           
            return View();
        }
    }
}
