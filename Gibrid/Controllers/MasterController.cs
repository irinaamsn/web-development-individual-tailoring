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
        private readonly IListTime timeRepos;
        public MasterController(IAllSignUp sign, IAllSpecialist spRepos,  UserManager<User> _userManager, IPersonalAccount personalAccount, IAllWorks workRepos, ISpecialistCategory categoryRepos, IReview review, IListTime timeRepos)
        {
            SignUpRepos = sign;
            specialistRepos = spRepos;
            this._userManager = _userManager;
            personRepos = personalAccount;
            this.workRepos = workRepos;
            this.categoryRepos = categoryRepos;
            this.review = review;
            this.timeRepos = timeRepos;
        }
        public IActionResult Index()
        {
            string user = User.Identity.Name;//имя авторизованного пользователя
            User userObj = _userManager.FindByNameAsync(user).Result;//авторизованный пользователь
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.userId == userObj.Id);//мастер под этим пользователем
            var listWorks = workRepos.WorksDetails.Where(x => x.SpecialistId == specialist.Id);//поиск всех работ мастера по его ID
            var listsignUpDetails = SignUpRepos.AllSignUpDetails.Where(x => x.SpecialistId == specialist.Id);//find his signUps  
            var home = new MasterViewModel()//класс использующийся в представлении
            {
                signUps = listsignUpDetails,
                worksDetails=listWorks
                
            };
            return View(home);
        }
        public async Task<IActionResult> MySigns(string name)//name -имя пользователя
        {
            User user = await _userManager.FindByNameAsync(name);//поиск пользователя по имени в аккаунте
            // var list = _userManager.GetUsersInRoleAsync("master").Result;
            var listSignVM = new List<SignViewModel>();//коллекция для хранения записей
            var master = specialistRepos.Specialists.SingleOrDefault(x => x.userId == user.Id);//поиск мастера по айди пользователя
            var times = timeRepos.getAllTimeDetails.Where(x => x.SpecialistDetailsId == master.Id && !x.isDelete);//поиск всего времени мастера (свободные и несвободные)
            var listsignUpDetails = SignUpRepos.AllSignUpDetails.Where(x => x.SpecialistId == master.Id);//поиск записей мастера
            var listSignUp = SignUpRepos.AllSignUp;
            foreach (var signup in listsignUpDetails)
                foreach (var sign in listSignUp)
                {
                    if (signup.SignUpId == sign.Id)
                    {
                        var model = new SignViewModel//класс содержаший информацию о записи
                        {
                            UserId = user.Id,
                            SignId = sign.Id,
                            NameUser = sign.Name,
                            PhoneUser = sign.phone,
                            Time = signup.Time,
                            IsServiced = signup.isServiced
                        };
                        listSignVM.Add(model);//добавляем в коллекцию
                    }
                }
            var calendar = new CalendarViewModel//класс использующийся в View 
            {
                signViewModels = listSignVM,
                times = times.ToList()
        };
            return View(calendar);
        }
        public async Task<IActionResult> MyRates(string name)//name-имя пользователя
        {
            User user = await _userManager.FindByNameAsync(name);//поиск пользователя по имени в аккаунте
            var master = specialistRepos.Specialists.SingleOrDefault(x => x.userId == user.Id);//поиск мастера по айди пользователя
            var listReviews = review.allReviewsDetails.Where(x => x.SpecialistId == master.Id);//поиск записей мастера
               
            return View(listReviews.ToList());
        }
        public IActionResult Serviced(int signId)//ID записи
        {
            var userId = SignUpRepos.getObjSignUpDetail(signId).UserId;//поиск айди пользователя из записи
            User user = _userManager.FindByIdAsync(userId).Result;//получение пользователя по его ID

            personRepos.DeleteSignUpByMaster(signId);//метод для удаления завершенной записи мастером (не удаляется из БД, помечается в свойствах как удаленная)
           
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.Id == SignUpRepos.getObjSignUpDetail(signId).SpecialistId);//получение специалиста по айди из записи
           
            var name = _userManager.FindByIdAsync(specialist.userId).Result;//получение пользователя
            return RedirectToAction("MySigns", new { name = name.UserName});//перенаправляет на страницу с записями мастера
        }
        
        public IActionResult ListReviews()//will some actions on view - click on button
        {
            return View();
        }
        public IActionResult ListWorks()//will some actions on view - click on button
        {
            string user = User.Identity.Name;//имя авторизованного пользователя
            User userObj = _userManager.FindByNameAsync(user).Result;//авторизованный пользователь полученный по его имени
            var specialist = specialistRepos.Specialists.SingleOrDefault(x => x.userId == userObj.Id);//получение мастера по ID
            var listWorks = workRepos.WorksDetails.Where(x => x.SpecialistId == specialist.Id);//поиск всех работ мастера по его ID
            return View(listWorks);
        }
        public IActionResult AddWork()//will some actions on view - click on button
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWork(WorkViewModel work)//класс содержащий информацию о фото которое мастер добавил
        {
            string user = User.Identity.Name;//имя авторизованного пользователя
            User userObj = _userManager.FindByNameAsync(user).Result;//авторизованный пользователь
            workRepos.createWork(work, userObj.Id);//метод создания и добавления в БД работы
            
            return RedirectToAction("ListWorks");//перенаправляет на страницу с его работами

        }

        //[HttpPost]
        public ActionResult DeleteWork(int id)//ID работы которую мастер хочет удалить
        {
            string user = User.Identity.Name;//имя авторизованного пользователя
            var work = workRepos.WorksDetails.SingleOrDefault(x => x.Id == id);//получение работы по айди 
            if (work != null)
               workRepos.Delete(work);//метод удаления работы (не удаляется из БД)
            User userObj = _userManager.FindByNameAsync(user).Result;
            return  RedirectToAction("Index", "Master");//перенаправляет на главную страницу мастера
        }


        public IActionResult AddTime()//will some actions on view - click on button
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTime(TimeViewModel model, string name)//получение класса который хранит инфоомацию о добавленном времени, имя пользователя (мастера)
        {
            if (timeRepos.getAllTimeDetails.Any(x => x.TimeSpecialist == model.Time)) return RedirectToAction("CompleteNotTime");
            var user = _userManager.FindByNameAsync(name).Result;//получение пользователя по его имени
            var id= specialistRepos.Specialists.SingleOrDefault(x => x.userId == user.Id).Id;//получение айди мастера по его айди пользоваетля
            // if (ModelState.IsValid)
            {
                timeRepos.createTime(model, id);//метод создания времени и добавления в БД
                return RedirectToAction("Index");//перенаправляет на главную страницу мастера
            }
          //  return View(model);
        }

        public IActionResult CompleteWork()
        {
           
            return View();
        }
    }
}
